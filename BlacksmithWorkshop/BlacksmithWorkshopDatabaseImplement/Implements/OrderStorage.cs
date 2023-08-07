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
    public class OrderStorage : IOrderStorage
    {
        public OrderViewModel? Delete(OrderBindingModel model)
        {
            using var context = new BlacksmithWorkshopDatabase();

            var element = context.Orders
                .Include(x => x.Manufacture)
                .FirstOrDefault(rec => rec.Id == model.Id);

            if (element != null)
            {
                // для отображения КОРРЕКТНОЙ ViewModel-и
                var deletedElement = context.Orders
                    .Include(x => x.Manufacture)
					.Include(x => x.Client)
					.FirstOrDefault(x => x.Id == model.Id)
                    ?.GetViewModel;

                context.Orders.Remove(element);
                context.SaveChanges();

                return deletedElement;
            }

            return null;
        }

        public OrderViewModel? GetElement(OrderSearchModel model)
        {
            using var context = new BlacksmithWorkshopDatabase();
            if (model.ImplementerId.HasValue && model.Status.HasValue)
            {
                return context.Orders
                              .Include(x => x.Manufacture)
                              .Include(x => x.Client)
                              .Include(x => x.Implementer)
                              .FirstOrDefault(x => x.ImplementerId == model.ImplementerId && x.Status == model.Status)
                              ?.GetViewModel;
            }
            if (model.ImplementerId.HasValue)
            {
                return context.Orders
                              .Include(x => x.Manufacture)
                              .Include(x => x.Client)
                              .Include(x => x.Implementer)
                              .FirstOrDefault(x => x.ImplementerId == model.ImplementerId)
                              ?.GetViewModel;
            }
            if (!model.Id.HasValue)
            {
                return null;
            }
            return context.Orders
                .Include(x => x.Manufacture)
                .Include(x => x.Client)
                .Include(x => x.Implementer)
                .FirstOrDefault(x => model.Id.HasValue && x.Id == model.Id)
                ?.GetViewModel;
        }

        public List<OrderViewModel> GetFilteredList(OrderSearchModel model)
        {
			using var context = new BlacksmithWorkshopDatabase();

			if (!model.Id.HasValue && model.DateFrom.HasValue && model.DateTo.HasValue)
            {
				return context.Orders
	                .Include(x => x.Manufacture)
	                .Include(x => x.Client)
					.Include(x => x.Implementer)
					.Where(x => x.DateCreate >= model.DateFrom && x.DateCreate <= model.DateTo)
	                .Select(x => x.GetViewModel)
	                .ToList();
			}
            else if (model.Id.HasValue)
            {
				return context.Orders
                    .Include(x => x.Manufacture)
                    .Include(x => x.Client)
					.Include(x => x.Implementer)
					.Where(x => x.Id == model.Id)
                    .Select(x => x.GetViewModel)
                    .ToList();
			}
			else if (model.ClientId.HasValue)
			{
				return context.Orders
					   .Include(x => x.Manufacture)
					   .Include(x => x.Client)
					   .Include(x => x.Implementer)
					   .Where(x => x.ClientId == model.ClientId)
					   .Select(x => x.GetViewModel)
					   .ToList();
			}
            else if (model.ImplementerId.HasValue)
            {
				return context.Orders
					   .Include(x => x.Manufacture)
					   .Include(x => x.Client)
					   .Include(x => x.Implementer)
					   .Where(x => x.ImplementerId == model.ImplementerId)
					   .Select(x => x.GetViewModel)
					   .ToList();
			}

            return context.Orders
				.Include(x => x.Manufacture)
				.Include(x => x.Client)
				.Include(x => x.Implementer)
				.Where(x => model.Status == x.Status)
                .Select(x => x.GetViewModel)
                .ToList();
		}

        public List<OrderViewModel> GetFullList()
        {
            using var context = new BlacksmithWorkshopDatabase();

            return context.Orders
                .Include(x => x.Manufacture)
				.Include(x => x.Client)
				.Include(x => x.Implementer)
				.Select(x => x.GetViewModel)
                .ToList();
        }

        public OrderViewModel? Insert(OrderBindingModel model)
        {
            var newOrder = Order.Create(model);

            if (newOrder == null)
            {
                return null;
            }

            using var context = new BlacksmithWorkshopDatabase();

            context.Orders.Add(newOrder);
            context.SaveChanges();

            return context.Orders
                .Include(x => x.Manufacture)
				.Include(x => x.Client)
				.FirstOrDefault(x => x.Id == newOrder.Id)
                ?.GetViewModel;
        }

        public OrderViewModel? Update(OrderBindingModel model)
        {
            using var context = new BlacksmithWorkshopDatabase();

            var order = context.Orders.FirstOrDefault(x => x.Id == model.Id);

			if (order == null)
            {
                return null;
            }

            order.Update(model);
            context.SaveChanges();

            return context.Orders
                .Include(x => x.Manufacture)
				.Include(x => x.Client)
				.Include(x => x.Implementer)
				.FirstOrDefault(x => x.Id == model.Id)
                ?.GetViewModel;
        }
    }
}
