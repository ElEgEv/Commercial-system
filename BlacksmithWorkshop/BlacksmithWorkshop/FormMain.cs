using BlacksmithWorkshopBusinessLogic.BusinessLogic;
using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.BusinessLogicsContracts;
using BlacksmithWorkshopContracts.DI;
using BlacksmithWorkshopDataModels.Enums;
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
	public partial class FormMain : Form
	{
		private readonly ILogger _logger;

		private readonly IOrderLogic _orderLogic;

		private readonly IReportLogic _reportLogic;

		private readonly IWorkProcess _workProcess;

		private readonly IBackUpLogic _backUpLogic;

		public FormMain(ILogger<FormMain> logger, IOrderLogic orderLogic, IReportLogic reportLogic, IWorkProcess workProcess, IBackUpLogic backUpLogic)
		{
			InitializeComponent();

			_logger = logger;
			_orderLogic = orderLogic;
			_reportLogic = reportLogic;
			_workProcess = workProcess;
			_backUpLogic = backUpLogic;
		}

		private void FormMain_Load(object sender, EventArgs e)
		{
			LoadData();
		}

		private void LoadData()
		{
			_logger.LogInformation("Загрузка заказов");

			try
			{
				dataGridView.FillandConfigGrid(_orderLogic.ReadList(null));

				_logger.LogInformation("Загрузка заказов");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка загрузки заказов");
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void WorkPieceToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var form = DependencyManager.Instance.Resolve<FormWorkPieces>();

			form.ShowDialog();
		}

		private void ManufactureToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var form = DependencyManager.Instance.Resolve<FormManufactures>();

			form.ShowDialog();
		}

		private void ButtonCreateOrder_Click(object sender, EventArgs e)
		{
			var form = DependencyManager.Instance.Resolve<FormCreateOrder>();

			form.ShowDialog();
			LoadData();
		}

		private void ButtonIssuedOrder_Click(object sender, EventArgs e)
		{
			if (dataGridView.SelectedRows.Count == 1)
			{
				int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Id"].Value);
				_logger.LogInformation("Заказ №{id}. Меняется статус на 'Выдан'", id);

				try
				{
					var operationResult = _orderLogic.DeliveryOrder(new OrderBindingModel
					{
						Id = id
					});

					if (!operationResult)
					{
						throw new Exception("Ошибка при сохранении. Дополнительная информация в логах.");
					}

					_logger.LogInformation("Заказ №{id} выдан", id);

					LoadData();
				}
				catch (Exception ex)
				{
					_logger.LogError(ex, "Ошибка отметки о выдачи заказа");
					MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void ButtonRef_Click(object sender, EventArgs e)
		{
			LoadData();
		}

		private void ButtonSellManufacture_Click(object sender, EventArgs e)
		{
			var form = DependencyManager.Instance.Resolve<FormSellManufacture>();

			form.ShowDialog();
			LoadData();

		}

		private void ShopToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var form = DependencyManager.Instance.Resolve<FormShops>();

			form.ShowDialog();
		}

		private void AddManufactureToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var form = DependencyManager.Instance.Resolve<FormAddManufacture>();

			form.ShowDialog();
			LoadData();
		}

		private void GroupedOrdersReportToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var form = DependencyManager.Instance.Resolve<FormReportGroupedOrders>();

			form.ShowDialog();
		}

		private void WorkloadStoresReportToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var form = DependencyManager.Instance.Resolve<FormReportShopManufactures>();

			form.ShowDialog();
		}

		private void ShopsReportToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using var dialog = new SaveFileDialog { Filter = "docx|*.docx" };

			if (dialog.ShowDialog() == DialogResult.OK)
			{
				_reportLogic.SaveShopsToWordFile(new ReportBindingModel { FileName = dialog.FileName });
				MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void WorkPieceManufacturesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var form = DependencyManager.Instance.Resolve<FormReportManufactureWorkPieces>();

			form.ShowDialog();

		}

		private void ImplementerToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			var form = DependencyManager.Instance.Resolve<FormImplementers>();

			form.ShowDialog();
		}

		private void ClientsToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			var form = DependencyManager.Instance.Resolve<FormClients>();

			form.ShowDialog();
		}

		private void StartWorkToolStripMenuItem_Click(object sender, EventArgs e)
		{
			_workProcess.DoWork(DependencyManager.Instance.Resolve<IImplementerLogic>()!, _orderLogic);

			MessageBox.Show("Процесс обработки запущен", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void ReportManufactureToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using var dialog = new SaveFileDialog { Filter = "docx|*.docx" };

			if (dialog.ShowDialog() == DialogResult.OK)
			{
				_reportLogic.SaveManufacturesToWordFile(new ReportBindingModel
				{
					FileName = dialog.FileName
				});

				MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void OrdersReportToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var form = DependencyManager.Instance.Resolve<FormImplementers>();

			form.ShowDialog();
		}

		private void MessageToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var form = DependencyManager.Instance.Resolve<FormMails>();

			form.ShowDialog();
		}

		private void CreateBackUpToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			try
			{
				if (_backUpLogic != null)
				{
					var fbd = new FolderBrowserDialog();

					if (fbd.ShowDialog() == DialogResult.OK)
					{
						_backUpLogic.CreateBackUp(new BackUpSaveBinidngModel
						{
							FolderName = fbd.SelectedPath
						});

						MessageBox.Show("Бекап создан", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}