using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.SearchModels;
using BlacksmithWorkshopContracts.StoragesContracts;
using BlacksmithWorkshopContracts.ViewModels;
using BlacksmithWorkshopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopFileImplement.Implements
{
    //реализация интерфейса хранилища изделий
    public class ManufactureStorage : IManufactureStorage
    {
        private readonly DataFileSingleton source;

        public ManufactureStorage()
        {
            source = DataFileSingleton.GetInstance();
        }

        public List<ManufactureViewModel> GetFullList()
        {
            return source.Manufactures.Select(x => x.GetViewModel).ToList();
        }

        public List<ManufactureViewModel> GetFilteredList(ManufactureSearchModel model)
        {
            if (string.IsNullOrEmpty(model.ManufactureName))
            {
                return new();
            }

            return source.Manufactures.Where(x => x.ManufactureName.Contains(model.ManufactureName)).Select(x => x.GetViewModel).ToList();
        }

        public ManufactureViewModel? GetElement(ManufactureSearchModel model)
        {
            if (string.IsNullOrEmpty(model.ManufactureName) && !model.Id.HasValue)
            {
                return null;
            }

            return source.Manufactures.FirstOrDefault(x => (!string.IsNullOrEmpty(model.ManufactureName) && x.ManufactureName == model.ManufactureName)
                || (model.Id.HasValue && x.Id == model.Id))?.GetViewModel;
        }

        public ManufactureViewModel? Insert(ManufactureBindingModel model)
        {
            model.Id = source.Manufactures.Count > 0 ? source.Manufactures.Max(x => x.Id) + 1 : 1;

            var newManufacture = Manufacture.Create(model);

            if (newManufacture == null)
            {
                return null;
            }

            source.Manufactures.Add(newManufacture);
            source.SaveManufactures();

            return newManufacture.GetViewModel;
        }

        public ManufactureViewModel? Update(ManufactureBindingModel model)
        {
            var manufacture = source.Manufactures.FirstOrDefault(x => x.Id == model.Id);

            if (manufacture == null)
            {
                return null;
            }

            manufacture.Update(model);
            source.SaveManufactures();

            return manufacture.GetViewModel;
        }

        public ManufactureViewModel? Delete(ManufactureBindingModel model)
        {
            var element = source.Manufactures.FirstOrDefault(x => x.Id == model.Id);

            if (element != null)
            {
                source.Manufactures.Remove(element);
                source.SaveManufactures();

                return element.GetViewModel;
            }

            return null;
        }
    }
}
