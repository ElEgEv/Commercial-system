using BlacksmithWorkshopContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopBusinessLogic.OfficePackage.HelperModels
{
    //информация по excel файлу, который хотим создать
    public class ExcelInfo
    {
        //название файла
        public string FileName { get; set; } = string.Empty; 

        //заголовок
        public string Title { get; set; } = string.Empty;

		public List<ReportManufactureWorkPieceViewModel> ManufactureWorkPieces
		{
			get;
			set;
		} = new();

		public List<ReportShopManufacturesViewModel> ShopManufactures
		{
			get;
			set;
		} = new();
    }
}
