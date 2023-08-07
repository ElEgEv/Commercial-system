namespace BlacksmithWorkshop
{
    partial class FormMails
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
            buttonForward = new Button();
            buttonBack = new Button();
            buttonAnswer = new Button();
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
            dataGridView.Size = new Size(781, 393);
            dataGridView.TabIndex = 0;
            // 
            // buttonForward
            // 
            buttonForward.Location = new Point(155, 416);
            buttonForward.Name = "buttonForward";
            buttonForward.Size = new Size(175, 29);
            buttonForward.TabIndex = 1;
            buttonForward.Text = "Вперёд";
            buttonForward.UseVisualStyleBackColor = true;
            buttonForward.Click += ButtonForward_Click;
            // 
            // buttonBack
            // 
            buttonBack.Location = new Point(468, 416);
            buttonBack.Name = "buttonBack";
            buttonBack.Size = new Size(173, 29);
            buttonBack.TabIndex = 2;
            buttonBack.Text = "Назад";
            buttonBack.UseVisualStyleBackColor = true;
            buttonBack.Click += ButtonBack_Click;
            // 
            // buttonAnswer
            // 
            buttonAnswer.Location = new Point(806, 34);
            buttonAnswer.Name = "buttonAnswer";
            buttonAnswer.Size = new Size(136, 29);
            buttonAnswer.TabIndex = 3;
            buttonAnswer.Text = "Ответить";
            buttonAnswer.UseVisualStyleBackColor = true;
            buttonAnswer.Click += ButtonAnswer_Click;
            // 
            // FormMails
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(963, 457);
            Controls.Add(buttonAnswer);
            Controls.Add(buttonBack);
            Controls.Add(buttonForward);
            Controls.Add(dataGridView);
            Name = "FormMails";
            Text = "Письма";
            Load += FormMails_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView;
        private Button buttonForward;
        private Button buttonBack;
        private Button buttonAnswer;
    }
}