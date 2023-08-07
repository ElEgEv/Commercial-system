using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.ViewModels;
using BlacksmithWorkshopDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlacksmithWorkshopFileImplement.Models
{
    //класс реализующий интерфейс модели изделия
    [DataContract]
    public class Manufacture : IManufactureModel
    {
        [DataMember]
        public int Id { get; private set; }

        [DataMember]
        public string ManufactureName { get; private set; } = string.Empty;

        [DataMember]
        public double Price { get; private set; }

        public Dictionary<int, int> WorkPieces { get; private set; } = new();

        private Dictionary<int, (IWorkPieceModel, int)>? _manufactureWorkPieces = null;

        [DataMember]
        public Dictionary<int, (IWorkPieceModel, int)> ManufactureWorkPieces
        {
            get
            {
                if (_manufactureWorkPieces == null)
                {
                    var source = DataFileSingleton.GetInstance();

                    _manufactureWorkPieces = WorkPieces.ToDictionary(x => x.Key, 
                        y => ((source.WorkPieces.FirstOrDefault(z => z.Id == y.Key) as IWorkPieceModel)!, y.Value));
                }

                return _manufactureWorkPieces;
            }
        }

        public static Manufacture? Create(ManufactureBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            return new Manufacture()
            {
                Id = model.Id,
                ManufactureName = model.ManufactureName,
                Price = model.Price,
                WorkPieces = model.ManufactureWorkPieces.ToDictionary(x => x.Key, x => x.Value.Item2)
            };
        }

        public static Manufacture? Create(XElement element)
        {
            if (element == null)
            {
                return null;
            }

            return new Manufacture()
            {
                Id = Convert.ToInt32(element.Attribute("Id")!.Value),
                ManufactureName = element.Element("ManufactureName")!.Value,
                Price = Convert.ToDouble(element.Element("Price")!.Value),
                WorkPieces = element.Element("ManufactureWorkPieces")!.Elements("ManufactureWorkPieces").ToDictionary(
                    x => Convert.ToInt32(x.Element("Key")?.Value), 
                    x => Convert.ToInt32(x.Element("Value")?.Value))
            };
        }

        public void Update(ManufactureBindingModel model)
        {
            if (model == null)
            {
                return;
            }

            ManufactureName = model.ManufactureName;
            Price = model.Price;
            WorkPieces = model.ManufactureWorkPieces.ToDictionary(x => x.Key, x => x.Value.Item2);
            _manufactureWorkPieces = null;
        }

        public ManufactureViewModel GetViewModel => new()
        {
            Id = Id,
            ManufactureName = ManufactureName,
            Price = Price,
            ManufactureWorkPieces = ManufactureWorkPieces
        };

        public XElement GetXElement => new("Manufacture", 
            new XAttribute("Id", Id), 
            new XElement("ManufactureName", ManufactureName), 
            new XElement("Price", Price.ToString()), 
            new XElement("ManufactureWorkPieces", WorkPieces.Select(
                x => new XElement("ManufactureWorkPieces", 
                    new XElement("Key", x.Key), 
                    new XElement("Value", x.Value))
                ).ToArray()));
    }
}
