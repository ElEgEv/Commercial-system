using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.SearchModels;
using BlacksmithWorkshopContracts.ViewModels;
using BlacksmithWorkshopShopApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlacksmithWorkshopShopApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			if (!APIClient.InSystem)
			{
				return Redirect("~/Home/Enter");
			}
			return View(APIClient.GetRequest<List<ShopViewModel>>($"api/shop/getshoplist"));
		}

		public IActionResult Privacy()
		{
			if (!APIClient.InSystem)
			{
				return Redirect("~/Home/Enter");
			}
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		[HttpGet]
		public IActionResult Enter()
		{
			return View();
		}

		[HttpPost]
		public void Enter(string password)
		{
			if (string.IsNullOrEmpty(password))
			{
				throw new Exception("Введите пароль");
			}

			APIClient.InSystem = APIClient.Password == password;

			if (!APIClient.InSystem)
			{
				throw new Exception("Неверный пароль");
			}

			Response.Redirect("Index");
		}

		[HttpGet]
		public IActionResult Create()
		{
			if (!APIClient.InSystem)
			{
				throw new Exception("Вход только для авторизованных пользователей");
			}
			return View();
		}

		[HttpPost]
		public void Create(string name, string address, int count, DateTime date)
		{
			if (!APIClient.InSystem)
			{
				throw new Exception("Вход только для авторизованных пользователей");
			}

			if (string.IsNullOrEmpty(name))
			{
				throw new Exception("Отсутствует название магазина");
			}

			if (string.IsNullOrEmpty(address))
			{
				throw new Exception("Отсутствует адрес магазина");
			}

			if (date <= DateTime.MinValue)
			{
				throw new Exception("Ещё скажи, что ты с Петром 1 и Иваном Грозным знаком");
			}

			if (count <= 0)
			{
				throw new Exception("Вместимость магазина должна быть больше 0");
			}

			APIClient.PostRequest("api/shop/createshop", new ShopBindingModel
			{
				ShopName = name,
				MaxCountManufactures = count,
				Address = address,
				DateOpen = date
			});

			Response.Redirect("Index");
		}

		[HttpGet]
		public IActionResult Update()
		{
			if (!APIClient.InSystem)
			{
				throw new Exception("Вход только для авторизованных пользователей");
			}

			ViewBag.Shops = APIClient.GetRequest<List<ShopViewModel>>("api/shop/getshoplist");

			return View();
		}

		[HttpPost]
		public void Update(int shop, string name, string address, int count, DateTime date)
		{
			if (!APIClient.InSystem)
			{
				throw new Exception("Вход только для авторизованных пользователей");
			}

			if (shop <= 0)
			{
				throw new Exception("Некорректный идентификатор магазина");
			}

			if (string.IsNullOrEmpty(name))
			{
				throw new Exception("Отсутствует название магазина");
			}

			if (string.IsNullOrEmpty(address))
			{
				throw new Exception("Отсутствует адрес магазина");
			}

			if (date <= DateTime.MinValue)
			{
				throw new Exception("Ещё скажи, что ты с Петром 1 и Иваном Грозным знаком");
			}

			if (count <= 0)
			{
				throw new Exception("Вместимость магазина должна быть больше 0");
			}

			APIClient.PostRequest("api/shop/updateshop", new ShopBindingModel
			{
				Id = shop,
				ShopName = name,
				MaxCountManufactures = count,
				Address = address,
				DateOpen = date
			});

			Response.Redirect("Index");
		}

		[HttpGet]
		public IActionResult Delete()
		{
			if (!APIClient.InSystem)
			{
				throw new Exception("Вход только для авторизованных пользователей");
			}
			ViewBag.Shops = APIClient.GetRequest<List<ShopViewModel>>("api/shop/getshoplist");
			return View();
		}

		[HttpPost]
		public void Delete(int shop)
		{
			if (!APIClient.InSystem)
			{
				throw new Exception("Вход только для авторизованных пользователей");
			}

			if (shop <= 0)
			{
				throw new Exception("Некорректный идентификатор магазина");
			}

			APIClient.PostRequest("api/shop/deleteshop", new ShopBindingModel
			{
				Id = shop
			});

			Response.Redirect("Index");
		}

		[HttpGet]
		public IActionResult AddManufacture()
		{
			ViewBag.Shops = APIClient.GetRequest<List<ShopViewModel>>("api/shop/getshoplist");
			ViewBag.Manufactures = APIClient.GetRequest<List<ManufactureViewModel>>("api/main/getmanufacturelist");
			return View();
		}

		[HttpPost]
		public void AddManufacture(int shop, int manufacture, int count)
		{
			if (!APIClient.InSystem)
			{
				throw new Exception("Вход только для авторизованных пользователей");
			}

			if (shop <= 0)
			{
				throw new Exception("Некорректный идентификатор магазина");
			}

			if (manufacture <= 0)
			{
				throw new Exception("Некорректный идентификатор изделия");
			}

			if (count <= 0)
			{
				throw new Exception("Вместимость магазина должна быть больше 0");
			}

			APIClient.PostRequest("api/shop/addmanufacture", new Tuple<ShopSearchModel, ManufactureBindingModel, int>(new()
			{
				Id = shop
			}, new()
			{
				Id = manufacture
			}, count));
			Response.Redirect("Index");
		}

		[HttpPost]
		public Tuple<ShopViewModel, string, string> GetManufactures(int shop)
		{
			var shopViewModel = APIClient.GetRequest<ShopViewModel>($"api/shop/getshop?shopId={shop}");
			
			if (shopViewModel == null)
			{
				throw new Exception("Неизвестная ошибка");
			}

			string tbody = "<td>";

			// Самый адекватный вариант перевода даты, чтобы она отображалась в инпуте
			var correctDate = shopViewModel.DateOpen.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");
			
			shopViewModel.ShopManufactureList.ForEach(x =>
			{
				tbody += $"<tr><td>{x.Item1.ManufactureName}</td><td>{x.Item2}</td>";
			});

			tbody += "</td>";

			return new Tuple<ShopViewModel, string, string>(shopViewModel, tbody, correctDate);
		}
	}
}