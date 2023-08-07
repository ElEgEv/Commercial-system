using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.ViewModels;
using BlacksmithWorkshopDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlacksmithWorkshopFileImplement.Models
{
	[DataContract]
	public class Implementer : IImplementerModel
	{
        [DataMember]
        public int Id { get; private set; }

        [DataMember]
        public string ImplementerFIO { get; private set; } = string.Empty;

        [DataMember]
        public string Password { get; private set; } = string.Empty;

        [DataMember]
        public int WorkExperience { get; private set; }

        [DataMember]
        public int Qualification { get; private set; }

		public static Implementer? Create(ImplementerBindingModel model)
		{
			if (model == null)
			{
				return null;
			}

			return new Implementer()
			{
				Id = model.Id,
				Password = model.Password,
				ImplementerFIO = model.ImplementerFIO,
				Qualification = model.Qualification,
				WorkExperience = model.WorkExperience
			};
		}

		public static Implementer? Create(XElement element)
		{
			if (element == null)
			{
				return null;
			}

			return new Implementer()
			{
				Id = Convert.ToInt32(element.Attribute("Id")!.Value),
				Password = element.Element("Password")!.Value,
				ImplementerFIO = element.Element("ImplementerFIO")!.Value,
				Qualification = Convert.ToInt32(element.Element("Qualification")!.Value),
				WorkExperience = Convert.ToInt32(element.Element("WorkExperience")!.Value)
			};
		}

		public void Update(ImplementerBindingModel model)
		{
			if (model == null)
			{
				return;
			}

			Id = model.Id;
			Password = model.Password;
			ImplementerFIO = model.ImplementerFIO;
			Qualification = model.Qualification;
			WorkExperience = model.WorkExperience;
		}

		public ImplementerViewModel GetViewModel => new()
		{
			Id = Id,
			Password = Password,
			ImplementerFIO = ImplementerFIO,
			Qualification = Qualification,
			WorkExperience = WorkExperience
		};

		public XElement GetXElement => new("Order",
			new XAttribute("Id", Id),
			new XElement("Password", Password),
			new XElement("ImplementerFIO", ImplementerFIO),
			new XElement("Qualification", Qualification),
			new XElement("WorkExperience", WorkExperience));
	}
}
