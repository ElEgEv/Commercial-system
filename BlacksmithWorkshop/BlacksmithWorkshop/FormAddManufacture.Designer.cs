namespace BlacksmithWorkshop
{
    partial class FormAddManufacture
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
            this.labelIceCream = new System.Windows.Forms.Label();
            this.labelCount = new System.Windows.Forms.Label();
            this.labelShop = new System.Windows.Forms.Label();
            this.comboBoxManufacture = new System.Windows.Forms.ComboBox();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.comboBoxShop = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labelIceCream
            // 
            this.labelIceCream.AutoSize = true;
            this.labelIceCream.Location = new System.Drawing.Point(28, 58);
            this.labelIceCream.Name = "labelIceCream";
            this.labelIceCream.Size = new System.Drawing.Size(56, 15);
            this.labelIceCream.TabIndex = 0;
            this.labelIceCream.Text = "Изделие:";
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(28, 91);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(75, 15);
            this.labelCount.TabIndex = 1;
            this.labelCount.Text = "Количество:";
            // 
            // labelShop
            // 
            this.labelShop.AutoSize = true;
            this.labelShop.Location = new System.Drawing.Point(28, 23);
            this.labelShop.Name = "labelShop";
            this.labelShop.Size = new System.Drawing.Size(57, 15);
            this.labelShop.TabIndex = 2;
            this.labelShop.Text = "Магазин:";
            // 
            // comboBoxManufacture
            // 
            this.comboBoxManufacture.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxManufacture.FormattingEnabled = true;
            this.comboBoxManufacture.Location = new System.Drawing.Point(149, 55);
            this.comboBoxManufacture.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxManufacture.Name = "comboBoxManufacture";
            this.comboBoxManufacture.Size = new System.Drawing.Size(230, 23);
            this.comboBoxManufacture.TabIndex = 3;
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(149, 88);
            this.textBoxCount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(230, 23);
            this.textBoxCount.TabIndex = 4;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(209, 123);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(82, 22);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(297, 123);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(82, 22);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // comboBoxShop
            // 
            this.comboBoxShop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxShop.FormattingEnabled = true;
            this.comboBoxShop.Location = new System.Drawing.Point(149, 23);
            this.comboBoxShop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxShop.Name = "comboBoxShop";
            this.comboBoxShop.Size = new System.Drawing.Size(230, 23);
            this.comboBoxShop.TabIndex = 8;
            // 
            // FormAddManufacture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 159);
            this.Controls.Add(this.comboBoxShop);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.comboBoxManufacture);
            this.Controls.Add(this.labelShop);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.labelIceCream);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormAddManufacture";
            this.Text = "Пополнение магазина";
            this.Load += new System.EventHandler(this.FormAddManufacture_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelIceCream;
        private Label labelCount;
        private Label labelShop;
        private ComboBox comboBoxManufacture;
        private TextBox textBoxCount;
        private Button buttonSave;
        private Button buttonCancel;
        private ComboBox comboBoxShop;
    }
}