using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopContracts.ViewModels
{
	public class ReportShopManufacturesViewModel
	{
		public string ShopName { get; set; } = string.Empty;

		public int TotalCount { get; set; }

		public List<(string Manufacture, int Count)> Manufactures { get; set; } = new();
	}
}
