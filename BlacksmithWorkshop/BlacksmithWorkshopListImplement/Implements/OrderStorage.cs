using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.SearchModels;
using BlacksmithWorkshopContracts.StoragesContracts;
using BlacksmithWorkshopContracts.ViewModels;
using BlacksmithWorkshopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopListImplement.Implements
{
    //класс, реализующий интерфейс хранилища заказов
    public class OrderStorage : IOrderStorage
    {
        //поле для работы со списком заказов
        private readonly DataListSingleton _source;

        //получение в конструкторе объекта DataListSingleton
        public OrderStorage()
        {
            _source = DataListSingleton.GetInstance();
        }

        //получение полного списка заготовок
        public List<OrderViewModel> GetFullList()
        {
            var result = new List<OrderViewModel>();

            foreach (var order in _source.Orders)
            {
                result.Add(GetViewModel(order));
            }

            return result;
        }

        //получение отфильтрованного списка заказов
        public List<OrderViewModel> GetFilteredList(OrderSearchModel model)
        {
            var result = new List<OrderViewModel>();

            if (!model.Id.HasValue && model.DateFrom.HasValue && model.DateTo.HasValue)
            {
				foreach (var order in _source.Orders)
                {
                    if (order.DateCreate >= model.DateFrom && order.DateCreate <= model.DateTo)
                    {
                        result.Add(GetViewModel(order));
                    }
                }

                return result;
            }
			else if (model.ClientId.HasValue)
			{
				foreach (var order in _source.Orders)
				{
					if (order.ClientId == model.ClientId)
					{
						result.Add(GetViewModel(order));
					}
				}

				return result;
			}
            else if (model.Status.HasValue)
            {
                foreach (var order in _source.Orders)
                {
                    if (order.Status == model.Status)
                    {
                        result.Add(GetViewModel(order));
                    }
                }
                return result;
            }

            foreach (var order in _source.Orders)
            {
                if (order.Id == model.Id)
                {
                    result.Add(GetViewModel(order));
                }
            }

            return result;
		}

        //получение элемента из списка заказов
        public OrderViewModel? GetElement(OrderSearchModel model)
        {
            if (!model.Id.HasValue)
            {
                return null;
            }

            foreach (var order in _source.Orders)
            {
                if (model.Id.HasValue && order.Id == model.Id)
                {
                    return GetViewModel(order);
                }
            }

            return null;
        }

        //метод для передачи названий и имён на форму
        private OrderViewModel GetViewModel(Order order)
        {
            var viewModel = order.GetViewModel;

            foreach (var manufactures in _source.Manufactures)
            {
                if (manufactures.Id == order.ManufactureId)
                {
                    viewModel.ManufactureName = manufactures.ManufactureName;

                    break;
                }
            }

			foreach (var client in _source.Clients)
			{
				if (client.Id == order.ClientId)
				{
					viewModel.ClientFIO = client.ClientFIO;
					break;
				}
			}

			foreach (var implementer in _source.Implementers)
			{
				if (implementer.Id == order.ImplementerId)
				{
					viewModel.ImplementerFIO = implementer.ImplementerFIO;

					break;
				}
			}

			return viewModel;
        }

        //при создании заказа определяем для него новый id: ищем max id и прибавляем к нему 1
        public OrderViewModel? Insert(OrderBindingModel model)
        {
            model.Id = 1;

            foreach (var order in _source.Orders)
            {
                if (model.Id <= order.Id)
                {
                    model.Id = order.Id + 1;
                }
            }

            var newOrder = Order.Create(model);

            if (newOrder == null)
            {
                return null;
            }

            _source.Orders.Add(newOrder);

            return GetViewModel(newOrder);
        }

        //обновление заказа
        public OrderViewModel? Update(OrderBindingModel model)
        {
            foreach (var order in _source.Orders)
            {
                if (order.Id == model.Id)
                {
                    order.Update(model);

                    return GetViewModel(order);
                }
            }

            return null;
        }

        //удаление заказа
        public OrderViewModel? Delete(OrderBindingModel model)
        {
            for (int i = 0; i < _source.Orders.Count; ++i)
            {
                if (_source.Orders[i].Id == model.Id)
                {
                    var element = _source.Orders[i];
                    _source.Orders.RemoveAt(i);

                    return GetViewModel(element);
                }
            }

            return null;
        }
    }
}
