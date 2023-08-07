using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.SearchModels;
using BlacksmithWorkshopContracts.StoragesContracts;
using BlacksmithWorkshopContracts.ViewModels;
using BlacksmithWorkshopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopDatabaseImplement.Implements
{
	public class ImplementerStorage : IImplementerStorage
	{
		public List<ImplementerViewModel> GetFullList()
		{
			using var context = new BlacksmithWorkshopDatabase();

			return context.Implementers
				.Include(x => x.Orders)
				.Select(x => x.GetViewModel)
				.ToList();
		}
		public List<ImplementerViewModel> GetFilteredList(ImplementerSearchModel model)
		{
			if (string.IsNullOrEmpty(model.ImplementerFIO))
			{
				return new();
			}

			using var context = new BlacksmithWorkshopDatabase();

			return context.Implementers
				.Include(x => x.Orders)
				.Where(x => x.ImplementerFIO.Contains(model.ImplementerFIO))
				.Select(x => x.GetViewModel)
				.ToList();
		}

		public ImplementerViewModel? GetElement(ImplementerSearchModel model)
		{
			using var context = new BlacksmithWorkshopDatabase();

			if (model.Id.HasValue)
			{
				return context.Implementers
				.Include(x => x.Orders)
				.FirstOrDefault(x => model.Id.HasValue && x.Id == model.Id)
				?.GetViewModel;
			}
			else if (!string.IsNullOrEmpty(model.ImplementerFIO) && !string.IsNullOrEmpty(model.Password))
			{
				return context.Implementers
					.Include(x => x.Orders)
					.FirstOrDefault(x => (x.ImplementerFIO == model.ImplementerFIO && x.Password == model.Password))
					?.GetViewModel;
			}

			return new();
		}

		public ImplementerViewModel? Insert(ImplementerBindingModel model)
		{
			var newImplementer = Implementer.Create(model);

			if (newImplementer == null)
			{
				return null;
			}

			using var context = new BlacksmithWorkshopDatabase();

			context.Implementers.Add(newImplementer);
			context.SaveChanges();

			return context.Implementers
				.Include(x => x.Orders)
				.FirstOrDefault(x => x.Id == newImplementer.Id)
				?.GetViewModel;
		}

		public ImplementerViewModel? Update(ImplementerBindingModel model)
		{
			using var context = new BlacksmithWorkshopDatabase();
			var order = context.Implementers
				.Include(x => x.Orders)
				.FirstOrDefault(x => x.Id == model.Id);

			if (order == null)
			{
				return null;
			}

			order.Update(model);
			context.SaveChanges();

			return context.Implementers
				.Include(x => x.Orders)
				.FirstOrDefault(x => x.Id == model.Id)
				?.GetViewModel;
		}
		public ImplementerViewModel? Delete(ImplementerBindingModel model)
		{
			using var context = new BlacksmithWorkshopDatabase();

			var element = context.Implementers
				.FirstOrDefault(rec => rec.Id == model.Id);

			if (element != null)
			{
				// для отображения КОРРЕКТНОЙ ViewModel-и
				var deletedElement = context.Implementers
					.Include(x => x.Orders)
					.FirstOrDefault(x => x.Id == model.Id)
					?.GetViewModel;

				context.Implementers.Remove(element);
				context.SaveChanges();

				return deletedElement;
			}

			return null;
		}
	}
}
