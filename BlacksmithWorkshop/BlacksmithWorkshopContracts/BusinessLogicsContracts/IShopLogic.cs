using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.SearchModels;
using BlacksmithWorkshopContracts.ViewModels;
using BlacksmithWorkshopDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopContracts.BusinessLogicsContracts
{
    public interface IShopLogic
    {
        List<ShopViewModel>? ReadList(ShopSearchModel? model);

        ShopViewModel? ReadElement(ShopSearchModel model);

        bool Create(ShopBindingModel model);

        bool Update(ShopBindingModel model);

        bool Delete(ShopBindingModel model);

        bool AddManufacture(ShopSearchModel model, IManufactureModel manufacture, int count);
    
        bool SellManufatures(IManufactureModel model, int count);

        bool AddManufactures(IManufactureModel model, int count);
    }
}
