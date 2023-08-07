using BlacksmithWorkshopContracts.BusinessLogicsContracts;
using BlacksmithWorkshopContracts.SearchModels;
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
    public partial class FormSellManufacture : Form
    {
        private readonly ILogger _logger;

        private readonly IManufactureLogic _logicI;

        private readonly IShopLogic _logicS;

        public FormSellManufacture(ILogger<FormAddManufacture> logger, IManufactureLogic logicI, IShopLogic logicS)
        {
            InitializeComponent();

            _logger = logger;
            _logicI = logicI;
            _logicS = logicS;
        }

        private void FormSellManufacture_Load(object sender, EventArgs e)
        {
            _logger.LogInformation("Загрузка списка изделий для продажи");

            try
            {
                var list = _logicI.ReadList(null);
                if (list != null)
                {
                    comboBoxManufacture.DisplayMember = "ManufactureName";
                    comboBoxManufacture.ValueMember = "Id";
                    comboBoxManufacture.DataSource = list;
                    comboBoxManufacture.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка загрузки списка изделий");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxManufacture.SelectedValue == null)
            {
                MessageBox.Show("Выберите изделие", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _logger.LogInformation("Продажа изделия");

            try
            {
                var operationResult = _logicS.SellManufatures(_logicI.ReadElement(new ManufactureSearchModel()
                {
                    Id = Convert.ToInt32(comboBoxManufacture.SelectedValue)
                })!, Convert.ToInt32(textBoxCount.Text));

                if (!operationResult)
                {
                    throw new Exception("Ошибка при продаже изделия. Дополнительная информация в логах.");
                }

                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка продажи изделия");
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
