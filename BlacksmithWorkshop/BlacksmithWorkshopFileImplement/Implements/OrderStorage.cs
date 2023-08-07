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
    //реализация интерфейса хранилища заказов
    public class OrderStorage : IOrderStorage
    {
        private readonly DataFileSingleton source;

        public OrderStorage()
        {
            source = DataFileSingleton.GetInstance();
        }

        public List<OrderViewModel> GetFullList()
        {
            return source.Orders.Select(x => GetViewModel(x)).ToList();
        }

        public List<OrderViewModel> GetFilteredList(OrderSearchModel model)
        {
            if (!model.Id.HasValue && model.DateFrom.HasValue && model.DateTo.HasValue)
            {
                return source.Orders.Where(x => x.DateCreate >= model.DateFrom && x.DateCreate <= model.DateTo)
                    .Select(x => GetViewModel(x))
                    .ToList();
            }
            else if (model.ClientId.HasValue)
            {
				return source.Orders
					.Where(x => x.ClientId == model.ClientId)
					.Select(x => GetViewModel(x))
                    .ToList();
			}
			else if (model.ImplementerId.HasValue)
			{
				return source.Orders
					.Where(x => x.ImplementerId == model.ImplementerId)
					.Select(x => GetViewModel(x))
					.ToList();
			}

			return source.Orders
                .Where(x => x.Id == model.Id)
                .Select(x => GetViewModel(x))
                .ToList();
        }

        public OrderViewModel? GetElement(OrderSearchModel model)
        {
            if (model.ImplementerId.HasValue && model.Status.HasValue)
            {
                return source.Orders
                    .FirstOrDefault(x => x.ImplementerId == model.ImplementerId && x.Status == model.Status)
                    ?.GetViewModel;
            }

            if (model.ImplementerId.HasValue)
            {
                return source.Orders
                    .FirstOrDefault(x => x.ImplementerId == model.ImplementerId)
                    ?.GetViewModel;
            }

            if (!model.Id.HasValue)
            {
                return null;
            }

            return source.Orders.FirstOrDefault(x =>(model.Id.HasValue && x.Id == model.Id))?.GetViewModel;
        }

        //для загрузки названий и имён в заказ
        private OrderViewModel GetViewModel(Order order)
        {
            var viewModel = order.GetViewModel;

            var manufacture = source.Manufactures.FirstOrDefault(x => x.Id == order.ManufactureId);

            var client = source.Clients.FirstOrDefault(x => x.Id == order.ClientId);

            var implementer = source.Implementers.FirstOrDefault(x => x.Id == order.ImplementerId);

            if(manufacture != null)
            {
                viewModel.ManufactureName = manufacture.ManufactureName;
            }

            if(client != null)
            {
                viewModel.ClientFIO = client.ClientFIO;
            }

			if (implementer != null)
			{
				viewModel.ImplementerFIO = implementer.ImplementerFIO;
			}

			return viewModel;
        }

        public OrderViewModel? Insert(OrderBindingModel model)
        {
            model.Id = source.Orders.Count > 0 ? source.Orders.Max(x => x.Id) + 1 : 1;

            var newOrder = Order.Create(model);

            if (newOrder == null)
            {
                return null;
            }

            source.Orders.Add(newOrder);
            source.SaveOrders();

            return GetViewModel(newOrder);
        }

        public OrderViewModel? Update(OrderBindingModel model)
        {
            var order = source.Orders.FirstOrDefault(x => x.Id == model.Id);

            if (order == null)
            {
                return null;
            }

            order.Update(model);
            source.SaveOrders();

            return GetViewModel(order);
        }

        public OrderViewModel? Delete(OrderBindingModel model)
        {
            var element = source.Orders.FirstOrDefault(x => x.Id == model.Id);

            if (element != null)
            {
                source.Orders.Remove(element);
                source.SaveOrders();

                return GetViewModel(element);
            }

            return null;
        }
    }
}
