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
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BlacksmithWorkshopBusinessLogic.BusinessLogic
{
    public class ClientLogic : IClientLogic
    {
		private readonly ILogger _logger;

		private readonly IClientStorage _clientStorage;

		public ClientLogic(ILogger<ClientLogic> logger, IClientStorage clientStorage)
		{
			_logger = logger;
			_clientStorage = clientStorage;
		}

		public List<ClientViewModel>? ReadList(ClientSearchModel? model)
        {
			_logger.LogInformation("ReadList. ClientFIO:{ClientFIO}. Id:{Id}", model?.ClientFIO, model?.Id);

			//list хранит весь список в случае, если model пришло со значением null на вход метода
			var list = model == null ? _clientStorage.GetFullList() : _clientStorage.GetFilteredList(model);

			if (list == null)
			{
				_logger.LogWarning("ReadList return null list");
				return null;
			}

			_logger.LogInformation("ReadList. Count:{Count}", list.Count);

			return list;
		}

		public ClientViewModel? ReadElement(ClientSearchModel model)
		{
			if (model == null)
			{
				throw new ArgumentNullException(nameof(model));
			}

			_logger.LogInformation("ReadList. ClientFIO:{ClientFIO}. Id:{Id}", model.ClientFIO, model?.Id);

			var element = _clientStorage.GetElement(model);

			if (element == null)
			{
				_logger.LogWarning("ReadElement element not found");

				return null;
			}

			_logger.LogInformation("ReadElement find. Id:{Id}", element.Id);

			return element;
		}

		public bool Create(ClientBindingModel model)
		{
			CheckModel(model);

			if (_clientStorage.Insert(model) == null)
			{
				_logger.LogWarning("Insert operation failed");

				return false;
			}

			return true;
		}

		public bool Update(ClientBindingModel model)
		{
			CheckModel(model);

			if (_clientStorage.Update(model) == null)
			{
				_logger.LogWarning("Update operation failed");

				return false;
			}

			return true;
		}

		public bool Delete(ClientBindingModel model)
		{
			CheckModel(model, false);

			_logger.LogInformation("Delete. Id:{Id}", model.Id);

			if (_clientStorage.Delete(model) == null)
			{
				_logger.LogWarning("Delete operation failed");

				return false;
			}

			return true;
		}

		//проверка входного аргумента для методов Insert, Update и Delete
		private void CheckModel(ClientBindingModel model, bool withParams = true)
		{
			if (model == null)
			{
				throw new ArgumentNullException(nameof(model));
			}

			//так как при удалении передаём как параметр false
			if (!withParams)
			{
				return;
			}

			//проверка на наличие ФИО
			if (string.IsNullOrEmpty(model.ClientFIO))
			{
				throw new ArgumentNullException("Отсутствие ФИО в учётной записи", nameof(model.ClientFIO));
			}

			//проверка на наличие почты
			if (string.IsNullOrEmpty(model.Email))
			{
				throw new ArgumentNullException("Отсутствие почты в учётной записи (логина)", nameof(model.Email));
			}

			//проверка на наличие пароля
			if (string.IsNullOrEmpty(model.Password))
			{
				throw new ArgumentNullException("Отсутствие пароля в учётной записи", nameof(model.Password));
			}

			if (!Regex.IsMatch(model.Email, @"^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$", RegexOptions.IgnoreCase))
			{
				throw new ArgumentException("Некорректная почта", nameof(model.Email));
			}

			if (!Regex.IsMatch(model.Password, @"^((\w+\d+\W+)|(\w+\W+\d+)|(\d+\w+\W+)|(\d+\W+\w+)|(\W+\w+\d+)|(\W+\d+\w+))[\w\d\W]*$", RegexOptions.IgnoreCase) && model.Password.Length < 10 && model.Password.Length > 50)
			{
				throw new ArgumentException("Необходимо придумать другой пароль", nameof(model.Password));
			}

			_logger.LogInformation("Client. ClientFIO:{ClientFIO}. Email:{Email}. Password:{Password}. Id:{Id}",
				model.ClientFIO, model.Email, model.Password, model.Id);

			//для проверка на наличие такого же аккаунта
			var element = _clientStorage.GetElement(new ClientSearchModel
			{
				Email = model.Email,
			});

			//если элемент найден и его Id не совпадает с Id переданного объекта
			if (element != null && element.Id != model.Id)
			{
				throw new InvalidOperationException("Аккаунт с таким логином уже есть");
			}
		}
	}
}
