using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.BusinessLogicsContracts;
using BlacksmithWorkshopContracts.SearchModels;
using BlacksmithWorkshopContracts.ViewModels;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Mvc;

namespace BlacksmithWorkshopRestApi.Controllers
{
    /// <summary>
    /// в этом контроллере логика по заказам и изделиям
    /// </summary>
    
    //настройка у контроллера, так как снова используем несколько Post и Get запросов
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : Controller
    {
        private readonly ILogger _logger;

        private readonly IOrderLogic _order;

        private readonly IManufactureLogic _manufacture;

        public MainController(ILogger<MainController> logger, IOrderLogic order, IManufactureLogic manufacture)
        {
            _logger = logger;
            _order = order;
            _manufacture = manufacture;
        }

        [HttpGet]
        public List<ManufactureViewModel>? GetManufactureList()
        {
            try
            {
                return _manufacture.ReadList(null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка получения списка изделий");
                throw;
            }
        }

        [HttpGet]
        public ManufactureViewModel? GetManufacture(int manufactureId)
        {
            try
            {
                return _manufacture.ReadElement(new ManufactureSearchModel
                {
                    Id = manufactureId
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка получения изделия по id={Id}", manufactureId);
                throw;
            }
        }

        [HttpGet]
        public List<OrderViewModel>? GetOrders(int clientId)
        {
            try
            {
                return _order.ReadList(new OrderSearchModel
                {
                    ClientId = clientId
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка получения списка заказов клиента id ={ Id}", clientId);
                throw;
            }
        }

        [HttpPost]
        public void CreateOrder(OrderBindingModel model)
        {
            try
            {
                _order.CreateOrder(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка создания заказа");
                throw;
            }
        }
    }
}
