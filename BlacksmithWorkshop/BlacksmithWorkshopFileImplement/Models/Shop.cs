using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.ViewModels;
using BlacksmithWorkshopDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlacksmithWorkshopFileImplement.Models
{
    public class Shop : IShopModel
    {
        public int Id { get; set; }

        public string ShopName { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public DateTime DateOpen { get; set; }

        public int MaxCountManufactures { get; set; }

        public Dictionary<int, int> Manufactures { get; private set; } = new();

        public Dictionary<int, (IManufactureModel, int)> _manufactures = null;
    
        public Dictionary<int, (IManufactureModel, int)> ShopManufactures
        {
            get
            {
                if (_manufactures == null)
                {
                    var source = DataFileSingleton.GetInstance();
                    _manufactures = Manufactures.ToDictionary(x => x.Key, y => ((source.Manufactures.FirstOrDefault(z => z.Id == y.Key) as IManufactureModel)!, y.Value));
                }

                return _manufactures;
            }
        }

        public static Shop? Create(ShopBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return new Shop()
            {
                Id = model.Id,
                ShopName = model.ShopName,
                Address = model.Address,
                DateOpen = model.DateOpen,
                MaxCountManufactures = model.MaxCountManufactures,
                Manufactures = model.ShopManufactures.ToDictionary(x => x.Key, x => x.Value.Item2)
            };
        }

        public static Shop? Create(XElement element)

        {
            if (element == null)
            {
                return null;
            }
            return new Shop()
            {
                Id = Convert.ToInt32(element.Attribute("Id")!.Value),
                ShopName = element.Element("ShopName")!.Value,
                Address = element.Element("Address")!.Value,
                DateOpen = Convert.ToDateTime(element.Element("DateOpen")!.Value),
                MaxCountManufactures = Convert.ToInt32(element.Element("MaxCountManufactures")!.Value),
                Manufactures = element.Element("Manufactures")!.Elements("Manufactures").ToDictionary(x => Convert.ToInt32(x.Element("Key")?.Value), x => Convert.ToInt32(x.Element("Value")?.Value))
            };
        }

        public void Update(ShopBindingModel? model)
        {
            if (model == null)
            {
                return;
            }
            ShopName = model.ShopName;
            Address = model.Address;
            DateOpen = model.DateOpen;
            MaxCountManufactures = model.MaxCountManufactures;
            Manufactures = model.ShopManufactures.ToDictionary(x => x.Key, x => x.Value.Item2);
            _manufactures = null;
        }

        public ShopViewModel GetViewModel => new()
        {
            Id = Id,
            ShopName = ShopName,
            Address = Address,
            DateOpen = DateOpen,
            MaxCountManufactures = MaxCountManufactures,
            ShopManufactures = ShopManufactures
        };

        public XElement GetXElement => new("Shop",
            new XAttribute("Id", Id),
            new XElement("ShopName", ShopName),
            new XElement("Address", Address),
            new XElement("DateOpen", DateOpen.ToString()),
            new XElement("MaxCountManufactures", MaxCountManufactures.ToString()),
            new XElement("Manufactures", Manufactures.Select(x => new XElement("Manufactures",
                new XElement("Key", x.Key),
                new XElement("Value", x.Value))).ToArray()));
    }
}
