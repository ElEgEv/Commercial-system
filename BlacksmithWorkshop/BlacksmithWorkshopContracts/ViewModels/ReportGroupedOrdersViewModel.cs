using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopContracts.ViewModels
{
	public class ReportGroupedOrdersViewModel
	{
		public DateTime DateCreate { get; set; }

		public int Count { get; set; }

		public double Sum { get; set; }
	}
}
