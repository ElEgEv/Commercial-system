namespace BlacksmithWorkshop
{
	partial class FormMain
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			dataGridView = new DataGridView();
			buttonCreateOrder = new Button();
			buttonIssuedOrder = new Button();
			buttonRef = new Button();
			menuStrip = new MenuStrip();
			toolStripMenuItem = new ToolStripMenuItem();
			workPieceToolStripMenuItem = new ToolStripMenuItem();
			manufactureToolStripMenuItem = new ToolStripMenuItem();
			shopToolStripMenuItem = new ToolStripMenuItem();
			addManufactureToolStripMenuItem = new ToolStripMenuItem();
			reportToolStripMenuItem = new ToolStripMenuItem();
			groupedOrdersReportToolStripMenuItem = new ToolStripMenuItem();
			ordersReportToolStripMenuItem = new ToolStripMenuItem();
			workloadStoresReportToolStripMenuItem = new ToolStripMenuItem();
			shopsReportToolStripMenuItem = new ToolStripMenuItem();
			reportManufactureToolStripMenuItem = new ToolStripMenuItem();
			workPieceManufacturesToolStripMenuItem = new ToolStripMenuItem();
			workWithImplementerToolStripMenuItem = new ToolStripMenuItem();
			implementerToolStripMenuItem = new ToolStripMenuItem();
			работаСКлиентамиToolStripMenuItem = new ToolStripMenuItem();
			clientsToolStripMenuItem = new ToolStripMenuItem();
			messageToolStripMenuItem = new ToolStripMenuItem();
			startWorkToolStripMenuItem = new ToolStripMenuItem();
			buttonSellManufacture = new Button();
			createBackUpToolStripMenuItem = new ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
			menuStrip.SuspendLayout();
			SuspendLayout();
			// 
			// dataGridView
			// 
			dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView.Location = new Point(11, 36);
			dataGridView.Name = "dataGridView";
			dataGridView.RowHeadersWidth = 51;
			dataGridView.RowTemplate.Height = 29;
			dataGridView.Size = new Size(937, 448);
			dataGridView.TabIndex = 0;
			// 
			// buttonCreateOrder
			// 
			buttonCreateOrder.Location = new Point(1014, 67);
			buttonCreateOrder.Name = "buttonCreateOrder";
			buttonCreateOrder.Size = new Size(235, 29);
			buttonCreateOrder.TabIndex = 1;
			buttonCreateOrder.Text = "Создать заказ";
			buttonCreateOrder.UseVisualStyleBackColor = true;
			buttonCreateOrder.Click += ButtonCreateOrder_Click;
			// 
			// buttonIssuedOrder
			// 
			buttonIssuedOrder.Location = new Point(1014, 141);
			buttonIssuedOrder.Name = "buttonIssuedOrder";
			buttonIssuedOrder.Size = new Size(235, 29);
			buttonIssuedOrder.TabIndex = 4;
			buttonIssuedOrder.Text = "Заказ выдан";
			buttonIssuedOrder.UseVisualStyleBackColor = true;
			buttonIssuedOrder.Click += ButtonIssuedOrder_Click;
			// 
			// buttonRef
			// 
			buttonRef.Location = new Point(1014, 214);
			buttonRef.Name = "buttonRef";
			buttonRef.Size = new Size(235, 29);
			buttonRef.TabIndex = 5;
			buttonRef.Text = "Обновить";
			buttonRef.UseVisualStyleBackColor = true;
			buttonRef.Click += ButtonRef_Click;
			// 
			// menuStrip
			// 
			menuStrip.ImageScalingSize = new Size(20, 20);
			menuStrip.Items.AddRange(new ToolStripItem[] { toolStripMenuItem, reportToolStripMenuItem, workWithImplementerToolStripMenuItem, работаСКлиентамиToolStripMenuItem, startWorkToolStripMenuItem, createBackUpToolStripMenuItem });
			menuStrip.Location = new Point(0, 0);
			menuStrip.Name = "menuStrip";
			menuStrip.Padding = new Padding(6, 3, 0, 3);
			menuStrip.Size = new Size(1297, 30);
			menuStrip.TabIndex = 6;
			menuStrip.Text = "menuStrip1";
			// 
			// toolStripMenuItem
			// 
			toolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { workPieceToolStripMenuItem, manufactureToolStripMenuItem, shopToolStripMenuItem, addManufactureToolStripMenuItem });
			toolStripMenuItem.Name = "toolStripMenuItem";
			toolStripMenuItem.Size = new Size(117, 24);
			toolStripMenuItem.Text = "Справочники";
			// 
			// workPieceToolStripMenuItem
			// 
			workPieceToolStripMenuItem.Name = "workPieceToolStripMenuItem";
			workPieceToolStripMenuItem.Size = new Size(251, 26);
			workPieceToolStripMenuItem.Text = "Заготовки";
			workPieceToolStripMenuItem.Click += WorkPieceToolStripMenuItem_Click;
			// 
			// manufactureToolStripMenuItem
			// 
			manufactureToolStripMenuItem.Name = "manufactureToolStripMenuItem";
			manufactureToolStripMenuItem.Size = new Size(251, 26);
			manufactureToolStripMenuItem.Text = "Изделия";
			manufactureToolStripMenuItem.Click += ManufactureToolStripMenuItem_Click;
			// 
			// shopToolStripMenuItem
			// 
			shopToolStripMenuItem.Name = "shopToolStripMenuItem";
			shopToolStripMenuItem.Size = new Size(251, 26);
			shopToolStripMenuItem.Text = "Магазины";
			shopToolStripMenuItem.Click += ShopToolStripMenuItem_Click;
			// 
			// addManufactureToolStripMenuItem
			// 
			addManufactureToolStripMenuItem.Name = "addManufactureToolStripMenuItem";
			addManufactureToolStripMenuItem.Size = new Size(251, 26);
			addManufactureToolStripMenuItem.Text = "Пополнение магазина";
			addManufactureToolStripMenuItem.Click += AddManufactureToolStripMenuItem_Click;
			// 
			// reportToolStripMenuItem
			// 
			reportToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { groupedOrdersReportToolStripMenuItem, ordersReportToolStripMenuItem, workloadStoresReportToolStripMenuItem, shopsReportToolStripMenuItem, reportManufactureToolStripMenuItem, workPieceManufacturesToolStripMenuItem });
			reportToolStripMenuItem.Name = "reportToolStripMenuItem";
			reportToolStripMenuItem.Size = new Size(73, 24);
			reportToolStripMenuItem.Text = "Отчёты";
			// 
			// groupedOrdersReportToolStripMenuItem
			// 
			groupedOrdersReportToolStripMenuItem.Name = "groupedOrdersReportToolStripMenuItem";
			groupedOrdersReportToolStripMenuItem.Size = new Size(310, 26);
			groupedOrdersReportToolStripMenuItem.Text = "Список заказов за весь период";
			groupedOrdersReportToolStripMenuItem.Click += GroupedOrdersReportToolStripMenuItem_Click;
			// 
			// ordersReportToolStripMenuItem
			// 
			ordersReportToolStripMenuItem.Name = "ordersReportToolStripMenuItem";
			ordersReportToolStripMenuItem.Size = new Size(310, 26);
			ordersReportToolStripMenuItem.Text = "Список заказов";
			ordersReportToolStripMenuItem.Click += OrdersReportToolStripMenuItem_Click;
			// 
			// workloadStoresReportToolStripMenuItem
			// 
			workloadStoresReportToolStripMenuItem.Name = "workloadStoresReportToolStripMenuItem";
			workloadStoresReportToolStripMenuItem.Size = new Size(310, 26);
			workloadStoresReportToolStripMenuItem.Text = "Загруженность магазинов";
			workloadStoresReportToolStripMenuItem.Click += WorkloadStoresReportToolStripMenuItem_Click;
			// 
			// shopsReportToolStripMenuItem
			// 
			shopsReportToolStripMenuItem.Name = "shopsReportToolStripMenuItem";
			shopsReportToolStripMenuItem.Size = new Size(310, 26);
			shopsReportToolStripMenuItem.Text = "Таблица магазинов";
			shopsReportToolStripMenuItem.Click += ShopsReportToolStripMenuItem_Click;
			// 
			// reportManufactureToolStripMenuItem
			// 
			reportManufactureToolStripMenuItem.Name = "reportManufactureToolStripMenuItem";
			reportManufactureToolStripMenuItem.Size = new Size(310, 26);
			reportManufactureToolStripMenuItem.Text = "Список изделий";
			reportManufactureToolStripMenuItem.Click += ReportManufactureToolStripMenuItem_Click;
			// 
			// workPieceManufacturesToolStripMenuItem
			// 
			workPieceManufacturesToolStripMenuItem.Name = "workPieceManufacturesToolStripMenuItem";
			workPieceManufacturesToolStripMenuItem.Size = new Size(310, 26);
			workPieceManufacturesToolStripMenuItem.Text = "Заготовки по изделиям";
			workPieceManufacturesToolStripMenuItem.Click += WorkPieceManufacturesToolStripMenuItem_Click;
			// 
			// workWithImplementerToolStripMenuItem
			// 
			workWithImplementerToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { implementerToolStripMenuItem });
			workWithImplementerToolStripMenuItem.Name = "workWithImplementerToolStripMenuItem";
			workWithImplementerToolStripMenuItem.Size = new Size(196, 24);
			workWithImplementerToolStripMenuItem.Text = "Работа с исполнителями";
			// 
			// implementerToolStripMenuItem
			// 
			implementerToolStripMenuItem.Name = "implementerToolStripMenuItem";
			implementerToolStripMenuItem.Size = new Size(185, 26);
			implementerToolStripMenuItem.Text = "Исполнители";
			implementerToolStripMenuItem.Click += ImplementerToolStripMenuItem_Click_1;
			// 
			// работаСКлиентамиToolStripMenuItem
			// 
			работаСКлиентамиToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { clientsToolStripMenuItem, messageToolStripMenuItem });
			работаСКлиентамиToolStripMenuItem.Name = "работаСКлиентамиToolStripMenuItem";
			работаСКлиентамиToolStripMenuItem.Size = new Size(161, 24);
			работаСКлиентамиToolStripMenuItem.Text = "Работа с клиентами";
			// 
			// clientsToolStripMenuItem
			// 
			clientsToolStripMenuItem.Name = "clientsToolStripMenuItem";
			clientsToolStripMenuItem.Size = new Size(152, 26);
			clientsToolStripMenuItem.Text = "Клиенты";
			clientsToolStripMenuItem.Click += ClientsToolStripMenuItem_Click_1;
			// 
			// messageToolStripMenuItem
			// 
			messageToolStripMenuItem.Name = "messageToolStripMenuItem";
			messageToolStripMenuItem.Size = new Size(152, 26);
			messageToolStripMenuItem.Text = "Письма";
			messageToolStripMenuItem.Click += MessageToolStripMenuItem_Click;
			// 
			// startWorkToolStripMenuItem
			// 
			startWorkToolStripMenuItem.Name = "startWorkToolStripMenuItem";
			startWorkToolStripMenuItem.Size = new Size(114, 24);
			startWorkToolStripMenuItem.Text = "Запуск работ";
			startWorkToolStripMenuItem.Click += StartWorkToolStripMenuItem_Click;
			// 
			// buttonSellManufacture
			// 
			buttonSellManufacture.Location = new Point(1014, 285);
			buttonSellManufacture.Name = "buttonSellManufacture";
			buttonSellManufacture.Size = new Size(233, 29);
			buttonSellManufacture.TabIndex = 7;
			buttonSellManufacture.Text = "Продажа изделий";
			buttonSellManufacture.UseVisualStyleBackColor = true;
			buttonSellManufacture.Click += ButtonSellManufacture_Click;
			// 
			// createBackUpToolStripMenuItem
			// 
			createBackUpToolStripMenuItem.Name = "createBackUpToolStripMenuItem";
			createBackUpToolStripMenuItem.Size = new Size(122, 24);
			createBackUpToolStripMenuItem.Text = "Создать бэкап";
			createBackUpToolStripMenuItem.Click += CreateBackUpToolStripMenuItem_Click_1;
			// 
			// FormMain
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1297, 496);
			Controls.Add(buttonSellManufacture);
			Controls.Add(buttonRef);
			Controls.Add(buttonIssuedOrder);
			Controls.Add(buttonCreateOrder);
			Controls.Add(dataGridView);
			Controls.Add(menuStrip);
			MainMenuStrip = menuStrip;
			Name = "FormMain";
			Text = "Кузнечная мастерская";
			Load += FormMain_Load;
			((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
			menuStrip.ResumeLayout(false);
			menuStrip.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private DataGridView dataGridView;
		private Button buttonCreateOrder;
		private Button buttonIssuedOrder;
		private Button buttonRef;
		private MenuStrip menuStrip;
		private ToolStripMenuItem toolStripMenuItem;
		private ToolStripMenuItem workPieceToolStripMenuItem;
		private ToolStripMenuItem manufactureToolStripMenuItem;
		private ToolStripMenuItem shopToolStripMenuItem;
		private ToolStripMenuItem addManufactureToolStripMenuItem;
		private Button buttonSellManufacture;
		private ToolStripMenuItem reportToolStripMenuItem;
		private ToolStripMenuItem groupedOrdersReportToolStripMenuItem;
		private ToolStripMenuItem ordersReportToolStripMenuItem;
		private ToolStripMenuItem workloadStoresReportToolStripMenuItem;
		private ToolStripMenuItem shopsReportToolStripMenuItem;
		private ToolStripMenuItem reportManufactureToolStripMenuItem;
		private ToolStripMenuItem workPieceManufacturesToolStripMenuItem;
		private ToolStripMenuItem workWithImplementerToolStripMenuItem;
		private ToolStripMenuItem implementerToolStripMenuItem;
		private ToolStripMenuItem работаСКлиентамиToolStripMenuItem;
		private ToolStripMenuItem clientsToolStripMenuItem;
		private ToolStripMenuItem startWorkToolStripMenuItem;
		private ToolStripMenuItem messageToolStripMenuItem;
		private ToolStripMenuItem createBackUpToolStripMenuItem;
	}
}