using BlacksmithWorkshopContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopBusinessLogic.OfficePackage.HelperModels
{
    //общая информация по pdf файлу
    public class PdfInfo
    {
        public string FileName { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        //перечень заказов за указанный период для вывода/сохранения
        public List<ReportOrdersViewModel> Orders { get; set; } = new();
		
		public List<ReportGroupedOrdersViewModel> GroupedOrders { get; set; } = new();
    }
}
