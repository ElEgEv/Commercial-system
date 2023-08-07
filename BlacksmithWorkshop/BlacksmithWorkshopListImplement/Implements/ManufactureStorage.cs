using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.SearchModels;
using BlacksmithWorkshopContracts.StoragesContracts;
using BlacksmithWorkshopContracts.ViewModels;
using BlacksmithWorkshopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopListImplement.Implements
{
    //класс, реализующий интерфейс хранилища изделий
    public class ManufactureStorage : IManufactureStorage
    {
        //поле для работы со списком изделий
        private readonly DataListSingleton _source;

        //получение в конструкторе объекта DataListSingleton
        public ManufactureStorage()
        {
            _source = DataListSingleton.GetInstance();
        }

        //получение полного списка изделий
        public List<ManufactureViewModel> GetFullList()
        {
            var result = new List<ManufactureViewModel>();

            foreach(var manufacture in _source.Manufactures)
            {
                result.Add(manufacture.GetViewModel);
            }

            return result;
        }

        //получение отфильтрованного списка изделий
        public List<ManufactureViewModel> GetFilteredList(ManufactureSearchModel model)
        {
            var result = new List<ManufactureViewModel>();

            if (string.IsNullOrEmpty(model.ManufactureName))
            {
                return result;
            }

            foreach(var manufacture in _source.Manufactures)
            {
                if(manufacture.ManufactureName.Contains(model.ManufactureName))
                {
                    result.Add(manufacture.GetViewModel);
                }
            }

            return result;
        }

        //получение элемента из списка изделий
        public ManufactureViewModel? GetElement(ManufactureSearchModel model)
        {
            if(string.IsNullOrEmpty(model.ManufactureName) && !model.Id.HasValue)
            {
                return null;
            }

            foreach(var manufacture in _source.Manufactures)
            {
                if((!string.IsNullOrEmpty(model.ManufactureName) && manufacture.ManufactureName == model.ManufactureName) ||
                    (model.Id.HasValue && manufacture.Id == model.Id))
                {
                    return manufacture.GetViewModel;
                }
            }

            return null;
        }

        //при создании изделия определяем для него новый id: ищем max id и прибавлляем к нему 1
        public ManufactureViewModel? Insert(ManufactureBindingModel model)
        {
            model.Id = 1;

            foreach(var manufacture in _source.Manufactures)
            {
                if(model.Id <= manufacture.Id)
                {
                    model.Id = manufacture.Id + 1;
                }
            }

            var newManufacture = Manufacture.Create(model);

            if(newManufacture == null)
            {
                return null;
            }

            _source.Manufactures.Add(newManufacture);

            return newManufacture.GetViewModel;
        }

        //обновление изделия
        public ManufactureViewModel? Update(ManufactureBindingModel model)
        {
            foreach (var manufacture in _source.Manufactures)
            {
                if (manufacture.Id == model.Id)
                {
                    manufacture.Update(model);

                    return manufacture.GetViewModel;
                }
            }

            return null;
        }

        //удаление изделия
        public ManufactureViewModel? Delete(ManufactureBindingModel model)
        {
            for(int i = 0; i < _source.Manufactures.Count; ++i)
            {
                if (_source.Manufactures[i].Id == model.Id)
                {
                    var element = _source.Manufactures[i];
                    _source.Manufactures.RemoveAt(i);

                    return element.GetViewModel;
                }
            }

            return null;
        }
    }
}
