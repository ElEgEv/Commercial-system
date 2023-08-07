using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.SearchModels;
using BlacksmithWorkshopContracts.ViewModels;
using BlacksmithWorkshopDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopContracts.StoragesContracts
{
    public interface IShopStorage
    {
        List<ShopViewModel> GetFullList();

        List<ShopViewModel> GetFilteredList(ShopSearchModel model);

        ShopViewModel? GetElement(ShopSearchModel model);

        ShopViewModel? Insert(ShopBindingModel model);

        ShopViewModel? Update(ShopBindingModel model);

        ShopViewModel? Delete(ShopBindingModel model);

        bool SellManufactures(IManufactureModel model, int count);
    }
}
