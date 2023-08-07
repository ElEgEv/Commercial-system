using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.BusinessLogicsContracts;
using BlacksmithWorkshopContracts.SearchModels;
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
	public partial class FormImplementer : Form
	{
		private readonly ILogger _logger;

		private readonly IImplementerLogic _logic;

		private int? _id;

		public int Id { set { _id = value; } }

		//конструктор
		public FormImplementer(ILogger<FormImplementer> logger, IImplementerLogic logic)
		{
			InitializeComponent();

			_logger = logger;
			_logic = logic;
		}

		//при загрузке формы
		private void FormImplementer_Load(object sender, EventArgs e)
		{
			//проверка на заполнение поля id. Если оно заполнено, то пробуем получить запись и выести её на экран
			if (_id.HasValue)
			{
				try
				{
					_logger.LogInformation("Получение исполнителя");

					var view = _logic.ReadElement(new ImplementerSearchModel { Id = _id.Value });

					if (view != null)
					{
						textBoxImplementerFIO.Text = view.ImplementerFIO;
						textBoxPassword.Text = view.Password;
						textBoxWorkExperience.Text = view.WorkExperience.ToString();
						textBoxQualification.Text = view.Qualification.ToString();
					}
				}
				catch (Exception ex)
				{
					_logger.LogError(ex, "Ошибка получения исполнителя");

					MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void ButtonSave_Click(object sender, EventArgs e)
		{
			//проверка на заполнение поля с ФИО исполнителя
			if (string.IsNullOrEmpty(textBoxImplementerFIO.Text))
			{
				MessageBox.Show("Заполните ФИО", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return;
			}

			//проверка на заполнение поля с паролем
			if (string.IsNullOrEmpty(textBoxPassword.Text))
			{
				MessageBox.Show("Введите пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return;
			}

			//проверка на заполнение поля со стажем
			if (string.IsNullOrEmpty(textBoxWorkExperience.Text))
			{
				MessageBox.Show("Введите ваш стаж", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return;
			}

			//проверка на заполнение поля с квалификацией
			if (string.IsNullOrEmpty(textBoxQualification.Text))
			{
				MessageBox.Show("Введите свою квалификацию", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return;
			}

			_logger.LogInformation("Сохранение исполнителя");

			try
			{
				var model = new ImplementerBindingModel
				{
					Id = _id ?? 0,
					ImplementerFIO = textBoxImplementerFIO.Text,
					Password = textBoxPassword.Text,
					WorkExperience = Convert.ToInt16(textBoxWorkExperience.Text),
					Qualification = Convert.ToInt16(textBoxQualification.Text)
				};

				var operationResult = _id.HasValue ? _logic.Update(model) : _logic.Create(model);

				if (!operationResult)
				{
					throw new Exception("Ошибка при сохранеии. Дополнительная информация в логах.");
				}

				MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
				DialogResult = DialogResult.OK;

				Close();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка сохранения исполнителя");

				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void ButtonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}
