namespace BlacksmithWorkshop
{
    partial class FormReportManufactureWorkPieces
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
			buttonSaveToExcel = new Button();
			ColumnManufacture = new DataGridViewTextBoxColumn();
			ColumnWorkPiece = new DataGridViewTextBoxColumn();
			ColumnCount = new DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
			SuspendLayout();
            // 
			// dataGridView
            // 
			dataGridView.AllowUserToAddRows = false;
			dataGridView.AllowUserToDeleteRows = false;
			dataGridView.AllowUserToOrderColumns = true;
			dataGridView.AllowUserToResizeColumns = false;
			dataGridView.AllowUserToResizeRows = false;
			dataGridView.BackgroundColor = SystemColors.ControlLightLight;
			dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView.Columns.AddRange(new DataGridViewColumn[] { ColumnManufacture, ColumnWorkPiece, ColumnCount });
			dataGridView.Dock = DockStyle.Bottom;
			dataGridView.Location = new Point(0, 63);
			dataGridView.Margin = new Padding(4, 5, 4, 5);
			dataGridView.MultiSelect = false;
			dataGridView.Name = "dataGridView";
			dataGridView.ReadOnly = true;
			dataGridView.RowHeadersVisible = false;
			dataGridView.RowHeadersWidth = 51;
			dataGridView.Size = new Size(704, 680);
			dataGridView.TabIndex = 0;
            // 
			// buttonSaveToExcel
            // 
			buttonSaveToExcel.Location = new Point(16, 18);
			buttonSaveToExcel.Margin = new Padding(4, 5, 4, 5);
			buttonSaveToExcel.Name = "buttonSaveToExcel";
			buttonSaveToExcel.Size = new Size(212, 35);
			buttonSaveToExcel.TabIndex = 1;
			buttonSaveToExcel.Text = "Сохранить в Excel";
			buttonSaveToExcel.UseVisualStyleBackColor = true;
			buttonSaveToExcel.Click += ButtonSaveToExcel_Click;
            // 
			// ColumnManufacture
            // 
			ColumnManufacture.HeaderText = "Изделие";
			ColumnManufacture.MinimumWidth = 6;
			ColumnManufacture.Name = "ColumnManufacture";
			ColumnManufacture.ReadOnly = true;
			ColumnManufacture.Width = 200;
            // 
			// ColumnWorkPiece
            // 
			ColumnWorkPiece.HeaderText = "Заготовка";
			ColumnWorkPiece.MinimumWidth = 6;
			ColumnWorkPiece.Name = "ColumnWorkPiece";
			ColumnWorkPiece.ReadOnly = true;
			ColumnWorkPiece.Width = 200;
            // 
            // ColumnCount
            // 
			ColumnCount.HeaderText = "Количество";
			ColumnCount.MinimumWidth = 6;
			ColumnCount.Name = "ColumnCount";
			ColumnCount.ReadOnly = true;
			ColumnCount.Width = 125;
            // 
            // FormReportManufactureWorkPieces
            // 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(704, 743);
			Controls.Add(buttonSaveToExcel);
			Controls.Add(dataGridView);
			Margin = new Padding(4, 5, 4, 5);
			Name = "FormReportManufactureWorkPieces";
			Text = "Заготовки по изделиям";
			Load += FormReportManufactureWorkPieces_Load;
			((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
			ResumeLayout(false);
        }

        #endregion

		private DataGridView dataGridView;
        private Button buttonSaveToExcel;
        private DataGridViewTextBoxColumn ColumWorkPiece;
        private DataGridViewTextBoxColumn ColumnManufacture;
		private DataGridViewTextBoxColumn ColumnWorkPiece;
        private DataGridViewTextBoxColumn ColumnCount;
    }
}