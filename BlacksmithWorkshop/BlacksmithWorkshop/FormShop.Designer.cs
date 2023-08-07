namespace BlacksmithWorkshop
{
    partial class FormShop
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
            this.labelName = new System.Windows.Forms.Label();
            this.labelAddress = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.groupBoxIceCreams = new System.Windows.Forms.GroupBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnManufactureName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelDate = new System.Windows.Forms.Label();
            this.dateTimePickerDate = new System.Windows.Forms.DateTimePicker();
            this.labelCount = new System.Windows.Forms.Label();
            this.numericUpDownCount = new System.Windows.Forms.NumericUpDown();
            this.groupBoxIceCreams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCount)).BeginInit();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(21, 13);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(80, 20);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Название:";
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Location = new System.Drawing.Point(304, 12);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(54, 20);
            this.labelAddress.TabIndex = 1;
            this.labelAddress.Text = "Адрес:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(107, 10);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(157, 27);
            this.textBoxName.TabIndex = 2;
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(364, 9);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(157, 27);
            this.textBoxAddress.TabIndex = 3;
            // 
            // groupBoxIceCreams
            // 
            this.groupBoxIceCreams.Controls.Add(this.dataGridView);
            this.groupBoxIceCreams.Location = new System.Drawing.Point(14, 94);
            this.groupBoxIceCreams.Name = "groupBoxIceCreams";
            this.groupBoxIceCreams.Size = new System.Drawing.Size(823, 275);
            this.groupBoxIceCreams.TabIndex = 4;
            this.groupBoxIceCreams.TabStop = false;
            this.groupBoxIceCreams.Text = "Изделия";
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.ColumnManufactureName,
            this.ColumnCount});
            this.dataGridView.Location = new System.Drawing.Point(6, 27);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 29;
            this.dataGridView.Size = new System.Drawing.Size(810, 243);
            this.dataGridView.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.Visible = false;
            this.ID.Width = 125;
            // 
            // ColumnManufactureName
            // 
            this.ColumnManufactureName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnManufactureName.HeaderText = "Изделие";
            this.ColumnManufactureName.MinimumWidth = 6;
            this.ColumnManufactureName.Name = "ColumnManufactureName";
            this.ColumnManufactureName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ColumnCount
            // 
            this.ColumnCount.HeaderText = "Количество";
            this.ColumnCount.MinimumWidth = 6;
            this.ColumnCount.Name = "ColumnCount";
            this.ColumnCount.Width = 125;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(470, 381);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(155, 29);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(662, 381);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(155, 29);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(562, 12);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(113, 20);
            this.labelDate.TabIndex = 7;
            this.labelDate.Text = "Дата открытия:";
            // 
            // dateTimePickerDate
            // 
            this.dateTimePickerDate.Location = new System.Drawing.Point(681, 9);
            this.dateTimePickerDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateTimePickerDate.Name = "dateTimePickerDate";
            this.dateTimePickerDate.Size = new System.Drawing.Size(145, 27);
            this.dateTimePickerDate.TabIndex = 9;
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(21, 55);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(173, 20);
            this.labelCount.TabIndex = 10;
            this.labelCount.Text = "Вместимость магазина:";
            // 
            // numericUpDownCount
            // 
            this.numericUpDownCount.Location = new System.Drawing.Point(200, 53);
            this.numericUpDownCount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericUpDownCount.Name = "numericUpDownCount";
            this.numericUpDownCount.Size = new System.Drawing.Size(145, 27);
            this.numericUpDownCount.TabIndex = 11;
            // 
            // FormShop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 425);
            this.Controls.Add(this.numericUpDownCount);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.dateTimePickerDate);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBoxIceCreams);
            this.Controls.Add(this.textBoxAddress);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelAddress);
            this.Controls.Add(this.labelName);
            this.Name = "FormShop";
            this.Text = "Магазин";
            this.Load += new System.EventHandler(this.FormShop_Load);
            this.groupBoxIceCreams.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelName;
        private Label labelAddress;
        private TextBox textBoxName;
        private TextBox textBoxAddress;
        private GroupBox groupBoxIceCreams;
        private DataGridView dataGridView;
        private Button buttonSave;
        private Button buttonCancel;
        private Label labelDate;
        private DateTimePicker dateTimePickerDate;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn ColumnManufactureName;
        private DataGridViewTextBoxColumn ColumnCount;
        private Label labelCount;
        private NumericUpDown numericUpDownCount;
    }
}