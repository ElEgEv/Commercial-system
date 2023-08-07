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
	public class Client : IClientModel
	{
		//методы set делаем приватным, чтобы исключить неразрешённые манипуляции
		public int Id { get; private set; }

		public string ClientFIO { get; private set; } = string.Empty;

		public string Email { get; private set; } = string.Empty;

		public string Password { get; private set; } = string.Empty;

		//метод для создания объекта от класса-компонента на основе класса-BindingModel
		public static Client? Create(ClientBindingModel? model)
		{
			if (model == null)
			{
				return null;
			}

			return new Client()
			{
				Id = model.Id,
				ClientFIO = model.ClientFIO,
				Email = model.Email,
				Password = model.Password
			};
		}

		//метод изменения существующего объекта
		public void Update(ClientBindingModel? model)
		{
			if (model == null)
			{
				return;
			}

			ClientFIO = model.ClientFIO;
			Email = model.Email;
			Password = model.Password;
		}

		//метод для создания объекта класса ViewModel на основе данных объекта класса-компонента
		public ClientViewModel GetViewModel => new()
		{
			Id = Id,
			ClientFIO = ClientFIO,
			Email = Email,
			Password = Password
		};
	}
}
