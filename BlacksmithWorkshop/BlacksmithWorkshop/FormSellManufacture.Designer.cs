namespace BlacksmithWorkshop
{
    partial class FormSellManufacture
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
            this.labelManufacture = new System.Windows.Forms.Label();
            this.labelCount = new System.Windows.Forms.Label();
            this.comboBoxManufacture = new System.Windows.Forms.ComboBox();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelManufacture
            // 
            this.labelManufacture.AutoSize = true;
            this.labelManufacture.Location = new System.Drawing.Point(32, 32);
            this.labelManufacture.Name = "labelManufacture";
            this.labelManufacture.Size = new System.Drawing.Size(71, 20);
            this.labelManufacture.TabIndex = 0;
            this.labelManufacture.Text = "Изделие:";
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(34, 85);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(93, 20);
            this.labelCount.TabIndex = 1;
            this.labelCount.Text = "Количество:";
            // 
            // comboBoxManufacture
            // 
            this.comboBoxManufacture.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxManufacture.FormattingEnabled = true;
            this.comboBoxManufacture.Location = new System.Drawing.Point(170, 32);
            this.comboBoxManufacture.Name = "comboBoxManufacture";
            this.comboBoxManufacture.Size = new System.Drawing.Size(262, 28);
            this.comboBoxManufacture.TabIndex = 3;
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(170, 85);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(262, 27);
            this.textBoxCount.TabIndex = 4;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(239, 141);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(94, 29);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(339, 141);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(94, 29);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // FormSellManufacture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 180);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.comboBoxManufacture);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.labelManufacture);
            this.Name = "FormSellManufacture";
            this.Text = "Продажа изделий";
            this.Load += new System.EventHandler(this.FormSellManufacture_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelManufacture;
        private Label labelCount;
        private ComboBox comboBoxManufacture;
        private TextBox textBoxCount;
        private Button buttonSave;
        private Button buttonCancel;
    }
}