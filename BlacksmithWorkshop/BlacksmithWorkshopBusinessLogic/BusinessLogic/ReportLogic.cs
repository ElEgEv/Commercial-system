using BlacksmithWorkshopBusinessLogic.OfficePackage;
using BlacksmithWorkshopBusinessLogic.OfficePackage.HelperModels;
using BlacksmithWorkshopBusinessLogic.OfficePackage;
using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.BusinessLogicsContracts;
using BlacksmithWorkshopContracts.SearchModels;
using BlacksmithWorkshopContracts.StoragesContracts;
using BlacksmithWorkshopContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopBusinessLogic.BusinessLogic
{
    //Реализация бизнес-логики отчётов
    public class ReportLogic : IReportLogic
    {
        private readonly IManufactureStorage _manufactureStorage;

        private readonly IOrderStorage _orderStorage;

		private readonly IShopStorage _shopStorage;

        private readonly AbstractSaveToExcel _saveToExcel;

        private readonly AbstractSaveToWord _saveToWord;

        private readonly AbstractSaveToPdf _saveToPdf;

		public ReportLogic(IManufactureStorage manufactureStorage, IOrderStorage orderStorage, IShopStorage shopStorage,
			AbstractSaveToExcel saveToExcel, AbstractSaveToWord saveToWord, AbstractSaveToPdf saveToPdf)
        {
            _manufactureStorage = manufactureStorage;
            _orderStorage = orderStorage;
			_shopStorage = shopStorage;

            _saveToExcel = saveToExcel;
            _saveToWord = saveToWord;
            _saveToPdf = saveToPdf;
        }

		//Получение списка заготовок с указанием, в каких изделиях используются
        public List<ReportManufactureWorkPieceViewModel> GetManufactureWorkPiece()
        {
            var manufactures = _manufactureStorage.GetFullList();

            var list = new List<ReportManufactureWorkPieceViewModel>();

            foreach (var manufacture in manufactures)
            {
                var record = new ReportManufactureWorkPieceViewModel
                {
                    ManufactureName = manufacture.ManufactureName,
                    WorkPieces = new List<(string, int)>(),
                    TotalCount = 0
                };

                foreach (var workPiece in manufacture.ManufactureWorkPieces)
                {
					record.WorkPieces.Add(new(workPiece.Value.Item1.WorkPieceName, workPiece.Value.Item2));
                    record.TotalCount += workPiece.Value.Item2;
                }

                list.Add(record);
            }

            return list;
        }

		//Получение списка изделий с указанием, в каких магазинах в наличии
		public List<ReportShopManufacturesViewModel> GetShopManufactures()
		{
			var shops = _shopStorage.GetFullList();

			var list = new List<ReportShopManufacturesViewModel>();

			foreach (var shop in shops)
			{
				var record = new ReportShopManufacturesViewModel
				{
					ShopName = shop.ShopName,
					Manufactures = new List<(string, int)>(),
					TotalCount = 0
				};

				foreach (var manufacture in shop.ShopManufactures)
				{
					record.Manufactures.Add(new(manufacture.Value.Item1.ManufactureName, manufacture.Value.Item2));
					record.TotalCount += manufacture.Value.Item2;
				}

				list.Add(record);
			}

			return list;
		}

        //Получение списка заказов за определенный период
        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
        {
            return _orderStorage.GetFilteredList(new OrderSearchModel { DateFrom = model.DateFrom, DateTo = model.DateTo })
                .Select(x => new ReportOrdersViewModel
                {
                    Id = x.Id,
                    DateCreate = x.DateCreate,
                    ManufactureName = x.ManufactureName,
                    Sum = x.Sum,
                    OrderStatus = x.Status.ToString()
                })
                .ToList();
        }

		//Получение списка заказов за весь период
		public List<ReportGroupedOrdersViewModel> GetGroupedOrders()
		{
			return _orderStorage.GetFullList()
					.GroupBy(x => x.DateCreate.Date)
					.Select(x => new ReportGroupedOrdersViewModel
					{
						DateCreate = x.Key,
						Count = x.Count(),
						Sum = x.Sum(x => x.Sum)
					})
					.ToList();
		}

		//Сохранение изделий в файл-Word
        public void SaveManufacturesToWordFile(ReportBindingModel model)
        {
            _saveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список изделий",
                Manufactures = _manufactureStorage.GetFullList()
            });
        }

		//Сохранение магазинов в файл-Word
		public void SaveShopsToWordFile(ReportBindingModel model)
		{
			_saveToWord.CreateTable(new WordInfo
			{
				FileName = model.FileName,
				Title = "Таблица магазинов",
				Shops = _shopStorage.GetFullList()
			});
		}

		//Сохранение изделий с указаеним заготовок в файл-Excel
        public void SaveManufactureWorkPieceToExcelFile(ReportBindingModel model)
        {
            _saveToExcel.CreateReport(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список заготовок",
                ManufactureWorkPieces = GetManufactureWorkPiece()
            });
        }

		//Сохранение магазинов с указанием изделий в файл-Excel
		public void SaveShopManufacturesToExcelFile(ReportBindingModel model)
		{
			_saveToExcel.CreateShopReport(new ExcelInfo
			{
				FileName = model.FileName,
				Title = "Список магазинов",
				ShopManufactures = GetShopManufactures()
			});
		}

        //Сохранение заказов в файл-Pdf
        public void SaveOrdersToPdfFile(ReportBindingModel model)
        {
            _saveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                DateFrom = model.DateFrom!.Value,
                DateTo = model.DateTo!.Value,
                Orders = GetOrders(model)
            });
        }

		//Сохранение заказов за весь период в файл-Pdf
		public void SaveGroupedOrdersToPdfFile(ReportBindingModel model)
		{
			_saveToPdf.CreateGroupedDoc(new PdfInfo
			{
				FileName = model.FileName,
				Title = "Список заказов",
				GroupedOrders = GetGroupedOrders()
			});
		}
    }
}
