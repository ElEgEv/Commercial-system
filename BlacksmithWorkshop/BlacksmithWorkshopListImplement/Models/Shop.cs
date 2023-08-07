using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.ViewModels;
using BlacksmithWorkshopDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopListImplement.Models
{
    public class Shop : IShopModel
    {
        public string ShopName { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public DateTime DateOpen { get; set; }

        public int Id { get; set; }

        public int MaxCountManufactures { get; set; }

        public Dictionary<int, (IManufactureModel, int)> ShopManufactures { get; private set; } =
            new Dictionary<int, (IManufactureModel, int)>();

        public static Shop? Create(ShopBindingModel? model)
        {
            if(model == null)
            {
                return null;
            }

            return new Shop()
            {
                Id = model.Id,
                ShopName = model.ShopName,
                Address = model.Address,
                DateOpen = model.DateOpen,
                ShopManufactures = model.ShopManufactures
            };
        }

        public void Update(ShopBindingModel? model)
        {
            if(model == null)
            {
                return;
            }

            ShopName = model.ShopName;
            Address = model.Address;
            DateOpen = model.DateOpen;
            ShopManufactures = model.ShopManufactures;
        }

        public ShopViewModel GetViewModel => new()
        {
            Id = Id,
            ShopName = ShopName,
            Address = Address,
            DateOpen = DateOpen,
            ShopManufactures = ShopManufactures
        };
    }
}
