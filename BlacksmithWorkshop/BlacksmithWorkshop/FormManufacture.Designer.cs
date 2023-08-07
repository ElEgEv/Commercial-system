namespace BlacksmithWorkshop
{
    partial class FormManufacture
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
            this.labelCost = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.groupBoxWorkPiece = new System.Windows.Forms.GroupBox();
            this.buttonRef = new System.Windows.Forms.Button();
            this.buttonDel = new System.Windows.Forms.Button();
            this.buttonUpd = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.ColumnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxWorkPiece.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(23, 30);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(80, 20);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Название:";
            // 
            // labelCost
            // 
            this.labelCost.AutoSize = true;
            this.labelCost.Location = new System.Drawing.Point(23, 84);
            this.labelCost.Name = "labelCost";
            this.labelCost.Size = new System.Drawing.Size(86, 20);
            this.labelCost.TabIndex = 1;
            this.labelCost.Text = "Стоимость:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(133, 27);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(332, 27);
            this.textBoxName.TabIndex = 2;
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(133, 81);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(196, 27);
            this.textBoxPrice.TabIndex = 3;
            // 
            // groupBoxWorkPiece
            // 
            this.groupBoxWorkPiece.Controls.Add(this.buttonRef);
            this.groupBoxWorkPiece.Controls.Add(this.buttonDel);
            this.groupBoxWorkPiece.Controls.Add(this.buttonUpd);
            this.groupBoxWorkPiece.Controls.Add(this.buttonAdd);
            this.groupBoxWorkPiece.Controls.Add(this.dataGridView);
            this.groupBoxWorkPiece.Location = new System.Drawing.Point(23, 126);
            this.groupBoxWorkPiece.Name = "groupBoxWorkPiece";
            this.groupBoxWorkPiece.Size = new System.Drawing.Size(567, 300);
            this.groupBoxWorkPiece.TabIndex = 4;
            this.groupBoxWorkPiece.TabStop = false;
            this.groupBoxWorkPiece.Text = "Заготовки";
            // 
            // buttonRef
            // 
            this.buttonRef.Location = new System.Drawing.Point(454, 196);
            this.buttonRef.Name = "buttonRef";
            this.buttonRef.Size = new System.Drawing.Size(94, 29);
            this.buttonRef.TabIndex = 4;
            this.buttonRef.Text = "Обновить";
            this.buttonRef.UseVisualStyleBackColor = true;
            this.buttonRef.Click += new System.EventHandler(this.ButtonRef_Click);
            // 
            // buttonDel
            // 
            this.buttonDel.Location = new System.Drawing.Point(454, 145);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(94, 29);
            this.buttonDel.TabIndex = 3;
            this.buttonDel.Text = "Удалить";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.ButtonDel_Click);
            // 
            // buttonUpd
            // 
            this.buttonUpd.Location = new System.Drawing.Point(454, 95);
            this.buttonUpd.Name = "buttonUpd";
            this.buttonUpd.Size = new System.Drawing.Size(94, 29);
            this.buttonUpd.TabIndex = 2;
            this.buttonUpd.Text = "Изменить";
            this.buttonUpd.UseVisualStyleBackColor = true;
            this.buttonUpd.Click += new System.EventHandler(this.ButtonUpd_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(454, 43);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(94, 29);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnID,
            this.ColumnName,
            this.ColumnPrice});
            this.dataGridView.Location = new System.Drawing.Point(6, 26);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 29;
            this.dataGridView.Size = new System.Drawing.Size(436, 268);
            this.dataGridView.TabIndex = 0;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(340, 448);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(95, 29);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(458, 448);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(94, 29);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // ColumnID
            // 
            this.ColumnID.HeaderText = "Id";
            this.ColumnID.MinimumWidth = 6;
            this.ColumnID.Name = "ColumnID";
            this.ColumnID.Visible = false;
            this.ColumnID.Width = 125;
            // 
            // ColumnName
            // 
            this.ColumnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnName.HeaderText = "Название";
            this.ColumnName.MinimumWidth = 6;
            this.ColumnName.Name = "ColumnName";
            // 
            // ColumnPrice
            // 
            this.ColumnPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnPrice.HeaderText = "Количество";
            this.ColumnPrice.MinimumWidth = 6;
            this.ColumnPrice.Name = "ColumnPrice";
            // 
            // FormManufacture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 500);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBoxWorkPiece);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelCost);
            this.Controls.Add(this.labelName);
            this.Name = "FormManufacture";
            this.Text = "Изделие";
            this.Load += new System.EventHandler(this.FormManufacture_Load);
            this.groupBoxWorkPiece.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelName;
        private Label labelCost;
        private TextBox textBoxName;
        private TextBox textBoxPrice;
        private GroupBox groupBoxWorkPiece;
        private Button buttonRef;
        private Button buttonDel;
        private Button buttonUpd;
        private Button buttonAdd;
        private DataGridView dataGridView;
        private Button buttonSave;
        private Button buttonCancel;
        private DataGridViewTextBoxColumn ColumnID;
        private DataGridViewTextBoxColumn ColumnName;
        private DataGridViewTextBoxColumn ColumnPrice;
    }
}