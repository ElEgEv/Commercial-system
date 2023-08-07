using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.BusinessLogicsContracts;
using BlacksmithWorkshopContracts.SearchModels;
using BlacksmithWorkshopContracts.StoragesContracts;
using BlacksmithWorkshopContracts.ViewModels;
using BlacksmithWorkshopDataModels.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopBusinessLogic.BusinessLogic
{
    public class ShopLogic : IShopLogic
    {
        private readonly ILogger _logger;
        private readonly IShopStorage _shopStorage;

        public ShopLogic(ILogger<ShopLogic> logger, IShopStorage shopStorage)
        {
            _logger = logger;
            _shopStorage = shopStorage;
        }

        public ShopViewModel? ReadElement(ShopSearchModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            _logger.LogInformation("ReadElement. ShopName:{ShopName}. Id:{Id}", model.ShopName, model.Id);
            var element = _shopStorage.GetElement(model);

            if (element == null)
            {
                _logger.LogWarning("ReadElement element not found");

                return null;
            }

            _logger.LogInformation("ReadElement find. Id:{Id}", element.Id);

            return element;
        }

        public List<ShopViewModel>? ReadList(ShopSearchModel? model)
        {
            _logger.LogInformation("ReadList. ShopName:{ShopName}. Id: {Id}", model?.ShopName, model?.Id);

            var list = model == null ? _shopStorage.GetFullList() : _shopStorage.GetFilteredList(model);
            
            if (list == null)
            {
                _logger.LogWarning("ReadList return null list");

                return null;
            }

            _logger.LogInformation("ReadList. Count:{Count}", list.Count);

            return list;
        }

        public bool AddManufacture(ShopSearchModel model, IManufactureModel manufacture, int count)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (count <= 0)
            {
                throw new ArgumentNullException("Количество добавляемых изделий должно быть больше 0", nameof(count));
            }

            _logger.LogInformation("AddManufacture. ShopName:{ShopName}. Id: {Id}", model?.ShopName, model?.Id);

            var shop = _shopStorage.GetElement(model);

            if (shop == null)
            {
                _logger.LogWarning("Add Manufacture operation failed");

                return false;
            }

            if (shop.MaxCountManufactures - shop.ShopManufactures.Select(x => x.Value.Item2).Sum() < count)
            {
                throw new ArgumentNullException("Слишком много изделий для одного магазина", nameof(count));
            }

            if (!shop.ShopManufactures.ContainsKey(manufacture.Id))
            {
                shop.ShopManufactures[manufacture.Id] = (manufacture, count);
            }
            else
            {
                shop.ShopManufactures[manufacture.Id] = (manufacture, shop.ShopManufactures[manufacture.Id].Item2 + count);
            }

            _shopStorage.Update(new ShopBindingModel()
            {
                Id = shop.Id,
                ShopName = shop.ShopName,
                Address = shop.Address,
                DateOpen = shop.DateOpen,
                MaxCountManufactures = shop.MaxCountManufactures,
                ShopManufactures = shop.ShopManufactures
            });

            return true;
        }

        public bool Create(ShopBindingModel model)
        {
            CheckModel(model);

            if (_shopStorage.Insert(model) == null)
            {
                _logger.LogWarning("Insert operation failed");

                return false;
            }

            return true;
        }

        public bool Update(ShopBindingModel model)
        {
            CheckModel(model);

            if (_shopStorage.Update(model) == null)
            {
                _logger.LogWarning("Update operation failed");

                return false;
            }

            return true;
        }

        public bool Delete(ShopBindingModel model)
        {
            CheckModel(model, false);
            _logger.LogInformation("Delete. Id:{Id}", model.Id);

            if (_shopStorage.Delete(model) == null)
            {
                _logger.LogWarning("Delete operation failed");

                return false;
            }

            return true;
        }

        private void CheckModel(ShopBindingModel model, bool withParams = true)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (!withParams)
            {
                return;
            }

            if (string.IsNullOrEmpty(model.ShopName))
            {
                throw new ArgumentNullException("Отсутствует названия магазина", nameof(model.ShopName));
            }

            if (string.IsNullOrEmpty(model.Address))
            {
                throw new ArgumentNullException("Отсутствует адреса магазина", nameof(model.Address));
            }

            _logger.LogInformation("Shop. ShopName:{ShopName}. Address:{Address}. Id: {Id}", model.ShopName, model.Address, model.Id);
            var element = _shopStorage.GetElement(new ShopSearchModel
            {
                ShopName = model.ShopName
            });

            if (element != null && element.Id != model.Id)
            {
                throw new InvalidOperationException("Магазин с таким названием уже есть");
            }
        }

        public bool AddManufactures(IManufactureModel model, int count)
        {
            if (count <= 0)
            {
                throw new ArgumentNullException("Количество добавляемых изделий должно быть больше 0", nameof(count));
            }

            _logger.LogInformation("AddManufactures. Manufacture: {Manufacture}. Count: {Count}", model?.ManufactureName, count);

            var capacity = _shopStorage.GetFullList().Select(x => x.MaxCountManufactures - x.ShopManufactures.Select(x => x.Value.Item2).Sum()).Sum() - count;
            
            if (capacity < 0)
            {
                _logger.LogWarning("AddManufactures operation failed. Sell {count} Manufactures ", -capacity);
                return false;
            }

            foreach (var shop in _shopStorage.GetFullList())
            {
                if (shop.MaxCountManufactures - shop.ShopManufactures.Select(x => x.Value.Item2).Sum() < count)
                {
                    if (!AddManufacture(new() { Id = shop.Id }, model, shop.MaxCountManufactures - shop.ShopManufactures.Select(x => x.Value.Item2).Sum()))
                    {
                        _logger.LogWarning("AddIceCreams operation failed.");
                        return false;
                    }
                    count -= shop.MaxCountManufactures - shop.ShopManufactures.Select(x => x.Value.Item2).Sum();
                }
                else
                {
                    if (!AddManufacture(new() { Id = shop.Id }, model, count))
                    {
                        _logger.LogWarning("AddIceCreams operation failed.");
                        return false;
                    }
                    count -= count;
                }
                if (count == 0)
                {
                    return true;
                }
            }

            return true;
        }

        public bool SellManufatures(IManufactureModel model, int count)
        {
            return _shopStorage.SellManufactures(model, count);
        }
    }
}
