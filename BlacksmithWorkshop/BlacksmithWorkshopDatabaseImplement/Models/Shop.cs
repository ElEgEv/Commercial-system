using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.ViewModels;
using BlacksmithWorkshopDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopDatabaseImplement.Models
{
    public class Shop : IShopModel
    {
        public int Id { get; set; }

        [Required]
        public string ShopName { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        [Required]
        public DateTime DateOpen { get; set; }

        [Required]
        public int MaxCountManufactures { get; set; }

        private Dictionary<int, (IManufactureModel, int)>? _shopManufactures = null;

        [Required]
        public Dictionary<int, (IManufactureModel, int)> ShopManufactures
        {
            get
            {
                if (_shopManufactures == null)
                {
                    _shopManufactures = new();

                    Manufactures.ForEach(x =>
                    {
                        if (_shopManufactures.ContainsKey(x.ManufactureId))
                        {
                            _shopManufactures[x.ManufactureId] = (x.Manufacture as IManufactureModel, _shopManufactures[x.ManufactureId].Item2 + x.Count);
                        }
                        else
                        {
                            _shopManufactures[x.ManufactureId] = (x.Manufacture as IManufactureModel, x.Count);
                        }
                    });
                }

                return _shopManufactures;
            }
        }

        [ForeignKey("ShopId")]
        public virtual List<ShopManufacture> Manufactures { get; set; } = new();

        public static Shop? Create(BlacksmithWorkshopDatabase context, ShopBindingModel model)
        {
            return new Shop()
            {
                Id = model.Id,
                ShopName = model.ShopName,
                Address = model.Address,
                DateOpen = model.DateOpen,
                Manufactures = model.ShopManufactures.Select(x => new ShopManufacture
                {
                    Manufacture = context.Manufactures.First(y => y.Id == x.Key),
                    Count = x.Value.Item2
                }).ToList(),
                MaxCountManufactures = model.MaxCountManufactures
            };
        }

        public void Update(ShopBindingModel model)
        {
            ShopName = model.ShopName;
            Address = model.Address;
            DateOpen = model.DateOpen;
            MaxCountManufactures = model.MaxCountManufactures;
        }

        public ShopViewModel GetViewModel => new()
        {
            Id = Id,
            ShopName = ShopName,
            Address = Address,
            DateOpen = DateOpen,
            MaxCountManufactures = MaxCountManufactures,
            ShopManufactures = ShopManufactures,
            ShopManufactureList = Manufactures.Select(x => new Tuple<ManufactureViewModel, int>(x.Manufacture.GetViewModel, x.Count)).ToList()
        };

        public void UpdateManufactures(BlacksmithWorkshopDatabase context, ShopBindingModel model)
        {
            var shopManufactures = context.ShopManufactures.Where(rec => rec.ShopId == model.Id).ToList();

            if (shopManufactures != null && shopManufactures.Count > 0)
            {   // удалили те, которых нет в модели
                context.ShopManufactures.RemoveRange(shopManufactures.Where(rec => !model.ShopManufactures.ContainsKey(rec.ManufactureId)));
                context.SaveChanges();

                // обновили количество у существующих записей
                foreach (var _shopManufactures in shopManufactures)
                {
                    _shopManufactures.Count = model.ShopManufactures[_shopManufactures.ManufactureId].Item2;
                    model.ShopManufactures.Remove(_shopManufactures.ManufactureId);
                }

                context.SaveChanges();
            }

            var shop = context.Shops.First(x => x.Id == Id);

            foreach (var sm in model.ShopManufactures)
            {
                context.ShopManufactures.Add(new ShopManufacture
                {
                    Shop = shop,
                    Manufacture = context.Manufactures.First(x => x.Id == sm.Key),
                    Count = sm.Value.Item2
                });

                context.SaveChanges();
            }

            _shopManufactures = null;
        }
    }
}
