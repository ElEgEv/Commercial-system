using BlacksmithWorkshopContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopBusinessLogic.OfficePackage.HelperModels
{
    //общая информация по документу
    public class WordInfo
    {
        public string FileName { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        //список заготовок для вывода и сохранения
        public List<ManufactureViewModel> Manufactures { get; set; } = new();

		public List<ShopViewModel> Shops { get; set; } = new();
    }
}
