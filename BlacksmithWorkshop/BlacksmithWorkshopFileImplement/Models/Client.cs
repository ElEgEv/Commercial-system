using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.ViewModels;
using BlacksmithWorkshopDataModels.Enums;
using BlacksmithWorkshopDataModels.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlacksmithWorkshopFileImplement.Models
{
	[DataContract]
	public class Client : IClientModel
	{
		[DataMember]
		public int Id { get; private set; }

        [DataMember]
        public string ClientFIO { get; private set; } = string.Empty;

        [DataMember]
        public string Email { get; private set; } = string.Empty;

        [DataMember]
        public string Password { get; private set; } = string.Empty;

		public static Client? Create(ClientBindingModel model)
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

		public static Client? Create(XElement element)
		{
			if (element == null)
			{
				return null;
			}

			return new Client()
			{
				Id = Convert.ToInt32(element.Attribute("Id")!.Value),
				ClientFIO = element.Element("ClientFIO")!.Value,
				Email = element.Element("Email")!.Value,
				Password = element.Element("Password")!.Value
			};
		}

		public void Update(ClientBindingModel model)
		{
			if (model == null)
			{
				return;
			}

			ClientFIO = model.ClientFIO;
			Email = model.Email;
			Password = model.Password;
		}

		public ClientViewModel GetViewModel => new()
		{
			Id = Id,
			ClientFIO = ClientFIO,
			Email = Email,
			Password = Password
		};

		public XElement GetXElement => new("Order",
			new XAttribute("Id", Id),
			new XElement("ClientFIO", ClientFIO),
			new XElement("Email", Email),
			new XElement("Password", Password));
	}
}
