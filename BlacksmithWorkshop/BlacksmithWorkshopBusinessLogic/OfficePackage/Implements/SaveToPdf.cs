﻿using BlacksmithWorkshopBusinessLogic.OfficePackage.HelperEnums;
using BlacksmithWorkshopBusinessLogic.OfficePackage.HelperModels;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopBusinessLogic.OfficePackage.Implements
{
    //реализация астрактного класса создания pdf документа
    public class SaveToPdf : AbstractSaveToPdf
    {
        private Document? _document;

        private Section? _section;

        private Table? _table;

        //преобразование необходимого типа выравнивания в соотвествующее выравнивание в MigraDoc
        private static ParagraphAlignment GetParagraphAlignment(PdfParagraphAlignmentType type)
        {
            return type switch
            {
                PdfParagraphAlignmentType.Center => ParagraphAlignment.Center,
                PdfParagraphAlignmentType.Left => ParagraphAlignment.Left,
				PdfParagraphAlignmentType.Right => ParagraphAlignment.Right,
                _ => ParagraphAlignment.Justify,
            };
        }

        //Создание стилей для документа
        private static void DefineStyles(Document document)
        {
            var style = document.Styles["Normal"];

            style.Font.Name = "Times New Roman";
            style.Font.Size = 14;

            style = document.Styles.AddStyle("NormalTitle", "Normal");
            style.Font.Bold = true;
        }

        protected override void CreatePdf(PdfInfo info)
        {
            //создаём документ
            _document = new Document();

            //передаём для него стили
            DefineStyles(_document);

            //получение первой секции документа
            _section = _document.AddSection();
        }

        protected override void CreateParagraph(PdfParagraph pdfParagraph)
        {
            if (_section == null)
            {
                return;
            }

            var paragraph = _section.AddParagraph(pdfParagraph.Text);
            paragraph.Format.SpaceAfter = "1cm";
            paragraph.Format.Alignment = GetParagraphAlignment(pdfParagraph.ParagraphAlignment);
            paragraph.Style = pdfParagraph.Style;
        }

        protected override void CreateTable(List<string> columns)
        {
            if (_document == null)
            {
                return;
            }

            //добавляем таблицу в документ как последнюю секцию (?)
            _table = _document.LastSection.AddTable();

            foreach (var elem in columns)
            {
                _table.AddColumn(elem);
            }
        }

        protected override void CreateRow(PdfRowParameters rowParameters)
        {
            if (_table == null)
            {
                return;
            }

            //добавление строки в таблицу
            var row = _table.AddRow();

            for (int i = 0; i < rowParameters.Texts.Count; ++i)
            {
                //ячейка добавляется добавлением параграфа
                row.Cells[i].AddParagraph(rowParameters.Texts[i]);

                if (!string.IsNullOrEmpty(rowParameters.Style))
                {
                    row.Cells[i].Style = rowParameters.Style;
                }

                Unit borderWidth = 0.5;

                row.Cells[i].Borders.Left.Width = borderWidth;
                row.Cells[i].Borders.Right.Width = borderWidth;
                row.Cells[i].Borders.Top.Width = borderWidth;
                row.Cells[i].Borders.Bottom.Width = borderWidth;

                row.Cells[i].Format.Alignment = GetParagraphAlignment(rowParameters.ParagraphAlignment);
                row.Cells[i].VerticalAlignment = VerticalAlignment.Center;
            }
        }

        protected override void SavePdf(PdfInfo info)
        {
            var renderer = new PdfDocumentRenderer(true)
            {
                Document = _document
            };

            renderer.RenderDocument();
            renderer.PdfDocument.Save(info.FileName);
        }
    }
}
