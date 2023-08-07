namespace BlacksmithWorkshop
{
	partial class FormImplementer
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
			labelFIO = new Label();
			labelPassword = new Label();
			labelWorkExperience = new Label();
			labelQualification = new Label();
			textBoxImplementerFIO = new TextBox();
			textBoxPassword = new TextBox();
			textBoxWorkExperience = new TextBox();
			textBoxQualification = new TextBox();
			buttonSave = new Button();
			buttonCancel = new Button();
			SuspendLayout();
			// 
			// labelFIO
			// 
			labelFIO.AutoSize = true;
			labelFIO.Location = new Point(38, 27);
			labelFIO.Name = "labelFIO";
			labelFIO.Size = new Size(45, 20);
			labelFIO.TabIndex = 0;
			labelFIO.Text = "ФИО:";
			// 
			// labelPassword
			// 
			labelPassword.AutoSize = true;
			labelPassword.Location = new Point(38, 79);
			labelPassword.Name = "labelPassword";
			labelPassword.Size = new Size(65, 20);
			labelPassword.TabIndex = 1;
			labelPassword.Text = "Пароль:";
			// 
			// labelWorkExperience
			// 
			labelWorkExperience.AutoSize = true;
			labelWorkExperience.Location = new Point(38, 136);
			labelWorkExperience.Name = "labelWorkExperience";
			labelWorkExperience.Size = new Size(102, 20);
			labelWorkExperience.TabIndex = 2;
			labelWorkExperience.Text = "Стаж работы:";
			// 
			// labelQualification
			// 
			labelQualification.AutoSize = true;
			labelQualification.Location = new Point(319, 136);
			labelQualification.Name = "labelQualification";
			labelQualification.Size = new Size(114, 20);
			labelQualification.TabIndex = 3;
			labelQualification.Text = "Квалификация:";
			// 
			// textBoxImplementerFIO
			// 
			textBoxImplementerFIO.Location = new Point(160, 24);
			textBoxImplementerFIO.Name = "textBoxImplementerFIO";
			textBoxImplementerFIO.Size = new Size(436, 27);
			textBoxImplementerFIO.TabIndex = 4;
			// 
			// textBoxPassword
			// 
			textBoxPassword.Location = new Point(160, 76);
			textBoxPassword.Name = "textBoxPassword";
			textBoxPassword.Size = new Size(436, 27);
			textBoxPassword.TabIndex = 5;
			// 
			// textBoxWorkExperience
			// 
			textBoxWorkExperience.Location = new Point(160, 133);
			textBoxWorkExperience.Name = "textBoxWorkExperience";
			textBoxWorkExperience.Size = new Size(126, 27);
			textBoxWorkExperience.TabIndex = 6;
			// 
			// textBoxQualification
			// 
			textBoxQualification.Location = new Point(444, 133);
			textBoxQualification.Name = "textBoxQualification";
			textBoxQualification.Size = new Size(152, 27);
			textBoxQualification.TabIndex = 7;
			// 
			// buttonSave
			// 
			buttonSave.Location = new Point(387, 178);
			buttonSave.Name = "buttonSave";
			buttonSave.Size = new Size(94, 29);
			buttonSave.TabIndex = 8;
			buttonSave.Text = "Сохранить";
			buttonSave.UseVisualStyleBackColor = true;
			buttonSave.Click += ButtonSave_Click;
			// 
			// buttonCancel
			// 
			buttonCancel.Location = new Point(502, 178);
			buttonCancel.Name = "buttonCancel";
			buttonCancel.Size = new Size(94, 29);
			buttonCancel.TabIndex = 9;
			buttonCancel.Text = "Отмена";
			buttonCancel.UseVisualStyleBackColor = true;
			buttonCancel.Click += ButtonCancel_Click;
			// 
			// FormImplementer
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(662, 224);
			Controls.Add(buttonCancel);
			Controls.Add(buttonSave);
			Controls.Add(textBoxQualification);
			Controls.Add(textBoxWorkExperience);
			Controls.Add(textBoxPassword);
			Controls.Add(textBoxImplementerFIO);
			Controls.Add(labelQualification);
			Controls.Add(labelWorkExperience);
			Controls.Add(labelPassword);
			Controls.Add(labelFIO);
			Name = "FormImplementer";
			Text = "Исполнитель";
			Load += FormImplementer_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label labelFIO;
		private Label labelPassword;
		private Label labelWorkExperience;
		private Label labelQualification;
		private TextBox textBoxImplementerFIO;
		private TextBox textBoxPassword;
		private TextBox textBoxWorkExperience;
		private TextBox textBoxQualification;
		private Button buttonSave;
		private Button buttonCancel;
	}
}