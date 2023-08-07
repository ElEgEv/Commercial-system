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
    public class ClientStorage : IClientStorage
    {
        public ClientViewModel? Delete(ClientBindingModel model)
        {
			using var context = new BlacksmithWorkshopDatabase();

			var element = context.Clients
				.FirstOrDefault(rec => rec.Id == model.Id);

			if (element != null)
			{
				// для отображения КОРРЕКТНОЙ ViewModel-и
				var deletedElement = context.Clients
					.Include(x => x.Orders)
					.FirstOrDefault(x => x.Id == model.Id)
					?.GetViewModel;

				context.Clients.Remove(element);
				context.SaveChanges();

				return deletedElement;
			}

			return null;
		}

        public ClientViewModel? GetElement(ClientSearchModel model)
        {
			using var context = new BlacksmithWorkshopDatabase();

			if (model.Id.HasValue)
			{
				return context.Clients
				.Include(x => x.Orders)
				.FirstOrDefault(x => x.Id == model.Id)
				?.GetViewModel;
			}
			
			if (!string.IsNullOrEmpty(model.Email) && !string.IsNullOrEmpty(model.Password))
			{
				return context.Clients
					.Include(x => x.Orders)
					.FirstOrDefault(x => (x.Email == model.Email && x.Password == model.Password))
					?.GetViewModel;
			}

			if (!string.IsNullOrEmpty(model.Email))
				return context.Clients
					.FirstOrDefault(x => x.Email == model.Email)
					?.GetViewModel;

			return null;
		}

		public List<ClientViewModel> GetFilteredList(ClientSearchModel model)
		{
			if (string.IsNullOrEmpty(model.ClientFIO))
			{
				return new();
			}

			using var context = new BlacksmithWorkshopDatabase();

			return context.Clients
				.Include(x => x.Orders)
				.Where(x => x.ClientFIO.Contains(model.ClientFIO))
				.Select(x => x.GetViewModel)
				.ToList();
		}

        public List<ClientViewModel> GetFullList()
        {
			using var context = new BlacksmithWorkshopDatabase();

			return context.Clients
				.Include(x => x.Orders)
				.Select(x => x.GetViewModel)
				.ToList();
		}

        public ClientViewModel? Insert(ClientBindingModel model)
        {
			var newClient = Client.Create(model);

			if (newClient == null)
			{
				return null;
			}

			using var context = new BlacksmithWorkshopDatabase();

			context.Clients.Add(newClient);
			context.SaveChanges();

			return context.Clients
				.Include(x => x.Orders)
				.FirstOrDefault(x => x.Id == newClient.Id)
				?.GetViewModel;
		}

        public ClientViewModel? Update(ClientBindingModel model)
        {
			using var context = new BlacksmithWorkshopDatabase();
			var order = context.Clients
				.Include(x => x.Orders)
				.FirstOrDefault(x => x.Id == model.Id);

			if (order == null)
			{
				return null;
			}

			order.Update(model);
			context.SaveChanges();

			return context.Clients
				.Include(x => x.Orders)
				.FirstOrDefault(x => x.Id == model.Id)
				?.GetViewModel;
		}
    }
}
