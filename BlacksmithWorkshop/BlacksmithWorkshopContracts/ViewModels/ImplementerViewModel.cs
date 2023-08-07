using BlacksmithWorkshopContracts.Attributes;
using BlacksmithWorkshopDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopContracts.ViewModels
{
	public class ImplementerViewModel : IImplementerModel
	{
        [Column(visible: false)]
        public int Id { get; set; }

        [Column(title: "ФИО исполнителя", width: 150)]
		public string ImplementerFIO { get; set; } = string.Empty;

        [Column(title: "Пароль", width: 150)]
        public string Password { get; set; } = string.Empty;

        [Column(title: "Стаж", width: 150)]
        public int WorkExperience { get; set; }

        [Column(title: "Квалификация", width: 150)]
        public int Qualification { get; set; }
	}
}
