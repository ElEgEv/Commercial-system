namespace BlacksmithWorkshop
{
    partial class FormManufactureWorkPiece
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
            this.labelWorkPiece = new System.Windows.Forms.Label();
            this.labelCount = new System.Windows.Forms.Label();
            this.comboBoxWorkPiece = new System.Windows.Forms.ComboBox();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelWorkPiece
            // 
            this.labelWorkPiece.AutoSize = true;
            this.labelWorkPiece.Location = new System.Drawing.Point(31, 33);
            this.labelWorkPiece.Name = "labelWorkPiece";
            this.labelWorkPiece.Size = new System.Drawing.Size(81, 20);
            this.labelWorkPiece.TabIndex = 0;
            this.labelWorkPiece.Text = "Заготовка:";
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(31, 79);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(93, 20);
            this.labelCount.TabIndex = 1;
            this.labelCount.Text = "Количество:";
            // 
            // comboBoxWorkPiece
            // 
            this.comboBoxWorkPiece.FormattingEnabled = true;
            this.comboBoxWorkPiece.Location = new System.Drawing.Point(156, 30);
            this.comboBoxWorkPiece.Name = "comboBoxWorkPiece";
            this.comboBoxWorkPiece.Size = new System.Drawing.Size(320, 28);
            this.comboBoxWorkPiece.TabIndex = 2;
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(156, 76);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(320, 27);
            this.textBoxCount.TabIndex = 3;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(235, 118);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(94, 29);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(353, 118);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(94, 29);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // FormManufactureWorkPiece
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 168);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.comboBoxWorkPiece);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.labelWorkPiece);
            this.Name = "FormManufactureWorkPiece";
            this.Text = "Заготовки для изделия";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelWorkPiece;
        private Label labelCount;
        private ComboBox comboBoxWorkPiece;
        private TextBox textBoxCount;
        private Button buttonSave;
        private Button buttonCancel;
    }
}