using BlacksmithWorkshopBusinessLogic.MailWorker;
using BlacksmithWorkshopContracts.BusinessLogicsContracts;
using BlacksmithWorkshopContracts.SearchModels;
using BlacksmithWorkshopContracts.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlacksmithWorkshop
{
    public partial class FormAnswerMail : Form
    {
        private readonly ILogger _logger;

        private readonly IMessageInfoLogic _logic;

        private readonly AbstractMailWorker _mailWorker;

        private MessageInfoViewModel _message;

        public string MessageId { get; set; } = string.Empty;

        public FormAnswerMail(ILogger<FormAnswerMail> logger, AbstractMailWorker mailWorker, IMessageInfoLogic logic)
        {
            InitializeComponent();

            _logger = logger;
            _mailWorker = mailWorker;
            _logic = logic;
        }

        private void FormAnswerMail_Load(object sender, EventArgs e)
        {
            try
            {
                _logger.LogInformation("Получение письма");

                _message = _logic.ReadElement(new MessageInfoSearchModel { MessageId = MessageId });

                if (_message != null)
                {
                    Text += $"для {_message.SenderName}";

                    textBoxHead.Text = _message.Subject;

                    textBoxBody.Text = _message.Body;
                }

                if (_message.IsRead is false)
                {
                    _logic.Update(new() { MessageId = MessageId, IsRead = true, Answer = _message.Answer });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка получения письма");

                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            //отправка письма с ответом
            _mailWorker.MailSendAsync(new()
            {
                MailAddress = _message.SenderName,
                Subject = _message.Subject,
                Text = textBoxAnswer.Text,
            });

            _logic.Update(new()
            {
                MessageId = MessageId,
                Answer = textBoxAnswer.Text,
                IsRead = true,
            });

            MessageBox.Show("Успешная отправка письма", "Отправка письма", MessageBoxButtons.OK);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
