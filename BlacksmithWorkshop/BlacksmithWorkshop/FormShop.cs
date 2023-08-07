using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.BusinessLogicsContracts;
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
    public partial class FormShop : Form
    {
        private readonly ILogger _logger;

        private readonly IShopLogic _logic;

        private int? _id;

        private Dictionary<int, (IManufactureModel, int)> _shopManufactures;

        public int Id { set { _id = value; } }

        public FormShop(ILogger<FormShop> logger, IShopLogic logic)
        {
            InitializeComponent();

            _logger = logger;
            _logic = logic;
            _shopManufactures = new Dictionary<int, (IManufactureModel, int)>();
        }

        private void FormShop_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                _logger.LogInformation("Загрузка магазина");
                try
                {
                    var view = _logic.ReadElement(new ShopSearchModel
                    {
                        Id = _id.Value
                    });

                    if (view != null)
                    {
                        textBoxName.Text = view.ShopName;
                        textBoxAddress.Text = view.Address.ToString();
                        dateTimePickerDate.Value = view.DateOpen;
                        numericUpDownCount.Value = view.MaxCountManufactures;
                        _shopManufactures = view.ShopManufactures ?? new Dictionary<int, (IManufactureModel, int)>();
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ошибка загрузки магазина");
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadData()
        {
            _logger.LogInformation("Загрузка изделий в магазине");
            try
            {
                if (_shopManufactures != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var element in _shopManufactures)
                    {
                        dataGridView.Rows.Add(new object[] { element.Key, element.Value.Item1.ManufactureName, element.Value.Item2 });
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка загрузки изделий в магазине");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxAddress.Text))
            {
                MessageBox.Show("Заполните адрес", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _logger.LogInformation("Сохранение магазина");
            try
            {
                var model = new ShopBindingModel
                {
                    Id = _id ?? 0,
                    ShopName = textBoxName.Text,
                    Address = textBoxAddress.Text,
                    DateOpen = dateTimePickerDate.Value.Date,
                    MaxCountManufactures = (int)numericUpDownCount.Value
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
                _logger.LogError(ex, "Ошибка сохранения магазина");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
