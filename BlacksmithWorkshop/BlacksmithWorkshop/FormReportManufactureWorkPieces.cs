using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.BusinessLogicsContracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlacksmithWorkshop
{
    public partial class FormReportManufactureWorkPieces : Form
    {
        private readonly ILogger _logger;

        private readonly IReportLogic _logic;

        public FormReportManufactureWorkPieces(ILogger<FormReportManufactureWorkPieces> logger, IReportLogic logic)
        {
            InitializeComponent();

            _logger = logger;
            _logic = logic;
        }

        private void FormReportManufactureWorkPieces_Load(object sender, EventArgs e)
        {
            try
            {
                var dict = _logic.GetManufactureWorkPiece();

                if (dict != null)
                {
                    dataGridView.Rows.Clear();

                    foreach (var elem in dict)
                    {
                        dataGridView.Rows.Add(new object[] { elem.ManufactureName, "", "" });

                        foreach (var listElem in elem.WorkPieces)
                        {
                            dataGridView.Rows.Add(new object[] { "", listElem.Item1, listElem.Item2 });
                        }

                        dataGridView.Rows.Add(new object[] { "Итого", "", elem.TotalCount });
                        dataGridView.Rows.Add(Array.Empty<object>());
                    }
                }

                _logger.LogInformation("Загрузка списка изделий по заготовкам");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка загрузки списка изделий по заготовкам");

                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonSaveToExcel_Click(object sender, EventArgs e)
        {
            //фильтрация файлов для диалогового окна
            using var dialog = new SaveFileDialog 
            { 
                Filter = "xlsx|*.xlsx" 
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _logic.SaveManufactureWorkPieceToExcelFile(new ReportBindingModel
                    {
                        FileName = dialog.FileName
                    });

                    _logger.LogInformation("Сохранение списка изделий по заготовкам");

                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ошибка сохранения списка изделий по заготовкам");

                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
