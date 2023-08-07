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
    public class ManufactureStorage : IManufactureStorage
    {
        public List<ManufactureViewModel> GetFullList()
		{
			using var context = new BlacksmithWorkshopDatabase();

			return context.Manufactures
					.Include(x => x.WorkPieces)
					.ThenInclude(x => x.WorkPiece)
					.ToList()
					.Select(x => x.GetViewModel)
					.ToList();
		}

		public List<ManufactureViewModel> GetFilteredList(ManufactureSearchModel model)
		{
			if (string.IsNullOrEmpty(model.ManufactureName))
			{
				return new();
			}

			using var context = new BlacksmithWorkshopDatabase();

			return context.Manufactures
					.Include(x => x.WorkPieces)
					.ThenInclude(x => x.WorkPiece)
					.Where(x => x.ManufactureName.Contains(model.ManufactureName))
					.ToList()
					.Select(x => x.GetViewModel)
					.ToList();
		}

		public ManufactureViewModel? GetElement(ManufactureSearchModel model)
		{
			if (string.IsNullOrEmpty(model.ManufactureName) && !model.Id.HasValue)
			{
				return null;
			}

			using var context = new BlacksmithWorkshopDatabase();

			return context.Manufactures
				.Include(x => x.WorkPieces)
				.ThenInclude(x => x.WorkPiece)
				.FirstOrDefault(x => (!string.IsNullOrEmpty(model.ManufactureName) && x.ManufactureName == model.ManufactureName) ||
								(model.Id.HasValue && x.Id == model.Id))
				?.GetViewModel;
		}

		public ManufactureViewModel? Insert(ManufactureBindingModel model)
		{
			using var context = new BlacksmithWorkshopDatabase();
			var newManufacture = Manufacture.Create(context, model);

			if (newManufacture == null)
			{
				return null;
			}

			context.Manufactures.Add(newManufacture);
			context.SaveChanges();

			return newManufacture.GetViewModel;
		}

		public ManufactureViewModel? Update(ManufactureBindingModel model)
		{
			using var context = new BlacksmithWorkshopDatabase();
			using var transaction = context.Database.BeginTransaction();

			try
			{
				var manufacture = context.Manufactures.FirstOrDefault(rec => rec.Id == model.Id);

				if (manufacture == null)
				{
					return null;
				}

                manufacture.Update(model);
				context.SaveChanges();
                manufacture.UpdateWorkPieces(context, model);
				transaction.Commit();

				return manufacture.GetViewModel;
			}
			catch
			{
				transaction.Rollback();
				throw;
			}
		}

		public ManufactureViewModel? Delete(ManufactureBindingModel model)
		{
			using var context = new BlacksmithWorkshopDatabase();
			var element = context.Manufactures
                .Include(x => x.WorkPieces)
				.Include(x => x.Orders)
				.FirstOrDefault(rec => rec.Id == model.Id);

			if (element != null)
			{
				context.Manufactures.Remove(element);
				context.SaveChanges();

				return element.GetViewModel;
			}

			return null;
		}
    }
}
