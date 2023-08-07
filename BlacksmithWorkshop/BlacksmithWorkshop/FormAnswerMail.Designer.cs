namespace BlacksmithWorkshop
{
    partial class FormAnswerMail
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
            buttonSave = new Button();
            buttonCancel = new Button();
            textBoxHead = new TextBox();
            textBoxBody = new TextBox();
            labelHead = new Label();
            labelBody = new Label();
            labelAnswer = new Label();
            textBoxAnswer = new TextBox();
            SuspendLayout();
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(203, 227);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(125, 29);
            buttonSave.TabIndex = 0;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += ButtonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(350, 227);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(123, 29);
            buttonCancel.TabIndex = 1;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += ButtonCancel_Click;
            // 
            // textBoxHead
            // 
            textBoxHead.Location = new Point(151, 34);
            textBoxHead.Name = "textBoxHead";
            textBoxHead.Size = new Size(322, 27);
            textBoxHead.TabIndex = 2;
            // 
            // textBoxBody
            // 
            textBoxBody.Location = new Point(151, 98);
            textBoxBody.Name = "textBoxBody";
            textBoxBody.Size = new Size(322, 27);
            textBoxBody.TabIndex = 3;
            // 
            // labelHead
            // 
            labelHead.AutoSize = true;
            labelHead.Location = new Point(30, 37);
            labelHead.Name = "labelHead";
            labelHead.Size = new Size(84, 20);
            labelHead.TabIndex = 4;
            labelHead.Text = "Заголовок:";
            // 
            // labelBody
            // 
            labelBody.AutoSize = true;
            labelBody.Location = new Point(30, 101);
            labelBody.Name = "labelBody";
            labelBody.Size = new Size(94, 20);
            labelBody.TabIndex = 5;
            labelBody.Text = "Сообщение:";
            // 
            // labelAnswer
            // 
            labelAnswer.AutoSize = true;
            labelAnswer.Location = new Point(30, 163);
            labelAnswer.Name = "labelAnswer";
            labelAnswer.Size = new Size(51, 20);
            labelAnswer.TabIndex = 6;
            labelAnswer.Text = "Ответ:";
            // 
            // textBoxAnswer
            // 
            textBoxAnswer.Location = new Point(151, 160);
            textBoxAnswer.Name = "textBoxAnswer";
            textBoxAnswer.Size = new Size(322, 27);
            textBoxAnswer.TabIndex = 7;
            // 
            // FormAnswerMail
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(512, 284);
            Controls.Add(textBoxAnswer);
            Controls.Add(labelAnswer);
            Controls.Add(labelBody);
            Controls.Add(labelHead);
            Controls.Add(textBoxBody);
            Controls.Add(textBoxHead);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Name = "FormAnswerMail";
            Text = "Просмотр письма";
            Load += FormAnswerMail_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonSave;
        private Button buttonCancel;
        private TextBox textBoxHead;
        private TextBox textBoxBody;
        private Label labelHead;
        private Label labelBody;
        private Label labelAnswer;
        private TextBox textBoxAnswer;
    }
}