using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.BusinessLogicsContracts;
using BlacksmithWorkshopContracts.SearchModels;
using BlacksmithWorkshopContracts.StoragesContracts;
using BlacksmithWorkshopContracts.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopBusinessLogic.BusinessLogic
{
    public class ManufactureLogic : IManufactureLogic
    {
        private readonly ILogger _logger;

        private readonly IManufactureStorage _manufactureStorage;

        //конструктор
        public ManufactureLogic(ILogger<ManufactureLogic> logger, IManufactureStorage manufactureStorage)
        {
            _logger = logger;
            _manufactureStorage = manufactureStorage;
        }

        //вывод отфильтрованного списка
        public List<ManufactureViewModel>? ReadList(ManufactureSearchModel? model)
        {
            _logger.LogInformation("ReadList. ManufactureName:{ManufactureName}. Id:{Id}", model?.ManufactureName, model?.Id);

            //list хранит весь список в случае, если model пришло со значением null на вход метода
            var list = model == null ? _manufactureStorage.GetFullList() : _manufactureStorage.GetFilteredList(model);

            if(list == null)
            {
                _logger.LogWarning("ReadList return null list");

                return null;
            }

            _logger.LogInformation("ReadList. Count:{Count}", list.Count);

            return list;
        }

        //вывод конкретного изделия
        public ManufactureViewModel? ReadElement(ManufactureSearchModel model)
        {
            if(model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            _logger.LogInformation("ReadElement. ManufactureName:{ManufactureName}. Id:{Id}", model.ManufactureName, model.Id);

            var element = _manufactureStorage.GetElement(model);

            if(element == null)
            {
                _logger.LogWarning("ReadElement element not found");

                return null;
            }

            _logger.LogInformation("ReadElement find. Id:{Id}", model.Id);

            return element;
        }

        //Создание изделия
        public bool Create(ManufactureBindingModel model)
        {
            CheckModel(model);

            if(_manufactureStorage.Insert(model) == null)
            {
                _logger.LogWarning("Create operation failed");

                return false;
            }

            return true;
        }

        //обновление изделия
        public bool Update(ManufactureBindingModel model)
        {
            CheckModel(model);

            if(_manufactureStorage.Update(model) == null)
            {
                _logger.LogWarning("Update operation failed");
                return false;
            }

            return true;
        }

        //удаление изделия
        public bool Delete(ManufactureBindingModel model)
        {
            CheckModel(model, false);

            _logger.LogInformation("Delete. Id:{Id}", model.Id);

            if(_manufactureStorage.Delete(model) == null)
            {
                _logger.LogWarning("Delete operation failed");

                return false;
            }

            return true;
        }

        //проверка входного аргумента для методов Insert, Update и Delete
        private void CheckModel(ManufactureBindingModel model, bool withParams = true)
        {
            if(model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            //так как при удалении параметром withParams передаём false
            if (!withParams)
            {
                return;
            }

            //проверка на наличие названия изделия
            if (string.IsNullOrEmpty(model.ManufactureName))
            {
                throw new ArgumentNullException("Нет названия изделия", nameof(model.ManufactureName));
            }

            //проверка на наличие нормальной цены у изделия
            if(model.Price <= 0)
            {
                throw new ArgumentNullException("Цена изделия должна быть больше 0", nameof(model.Price));
            }

            _logger.LogInformation("Manufacture. ManufactureName:{ManufactureName}. Price:{Price}. Id:{Id}", 
                model.ManufactureName, model.Price, model.Id);

            //проверка на наличие такого же изделия в списке
            var element = _manufactureStorage.GetElement(new ManufactureSearchModel
            {
                ManufactureName = model.ManufactureName,
            });

            //если элемент найден и его Id не совпадает с Id объекта, переданного на вход
            if(element != null && element.Id != model.Id)
            {
                throw new InvalidOperationException("Изделие с таким названием уже есть");
            }
        }
    }
}
