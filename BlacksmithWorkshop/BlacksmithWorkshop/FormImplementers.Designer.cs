namespace BlacksmithWorkshop
{
	partial class FormImplementers
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
			buttonCreate = new Button();
			buttonChange = new Button();
			buttonDelete = new Button();
			buttonUpdate = new Button();
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
			dataGridView.Size = new Size(768, 426);
			dataGridView.TabIndex = 0;
			// 
			// buttonCreate
			// 
			buttonCreate.Location = new Point(805, 22);
			buttonCreate.Name = "buttonCreate";
			buttonCreate.Size = new Size(160, 29);
			buttonCreate.TabIndex = 1;
			buttonCreate.Text = "Создать";
			buttonCreate.UseVisualStyleBackColor = true;
			buttonCreate.Click += ButtonCreate_Click;
			// 
			// buttonChange
			// 
			buttonChange.Location = new Point(805, 90);
			buttonChange.Name = "buttonChange";
			buttonChange.Size = new Size(160, 29);
			buttonChange.TabIndex = 2;
			buttonChange.Text = "Изменить";
			buttonChange.UseVisualStyleBackColor = true;
			buttonChange.Click += ButtonChange_Click;
			// 
			// buttonDelete
			// 
			buttonDelete.Location = new Point(805, 153);
			buttonDelete.Name = "buttonDelete";
			buttonDelete.Size = new Size(160, 29);
			buttonDelete.TabIndex = 3;
			buttonDelete.Text = "Удалить";
			buttonDelete.UseVisualStyleBackColor = true;
			buttonDelete.Click += ButtonDelete_Click;
			// 
			// buttonUpdate
			// 
			buttonUpdate.Location = new Point(805, 218);
			buttonUpdate.Name = "buttonUpdate";
			buttonUpdate.Size = new Size(160, 29);
			buttonUpdate.TabIndex = 4;
			buttonUpdate.Text = "Обновить";
			buttonUpdate.UseVisualStyleBackColor = true;
			buttonUpdate.Click += ButtonUpdate_Click;
			// 
			// FormImplementers
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(991, 450);
			Controls.Add(buttonUpdate);
			Controls.Add(buttonDelete);
			Controls.Add(buttonChange);
			Controls.Add(buttonCreate);
			Controls.Add(dataGridView);
			Name = "FormImplementers";
			Text = "Исполнители";
			Load += FormImplementers_Load;
			((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private DataGridView dataGridView;
		private Button buttonCreate;
		private Button buttonChange;
		private Button buttonDelete;
		private Button buttonUpdate;
	}
}