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
	public class ImplementerLogic : IImplementerLogic
	{
		private readonly ILogger _logger;

		private readonly IImplementerStorage _implementerStorage;

		public ImplementerLogic(ILogger<ImplementerLogic> logger, IImplementerStorage implementerStorage)
		{
			_logger = logger;
			_implementerStorage = implementerStorage;
		}

		public List<ImplementerViewModel>? ReadList(ImplementerSearchModel? model)
		{
			_logger.LogInformation("ReadList. ImplementerFIO:{ImplementerFIO}. Id:{Id}", model?.ImplementerFIO, model?.Id);

			//list хранит весь список в случае, если model пришло со значением null на вход метода
			var list = model == null ? _implementerStorage.GetFullList() : _implementerStorage.GetFilteredList(model);

			if (list == null)
			{
				_logger.LogWarning("ReadList return null list");
				return null;
			}

			_logger.LogInformation("ReadList. Count:{Count}", list.Count);

			return list;
		}

		public ImplementerViewModel? ReadElement(ImplementerSearchModel model)
		{
			if (model == null)
			{
				throw new ArgumentNullException(nameof(model));
			}

			_logger.LogInformation("ReadList. ImplementerFIO:{ImplementerFIO}. Id:{Id}", model.ImplementerFIO, model?.Id);

			var element = _implementerStorage.GetElement(model);

			if (element == null)
			{
				_logger.LogWarning("ReadElement element not found");

				return null;
			}

			_logger.LogInformation("ReadElement find. Id:{Id}", element.Id);

			return element;
		}

		public bool Create(ImplementerBindingModel model)
		{
			CheckModel(model);

			if (_implementerStorage.Insert(model) == null)
			{
				_logger.LogWarning("Insert operation failed");

				return false;
			}

			return true;
		}

		public bool Update(ImplementerBindingModel model)
		{
			CheckModel(model);

			if (_implementerStorage.Update(model) == null)
			{
				_logger.LogWarning("Update operation failed");

				return false;
			}

			return true;
		}

		public bool Delete(ImplementerBindingModel model)
		{
			CheckModel(model, false);

			_logger.LogInformation("Delete. Id:{Id}", model.Id);

			if (_implementerStorage.Delete(model) == null)
			{
				_logger.LogWarning("Delete operation failed");

				return false;
			}

			return true;
		}

		//проверка входного аргумента для методов Insert, Update и Delete
		private void CheckModel(ImplementerBindingModel model, bool withParams = true)
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
			if (string.IsNullOrEmpty(model.ImplementerFIO))
			{
				throw new ArgumentNullException("Отсутствие ФИО в учётной записи", nameof(model.ImplementerFIO));
			}

			//проверка на наличие пароля
			if (string.IsNullOrEmpty(model.Password))
			{
				throw new ArgumentNullException("Отсутствие пароля в учётной записи", nameof(model.Password));
			}

			//проверка на наличие квалификации
			if (model.Qualification <= 0)
			{
				throw new ArgumentNullException("Указана некорректная квалификация", nameof(model.Qualification));
			}

			//проверка на наличие квалификации
			if (model.WorkExperience < 0)
			{
				throw new ArgumentNullException("Указан некоректный стаж работы", nameof(model.WorkExperience));
			}

			_logger.LogInformation("Implementer. ImplementerFIO:{ImplementerFIO}. Password:{Password}. " +
				"Qualification:{Qualification}. WorkExperience:{ WorkExperience}. Id:{Id}",
				model.ImplementerFIO, model.Password, model.Qualification, model.WorkExperience, model.Id);

			//для проверка на наличие такого же аккаунта
			var element = _implementerStorage.GetElement(new ImplementerSearchModel
			{
				ImplementerFIO = model.ImplementerFIO,
			});

			//если элемент найден и его Id не совпадает с Id переданного объекта
			if (element != null && element.Id != model.Id)
			{
				throw new InvalidOperationException("Исполнитель с таким именем уже есть");
			}
		}
	}
}
