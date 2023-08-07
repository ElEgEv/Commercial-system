using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.ViewModels;
using BlacksmithWorkshopDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopDatabaseImplement.Models
{
    [DataContract]
    public class Implementer : IImplementerModel
	{
        [DataMember]
        public int Id { get; set; }

		[Required]
        [DataMember]
        public string ImplementerFIO { get; set; } = string.Empty;

		[Required]
        [DataMember]
        public string Password { get; set; } = string.Empty;

		[Required]
        [DataMember]
        public int WorkExperience { get; set; }

		[Required]
        [DataMember]
        public int Qualification { get; set; }

		//для реализации связи один ко многим с заказами
		[ForeignKey("ImplementerId")]
		public virtual List<Order> Orders { get; set; } = new();

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

		public static Implementer Create(ImplementerViewModel model)
		{
			return new Implementer
			{
				Id = model.Id,
				Password = model.Password,
				ImplementerFIO = model.ImplementerFIO,
				Qualification = model.Qualification,
				WorkExperience = model.WorkExperience
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
	}
}
