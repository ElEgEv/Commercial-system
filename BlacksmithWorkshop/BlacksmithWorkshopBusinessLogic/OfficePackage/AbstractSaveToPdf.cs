using BlacksmithWorkshopBusinessLogic.OfficePackage.HelperEnums;
using BlacksmithWorkshopBusinessLogic.OfficePackage.HelperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopBusinessLogic.OfficePackage
{
    public abstract class AbstractSaveToPdf
    {
        //публичный метод создания документа. Описание методов ниже
        public void CreateDoc(PdfInfo info)
        {
            CreatePdf(info);

			CreateParagraph(new PdfParagraph { Text = info.Title, Style = "NormalTitle", ParagraphAlignment = PdfParagraphAlignmentType.Center });
			
			CreateParagraph(new PdfParagraph { Text = $"с {info.DateFrom.ToShortDateString()} по {info.DateTo.ToShortDateString()}", Style = "Normal", ParagraphAlignment = PdfParagraphAlignmentType.Center });

			CreateTable(new List<string> { "2cm", "3cm", "6cm", "3cm", "3cm" });

			CreateRow(new PdfRowParameters
            {
				Texts = new List<string> { "Номер", "Дата заказа", "Изделие", "Статус заказа", "Сумма" },
                Style = "NormalTitle",
                ParagraphAlignment = PdfParagraphAlignmentType.Center
            });

			foreach (var order in info.Orders)
			{
				CreateRow(new PdfRowParameters
            {
					Texts = new List<string> { order.Id.ToString(), order.DateCreate.ToShortDateString(), order.ManufactureName, order.OrderStatus, order.Sum.ToString() },
                Style = "Normal",
					ParagraphAlignment = PdfParagraphAlignmentType.Left
            });
			}

			CreateParagraph(new PdfParagraph { Text = $"Итого: {info.Orders.Sum(x => x.Sum)}\t", Style = "Normal", ParagraphAlignment = PdfParagraphAlignmentType.Right });

			SavePdf(info);
		}

		public void CreateGroupedDoc(PdfInfo info)
		{
			CreatePdf(info);

			CreateParagraph(new PdfParagraph { Text = info.Title, Style = "NormalTitle", ParagraphAlignment = PdfParagraphAlignmentType.Center });

			CreateTable(new List<string> { "3cm", "3cm", "3cm" });

            CreateRow(new PdfRowParameters
            {
				Texts = new List<string> { "Дата заказа", "Количество заказов", "Сумма" },
                Style = "NormalTitle",
                ParagraphAlignment = PdfParagraphAlignmentType.Center
            });

			foreach (var order in info.GroupedOrders)
            {
                CreateRow(new PdfRowParameters
                {
					Texts = new List<string> { order.DateCreate.ToShortDateString(), order.Count.ToString(), order.Sum.ToString() },
                    Style = "Normal",
                    ParagraphAlignment = PdfParagraphAlignmentType.Left
                });
            }

			CreateParagraph(new PdfParagraph { Text = $"Итого: {info.GroupedOrders.Sum(x => x.Sum)}\t", Style = "Normal", ParagraphAlignment = PdfParagraphAlignmentType.Center });

            SavePdf(info);
        }

		//Создание doc-файла
        protected abstract void CreatePdf(PdfInfo info);

		//Создание параграфа с текстом
        protected abstract void CreateParagraph(PdfParagraph paragraph);

		//Создание таблицы
        protected abstract void CreateTable(List<string> columns);

		//Создание и заполнение строки
        protected abstract void CreateRow(PdfRowParameters rowParameters);

		//Сохранение файла
        protected abstract void SavePdf(PdfInfo info);
    }
}
