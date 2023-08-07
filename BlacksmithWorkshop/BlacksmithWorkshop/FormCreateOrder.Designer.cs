namespace BlacksmithWorkshop
{
	partial class FormCreateOrder
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
			labelManufacture = new Label();
			labelCount = new Label();
			labelSum = new Label();
			comboBoxManufacture = new ComboBox();
			textBoxCount = new TextBox();
			textBoxSum = new TextBox();
			buttonSave = new Button();
			buttonCancel = new Button();
			labelClient = new Label();
			comboBoxClient = new ComboBox();
			SuspendLayout();
			// 
			// labelManufacture
			// 
			labelManufacture.AutoSize = true;
			labelManufacture.Location = new Point(24, 24);
			labelManufacture.Name = "labelManufacture";
			labelManufacture.Size = new Size(71, 20);
			labelManufacture.TabIndex = 0;
			labelManufacture.Text = "Изделие:";
			// 
			// labelCount
			// 
			labelCount.AutoSize = true;
			labelCount.Location = new Point(24, 114);
			labelCount.Name = "labelCount";
			labelCount.Size = new Size(93, 20);
			labelCount.TabIndex = 1;
			labelCount.Text = "Количество:";
			// 
			// labelSum
			// 
			labelSum.AutoSize = true;
			labelSum.Location = new Point(24, 157);
			labelSum.Name = "labelSum";
			labelSum.Size = new Size(58, 20);
			labelSum.TabIndex = 2;
			labelSum.Text = "Сумма:";
			// 
			// comboBoxManufacture
			// 
			comboBoxManufacture.FormattingEnabled = true;
			comboBoxManufacture.Location = new Point(166, 21);
			comboBoxManufacture.Name = "comboBoxManufacture";
			comboBoxManufacture.Size = new Size(278, 28);
			comboBoxManufacture.TabIndex = 3;
			comboBoxManufacture.SelectedIndexChanged += ComboBoxManufacture_SelectedIndexChanged;
			// 
			// textBoxCount
			// 
			textBoxCount.Location = new Point(166, 111);
			textBoxCount.Name = "textBoxCount";
			textBoxCount.Size = new Size(278, 27);
			textBoxCount.TabIndex = 4;
			textBoxCount.TextChanged += TextBoxCount_TextChanged;
			// 
			// textBoxSum
			// 
			textBoxSum.Location = new Point(166, 154);
			textBoxSum.Name = "textBoxSum";
			textBoxSum.Size = new Size(278, 27);
			textBoxSum.TabIndex = 5;
			// 
			// buttonSave
			// 
			buttonSave.Location = new Point(230, 199);
			buttonSave.Name = "buttonSave";
			buttonSave.Size = new Size(94, 29);
			buttonSave.TabIndex = 6;
			buttonSave.Text = "Сохранить";
			buttonSave.UseVisualStyleBackColor = true;
			buttonSave.Click += ButtonSave_Click;
			// 
			// buttonCancel
			// 
			buttonCancel.Location = new Point(340, 199);
			buttonCancel.Name = "buttonCancel";
			buttonCancel.Size = new Size(94, 29);
			buttonCancel.TabIndex = 7;
			buttonCancel.Text = "Отмена";
			buttonCancel.UseVisualStyleBackColor = true;
			buttonCancel.Click += ButtonCancel_Click;
			// 
			// labelClient
			// 
			labelClient.AutoSize = true;
			labelClient.Location = new Point(24, 69);
			labelClient.Name = "labelClient";
			labelClient.Size = new Size(74, 20);
			labelClient.TabIndex = 8;
			labelClient.Text = "Заказчик:";
			// 
			// comboBoxClient
			// 
			comboBoxClient.FormattingEnabled = true;
			comboBoxClient.Location = new Point(166, 66);
			comboBoxClient.Name = "comboBoxClient";
			comboBoxClient.Size = new Size(278, 28);
			comboBoxClient.TabIndex = 9;
			// 
			// FormCreateOrder
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(479, 256);
			Controls.Add(comboBoxClient);
			Controls.Add(labelClient);
			Controls.Add(buttonCancel);
			Controls.Add(buttonSave);
			Controls.Add(textBoxSum);
			Controls.Add(textBoxCount);
			Controls.Add(comboBoxManufacture);
			Controls.Add(labelSum);
			Controls.Add(labelCount);
			Controls.Add(labelManufacture);
			Name = "FormCreateOrder";
			Text = "Заказ";
			Load += FormCreateOrder_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label labelManufacture;
		private Label labelCount;
		private Label labelSum;
		private ComboBox comboBoxManufacture;
		private TextBox textBoxCount;
		private TextBox textBoxSum;
		private Button buttonSave;
		private Button buttonCancel;
		private Label labelClient;
		private ComboBox comboBoxClient;
	}
}