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
    //класс, реализующий интерфейс модели изделия
    public class Manufacture : IManufactureModel
    {
        //методы set делаем приватным, чтобы исключить неразрешённые манипуляции
        public int Id { get; private set; }

        public string ManufactureName { get; private set; } = string.Empty;

        public double Price { get; private set; }

        public Dictionary<int, (IWorkPieceModel, int)> ManufactureWorkPieces { get; private set; } = new Dictionary<int, (IWorkPieceModel, int)>();

        //метод для создания объекта от класса-компонента на основе класса-BindingModel
        public static Manufacture? Create(ManufactureBindingModel? model)
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
                ManufactureWorkPieces = model.ManufactureWorkPieces
            };
        }

        //метод изменения существующего объекта
        public void Update(ManufactureBindingModel? model)
        {
            if (model == null)
            {
                return;
            }

            ManufactureName = model.ManufactureName;
            Price = model.Price;
            ManufactureWorkPieces = model.ManufactureWorkPieces;
        }

        //метод для создания объекта класса ViewModel на основе данных объекта класса-компонента
        public ManufactureViewModel GetViewModel => new()
        {
            Id = Id,
            ManufactureName = ManufactureName,
            Price = Price,
            ManufactureWorkPieces = ManufactureWorkPieces
        };
    }
}
