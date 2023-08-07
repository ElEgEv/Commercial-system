using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopContracts.SearchModels
{
	public class ImplementerSearchModel
	{
		public int? Id { get; set; }

		public string? ImplementerFIO { get; set; }

		public string? Password { get; set; }

		public int? WorkExperience { get; set; }

		public int? Qualification { get; set; }
	}
}
