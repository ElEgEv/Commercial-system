using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.BusinessLogicsContracts;
using BlacksmithWorkshopContracts.DI;
using BlacksmithWorkshopContracts.SearchModels;
using BlacksmithWorkshopDataModels.Models;
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
    public partial class FormManufacture : Form
    {
        private readonly ILogger _logger;

        private readonly IManufactureLogic _logic;

        private int? _id;

        private Dictionary<int, (IWorkPieceModel, int)> _manufactureWorkPieces;

        public int Id { set { _id = value; } }

        public FormManufacture(ILogger<FormManufacture> logger, IManufactureLogic logic)
        {
            InitializeComponent();

            _logger = logger;
            _logic = logic;
            _manufactureWorkPieces = new Dictionary<int, (IWorkPieceModel, int)>();
        }
       
        private void FormManufacture_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                _logger.LogInformation("Загрузка изделия");

                try
                {
                    var view = _logic.ReadElement(new ManufactureSearchModel { Id = _id.Value });

                    if(view != null)
                    {
                        textBoxName.Text = view.ManufactureName;
                        textBoxPrice.Text = view.Price.ToString();
                        _manufactureWorkPieces = view.ManufactureWorkPieces ?? new Dictionary<int, (IWorkPieceModel, int)>();
                        LoadData();
                    }
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex, "Ошибка загрузки изделия");
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadData()
        {
            _logger.LogInformation("Загрузка заготовок для изделия");

            try
            {
                if(_manufactureWorkPieces != null)
                {
                    dataGridView.Rows.Clear();

                    foreach(var awp in _manufactureWorkPieces)
                    {
                        dataGridView.Rows.Add(new object[] { awp.Key, awp.Value.Item1.WorkPieceName, awp.Value.Item2 });
                    }

                    textBoxPrice.Text = CalcPrice().ToString();
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Ошибка загрузки заготовки для изделия");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var form = DependencyManager.Instance.Resolve<FormManufactureWorkPiece>();

            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.WorkPieceModel == null)
                {
                    return;
                }

                _logger.LogInformation("Добавление новой заготовки:{WorkPieceName} - {Count}", form.WorkPieceModel.WorkPieceName, form.Count);

                if (_manufactureWorkPieces.ContainsKey(form.Id))
                {
                    _manufactureWorkPieces[form.Id] = (form.WorkPieceModel, form.Count);
                }
                else
                {
                    _manufactureWorkPieces.Add(form.Id, (form.WorkPieceModel, form.Count));
                }

                LoadData();
            }
        }

        private void ButtonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = DependencyManager.Instance.Resolve<FormManufactureWorkPiece>();
                
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                form.Id = id;
                form.Count = _manufactureWorkPieces[id].Item2;

                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (form.WorkPieceModel == null)
                    {
                        return;
                    }

                    _logger.LogInformation("Изменение компонента:{WorkPieceName} - {Count}", form.WorkPieceModel.WorkPieceName, form.Count); 
                    _manufactureWorkPieces[form.Id] = (form.WorkPieceModel, form.Count);

                    LoadData();
                }
            }
        }

        private void ButtonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        _logger.LogInformation("Удаление заготовки:{WorkPieceName} - {Count}", dataGridView.SelectedRows[0].Cells[1].Value);
                        _manufactureWorkPieces?.Remove(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    LoadData();
                }
            }
        }

        private void ButtonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (_manufactureWorkPieces == null || _manufactureWorkPieces.Count == 0)
            {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                return;
            }

            _logger.LogInformation("Сохранение изделия");

            try
            {
                var model = new ManufactureBindingModel
                {
                    Id = _id ?? 0,
                    ManufactureName = textBoxName.Text,
                    Price = Convert.ToDouble(textBoxPrice.Text),
                    ManufactureWorkPieces = _manufactureWorkPieces
                };

                var operationResult = _id.HasValue ? _logic.Update(model) : _logic.Create(model);

                if (!operationResult)
                {
                    throw new Exception("Ошибка при сохранении. Дополнительная информация в логах.");
                }

                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;

                Close();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка сохранения изделия");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        //в конце умножить на 1.1, так как прибавляем к итоговой стоимости некоторый процент (в данном случае 10%)
        private double CalcPrice()
        {
            double price = 0;

            foreach (var elem in _manufactureWorkPieces)
            {
                price += ((elem.Value.Item1?.Cost ?? 0) * elem.Value.Item2);
            }

            return Math.Round(price * 1.1, 2);
        }
    }
}
