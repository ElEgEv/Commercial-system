using BlacksmithWorkshopBusinessLogic.OfficePackage.HelperEnums;
using BlacksmithWorkshopBusinessLogic.OfficePackage.HelperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopBusinessLogic.OfficePackage
{
    public abstract class AbstractSaveToExcel
    {
		//Создание отчета
        public void CreateReport(ExcelInfo info)
        {
            CreateExcel(info);

            InsertCellInWorksheet(new ExcelCellParameters
            {
                ColumnName = "A",
                RowIndex = 1,
                Text = info.Title,
                StyleInfo = ExcelStyleInfoType.Title
            });

            MergeCells(new ExcelMergeParameters
            {
                CellFromName = "A1",
                CellToName = "C1"
            });

            uint rowIndex = 2;

            foreach (var mwp in info.ManufactureWorkPieces)
            {
                InsertCellInWorksheet(new ExcelCellParameters
                {
                    ColumnName = "A",
                    RowIndex = rowIndex,
                    Text = mwp.ManufactureName,
                    StyleInfo = ExcelStyleInfoType.Text
                });

                rowIndex++;

                foreach (var (WorkPiece, Count) in mwp.WorkPieces)
                {
                    InsertCellInWorksheet(new ExcelCellParameters
                    {
                        ColumnName = "B",
                        RowIndex = rowIndex,
                        Text = WorkPiece,
						StyleInfo = ExcelStyleInfoType.TextWithBorder
                    });

                    InsertCellInWorksheet(new ExcelCellParameters
                    {
                        ColumnName = "C",
                        RowIndex = rowIndex,
                        Text = Count.ToString(),
						StyleInfo = ExcelStyleInfoType.TextWithBorder
                    });

                    rowIndex++;
                }

                InsertCellInWorksheet(new ExcelCellParameters
                {
                    ColumnName = "A",
                    RowIndex = rowIndex,
                    Text = "Итого",
                    StyleInfo = ExcelStyleInfoType.Text
                });

                InsertCellInWorksheet(new ExcelCellParameters
                {
                    ColumnName = "C",
                    RowIndex = rowIndex,
                    Text = mwp.TotalCount.ToString(),
                    StyleInfo = ExcelStyleInfoType.Text
                });

                rowIndex++;
            }

            SaveExcel(info);
        }

		public void CreateShopReport(ExcelInfo info)
		{
			CreateExcel(info);

			InsertCellInWorksheet(new ExcelCellParameters
			{
				ColumnName = "A",
				RowIndex = 1,
				Text = info.Title,
				StyleInfo = ExcelStyleInfoType.Title
			});

			MergeCells(new ExcelMergeParameters
			{
				CellFromName = "A1",
				CellToName = "C1"
			});

			uint rowIndex = 2;

			foreach (var sm in info.ShopManufactures)
			{
				InsertCellInWorksheet(new ExcelCellParameters
				{
					ColumnName = "A",
					RowIndex = rowIndex,
					Text = sm.ShopName,
					StyleInfo = ExcelStyleInfoType.Text
				});

				rowIndex++;

				foreach (var (Manufacture, Count) in sm.Manufactures)
				{
					InsertCellInWorksheet(new ExcelCellParameters
					{
						ColumnName = "B",
						RowIndex = rowIndex,
						Text = Manufacture,
						StyleInfo = ExcelStyleInfoType.TextWithBorder
					});

					InsertCellInWorksheet(new ExcelCellParameters
					{
						ColumnName = "C",
						RowIndex = rowIndex,
						Text = Count.ToString(),
						StyleInfo = ExcelStyleInfoType.TextWithBorder
					});

					rowIndex++;
				}

				InsertCellInWorksheet(new ExcelCellParameters
				{
					ColumnName = "A",
					RowIndex = rowIndex,
					Text = "Итого",
					StyleInfo = ExcelStyleInfoType.Text
				});

				InsertCellInWorksheet(new ExcelCellParameters
				{
					ColumnName = "C",
					RowIndex = rowIndex,
					Text = sm.TotalCount.ToString(),
					StyleInfo = ExcelStyleInfoType.Text
				});

				rowIndex++;
			}

			SaveExcel(info);
		}

        //Создание excel-файла
        protected abstract void CreateExcel(ExcelInfo info);

        //Добавляем новую ячейку в лист
        protected abstract void InsertCellInWorksheet(ExcelCellParameters excelParams);

        //Объединение ячеек
        protected abstract void MergeCells(ExcelMergeParameters excelParams);

        //Сохранение файла
        protected abstract void SaveExcel(ExcelInfo info);
    }
}
