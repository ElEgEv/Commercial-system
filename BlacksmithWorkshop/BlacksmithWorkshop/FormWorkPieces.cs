using BlacksmithWorkshopBusinessLogic.BusinessLogic;
using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.BusinessLogicsContracts;
using BlacksmithWorkshopContracts.DI;
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
    public partial class FormWorkPieces : Form
    {
        private readonly ILogger _logger;

        private readonly IWorkPieceLogic _logic;

        public FormWorkPieces(ILogger<FormWorkPieces> logger, IWorkPieceLogic logic)
        {
            InitializeComponent();
            _logger = logger;
            _logic = logic;
        }

        private void FormWorkPiece_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                dataGridView.FillandConfigGrid(_logic.ReadList(null));

                _logger.LogInformation("Загрузка заготовок");
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Ошибка загрузки заготовок");

                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var form = DependencyManager.Instance.Resolve<FormWorkPiece>();

            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        //проверяем наличие выделенной строки
        private void ButtonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = DependencyManager.Instance.Resolve<FormWorkPiece>();

                form.Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Id"].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            //проверяем наличие выделенной строки
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Id"].Value);

                    _logger.LogInformation("Удаление компонента");

                    try
                    {
                        if (!_logic.Delete(new WorkPieceBindingModel
                        {
                            Id = id
                        }))
                        {
                            throw new Exception("Ошибка при удалении. Дополнительная информация в логах.");
                        }

                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Ошибка удаления компонента");
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ButtonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
