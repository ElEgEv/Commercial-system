namespace BlacksmithWorkshop
{
	partial class FormClients
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
			buttonDelete = new Button();
			buttonRef = new Button();
			((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
			SuspendLayout();
			// 
			// dataGridView
			// 
			dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView.Location = new Point(12, 12);
			dataGridView.Name = "dataGridView";
			dataGridView.RowHeadersWidth = 51;
			dataGridView.RowTemplate.Height = 29;
			dataGridView.Size = new Size(582, 426);
			dataGridView.TabIndex = 0;
			// 
			// buttonDelete
			// 
			buttonDelete.Location = new Point(638, 35);
			buttonDelete.Name = "buttonDelete";
			buttonDelete.Size = new Size(125, 29);
			buttonDelete.TabIndex = 1;
			buttonDelete.Text = "Удалить";
			buttonDelete.UseVisualStyleBackColor = true;
			buttonDelete.Click += ButtonDelete_Click;
			// 
			// buttonRef
			// 
			buttonRef.Location = new Point(638, 103);
			buttonRef.Name = "buttonRef";
			buttonRef.Size = new Size(125, 29);
			buttonRef.TabIndex = 2;
			buttonRef.Text = "Обновить";
			buttonRef.UseVisualStyleBackColor = true;
			buttonRef.Click += ButtonRef_Click;
			// 
			// FormClients
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(buttonRef);
			Controls.Add(buttonDelete);
			Controls.Add(dataGridView);
			Name = "FormClients";
			Text = "Клиенты";
			Load += FormClients_Load;
			((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private DataGridView dataGridView;
		private Button buttonDelete;
		private Button buttonRef;
	}
}