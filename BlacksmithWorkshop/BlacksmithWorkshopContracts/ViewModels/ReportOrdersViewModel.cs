using BlacksmithWorkshopDataModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopContracts.ViewModels
{
    public class ReportOrdersViewModel
    {
        public int Id { get; set; }

        public DateTime DateCreate { get; set; }

        public string ManufactureName { get; set; } = string.Empty;

        public double Sum { get; set; }

        public string OrderStatus { get; set; }
    }
}
