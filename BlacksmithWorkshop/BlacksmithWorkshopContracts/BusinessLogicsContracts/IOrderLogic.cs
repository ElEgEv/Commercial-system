using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.SearchModels;
using BlacksmithWorkshopContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopContracts.BusinessLogicsContracts
{
    //бизнес-логика для заказов
    public interface IOrderLogic
    {
        List<OrderViewModel>? ReadList(OrderSearchModel? model);

		OrderViewModel? ReadElement(OrderSearchModel model);

		bool CreateOrder(OrderBindingModel model);

        bool TakeOrderInWork(OrderBindingModel model);

        bool FinishOrder(OrderBindingModel model);

        bool DeliveryOrder(OrderBindingModel model);
    }
}
