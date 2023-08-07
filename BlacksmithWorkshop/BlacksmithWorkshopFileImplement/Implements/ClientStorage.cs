using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.SearchModels;
using BlacksmithWorkshopContracts.StoragesContracts;
using BlacksmithWorkshopContracts.ViewModels;
using BlacksmithWorkshopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopFileImplement.Implements
{
    public class ClientStorage : IClientStorage
    {
		private readonly DataFileSingleton source;

		public ClientStorage()
		{
			source = DataFileSingleton.GetInstance();
		}

		public List<ClientViewModel> GetFullList()
		{
			return source.Clients.Select(x => x.GetViewModel).ToList();
		}

		public List<ClientViewModel> GetFilteredList(ClientSearchModel model)
        {
			return source.Clients.Where(x => x.Id == model.Id).Select(x => x.GetViewModel).ToList();
		}

		public ClientViewModel? GetElement(ClientSearchModel model)
		{
			if (!model.Id.HasValue)
			{
				return null;
			}

			return source.Clients.FirstOrDefault(x => (model.Id.HasValue && x.Id == model.Id))?.GetViewModel;
		}

		public ClientViewModel? Insert(ClientBindingModel model)
        {
			model.Id = source.Clients.Count > 0 ? source.Clients.Max(x => x.Id) + 1 : 1;

			var newClient = Client.Create(model);

			if (newClient == null)
			{
				return null;
			}

			source.Clients.Add(newClient);
			source.SaveClients();

			return newClient.GetViewModel;
		}

        public ClientViewModel? Update(ClientBindingModel model)
        {
			var client = source.Clients.FirstOrDefault(x => x.Id == model.Id);

			if (client == null)
			{
				return null;
			}

			client.Update(model);
			source.SaveClients();

			return client.GetViewModel;
		}

		public ClientViewModel? Delete(ClientBindingModel model)
		{
			var element = source.Clients.FirstOrDefault(x => x.Id == model.Id);

			if (element != null)
			{
				source.Clients.Remove(element);
				source.SaveClients();

				return element.GetViewModel;
			}

			return null;
		}
	}
}
