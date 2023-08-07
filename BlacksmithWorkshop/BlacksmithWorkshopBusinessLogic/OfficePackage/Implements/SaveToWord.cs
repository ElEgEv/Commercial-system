using BlacksmithWorkshopBusinessLogic.OfficePackage.HelperEnums;
using BlacksmithWorkshopBusinessLogic.OfficePackage.HelperModels;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopBusinessLogic.OfficePackage.Implements
{
    //реализация абстрактного класса сохранения в word
    public class SaveToWord : AbstractSaveToWord
    {
        private WordprocessingDocument? _wordDocument;

        private Body? _docBody;

        //Получение типа выравнивания
        private static JustificationValues GetJustificationValues(WordJustificationType type)
        {
            //выравнивание слева будет в том случае, если передаётся неизвестный тип выравнивания
            return type switch
            {
                WordJustificationType.Both => JustificationValues.Both,
                WordJustificationType.Center => JustificationValues.Center,
                _ => JustificationValues.Left,
            };
        }

        //Настройки страницы
        private static SectionProperties CreateSectionProperties()
        {
            var properties = new SectionProperties();

            //прописываем портретную ориентацию
            var pageSize = new PageSize
            {
                Orient = PageOrientationValues.Portrait
            };

            properties.AppendChild(pageSize);

            return properties;
        }

        //Задание форматирования для абзаца
        private static ParagraphProperties? CreateParagraphProperties(WordTextProperties? paragraphProperties)
        {
            if (paragraphProperties == null)
            {
                return null;
            }

            var properties = new ParagraphProperties();

            //вытаскиваем выравнивание текста
            properties.AppendChild(new Justification()
            {
                Val = GetJustificationValues(paragraphProperties.JustificationType)
            });

            properties.AppendChild(new SpacingBetweenLines
            {
                LineRule = LineSpacingRuleValues.Auto
            });

            properties.AppendChild(new Indentation());

            var paragraphMarkRunProperties = new ParagraphMarkRunProperties();

            if (!string.IsNullOrEmpty(paragraphProperties.Size))
            {
				paragraphMarkRunProperties.AppendChild(new FontSize { Val = paragraphProperties.Size });
            }

            properties.AppendChild(paragraphMarkRunProperties);

            return properties;
        }

        protected override void CreateWord(WordInfo info)
        {
            //создаём документ word
            _wordDocument = WordprocessingDocument.Create(info.FileName, WordprocessingDocumentType.Document);

            //вытаскиваем главную часть из вордовского документа
            MainDocumentPart mainPart = _wordDocument.AddMainDocumentPart();

            mainPart.Document = new Document();

            //генерируем тело основной части документа
            _docBody = mainPart.Document.AppendChild(new Body());
        }

        protected override void CreateParagraph(WordParagraph paragraph)
        {
            //проверка на то, был ли вызван WordprocessingDocument.Create (создался ли документ) и есть ли вообще параграф для вставки
            if (_docBody == null || paragraph == null)
            {
                return;
            }

            var docParagraph = new Paragraph();

            //добавляем свойства параграфа
            docParagraph.AppendChild(CreateParagraphProperties(paragraph.TextProperties));

            //вставляем блоки текста (их называют Run)
            foreach (var run in paragraph.Texts)
            {
                var docRun = new Run();
                var properties = new RunProperties();

                properties.AppendChild(new FontSize { Val = run.Item2.Size });

                if (run.Item2.Bold)
                {
                    properties.AppendChild(new Bold());
                }

                docRun.AppendChild(properties);

				docRun.AppendChild(new Text { Text = run.Item1, Space = SpaceProcessingModeValues.Preserve });

                docParagraph.AppendChild(docRun);
            }

            _docBody.AppendChild(docParagraph);
        }

        //метод сохранения документа
        protected override void SaveWord(WordInfo info)
        {
            if (_docBody == null || _wordDocument == null)
            {
                return;
            }

            //вставляем информацию по секциям (смотри, что является входным параметром)
            _docBody.AppendChild(CreateSectionProperties());

            //сохраняем документ
            _wordDocument.MainDocumentPart!.Document.Save();

            _wordDocument.Close();
        }

		protected override void CreateTable(WordParagraph paragraph)
		{
			if (_docBody == null || paragraph == null)
			{
				return;
			}

			Table table = new Table();

			var tableProp = new TableProperties();

			tableProp.AppendChild(new TableLayout { Type = TableLayoutValues.Fixed });
			tableProp.AppendChild(new TableBorders(
					new TopBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 4 },
					new LeftBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 4 },
					new RightBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 4 },
					new BottomBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 4 },
					new InsideHorizontalBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 4 },
					new InsideVerticalBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 4 }
				));
			tableProp.AppendChild(new TableWidth { Type = TableWidthUnitValues.Auto });
			
			table.AppendChild(tableProp);

			TableGrid tableGrid = new TableGrid();

			for (int j = 0; j < paragraph.RowTexts[0].Count; ++j)
			{
				tableGrid.AppendChild(new GridColumn() { Width = "3000" });
			}

			table.AppendChild(tableGrid);

			for (int i = 0; i < paragraph.RowTexts.Count; ++i)
			{
				TableRow docRow = new TableRow();

				for (int j = 0; j < paragraph.RowTexts[i].Count; ++j)
				{
					var docParagraph = new Paragraph();

					docParagraph.AppendChild(CreateParagraphProperties(paragraph.RowTexts[i][j].Item2));

					var docRun = new Run();

					var properties = new RunProperties();

					properties.AppendChild(new FontSize { Val = paragraph.RowTexts[i][j].Item2.Size });
					
					if (paragraph.RowTexts[i][j].Item2.Bold)
					{
						properties.AppendChild(new Bold());
					}

					docRun.AppendChild(properties);

					docRun.AppendChild(new Text { Text = paragraph.RowTexts[i][j].Item1, Space = SpaceProcessingModeValues.Preserve });

					docParagraph.AppendChild(docRun);
					TableCell docCell = new TableCell();
					docCell.AppendChild(docParagraph);
					docRow.AppendChild(docCell);
				}

				table.AppendChild(docRow);
			}

			_docBody.AppendChild(table);
		}
    }
}
