using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopContracts.BusinessLogicsContracts
{
    public interface IReportLogic
    {
		//Получение списка добавок с указанием, в каких мороженых используются
        List<ReportManufactureWorkPieceViewModel> GetManufactureWorkPiece();

		//Получение списка мороженых с указанием, в каких магазинах в наличии
		List<ReportShopManufacturesViewModel> GetShopManufactures();

        //Получение списка заказов за определенный период
        List<ReportOrdersViewModel> GetOrders(ReportBindingModel model);

		//Получение списка заказов за весь период
		List<ReportGroupedOrdersViewModel> GetGroupedOrders();

		//Сохранение добавок в файл-Word
        void SaveManufacturesToWordFile(ReportBindingModel model);

		//Сохранение магазинов в виде таблицы в файл-Word
		void SaveShopsToWordFile(ReportBindingModel model);

		//Сохранение добавок с указаеним мороженых в файл-Excel
        void SaveManufactureWorkPieceToExcelFile(ReportBindingModel model);

		//Сохранение магазинов с указанием мороженых в файл-Excel
		void SaveShopManufacturesToExcelFile(ReportBindingModel model);

        //Сохранение заказов в файл-Pdf
        void SaveOrdersToPdfFile(ReportBindingModel model);

		//Сохранение заказов за весь период в файл-Pdf
		void SaveGroupedOrdersToPdfFile(ReportBindingModel model);
    }
}
