using BlacksmithWorkshopBusinessLogic.BusinessLogic;
using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.BusinessLogicsContracts;
using Microsoft.EntityFrameworkCore.Diagnostics;
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
	public partial class FormClients : Form
	{
		private readonly ILogger _logger;

		private readonly IClientLogic _clientLogic;

		public FormClients(ILogger<FormClients> logger, IClientLogic clientLogic)
		{
			InitializeComponent();

			_logger = logger;
			_clientLogic = clientLogic;
		}

		private void FormClients_Load(object sender, EventArgs e)
		{
			LoadData();
		}

		private void LoadData()
		{
            try
            {
                dataGridView.FillandConfigGrid(_clientLogic.ReadList(null));
                _logger.LogInformation("Загрузка клиентов");
            }
            catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка загрузки клиентов");
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void ButtonDelete_Click(object sender, EventArgs e)
		{
			if (dataGridView.SelectedRows.Count == 1)
			{
				if (MessageBox.Show("Удалить запись?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Id"].Value);

					_logger.LogInformation("Удаление клиента");

					try
					{
						if (!_clientLogic.Delete(new ClientBindingModel
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
