using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.BusinessLogicsContracts;
using BlacksmithWorkshopContracts.SearchModels;
using BlacksmithWorkshopContracts.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BlacksmithWorkshopRestApi.Controllers
{
	//настройка у контроллера, так как снова используем несколько Post и Get запросов
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class ShopController : Controller
	{
		private readonly ILogger _logger;

		private readonly IShopLogic _logic;

		public ShopController(IShopLogic logic, ILogger<ShopController> logger)
		{
			_logger = logger;
			_logic = logic;
		}

		[HttpGet]
		public List<ShopViewModel>? GetShopList()
		{
			try
			{
				return _logic.ReadList(null);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка получения списка магазинов");
				throw;
			}
		}

		[HttpGet]
		public ShopViewModel? GetShop(int shopId)
		{
			try
			{
				return _logic.ReadElement(new ShopSearchModel { Id = shopId });
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка получения магазина по id={Id}", shopId);
				throw;
			}
		}

		[HttpPost]
		public void CreateShop(ShopBindingModel model)
		{
			try
			{
				//создание магазина
				_logic.Create(model);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка создания магазина");
				throw;
			}
		}

		[HttpPost]
		public void UpdateShop(ShopBindingModel model)
		{
			try
			{
				//изменение магазина
				_logic.Update(model);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка обновления данных магазина");
				throw;
			}
		}

		[HttpPost]
		public void DeleteShop(ShopBindingModel model)
		{
			try
			{
				_logic.Delete(model);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка удаления магазина");
				throw;
			}
		}

		[HttpPost]
		public void AddManufacture(Tuple<ShopSearchModel, ManufactureBindingModel, int> model)
		{
			try
			{
				_logic.AddManufacture(model.Item1, model.Item2, model.Item3);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка добавления изделия в магазин");
				throw;
			}
		}
	}
}
