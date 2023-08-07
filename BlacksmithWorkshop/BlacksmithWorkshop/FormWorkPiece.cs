using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.BusinessLogicsContracts;
using BlacksmithWorkshopContracts.SearchModels;
using Microsoft.Extensions.Logging;

namespace BlacksmithWorkshop
{
    //форма "Заготовка"
    public partial class FormWorkPiece : Form
    {
        private readonly ILogger _logger;

        private readonly IWorkPieceLogic _logic;

        private int? _id;

        public int Id { set { _id = value; } }

        //конструктор
        public FormWorkPiece(ILogger<FormWorkPiece> logger, IWorkPieceLogic logic)
        {
            InitializeComponent();

            _logger = logger;
            _logic = logic;
        }

        //при загрузке формы
        private void FormWorkPiece_Load(object sender, EventArgs e)
        {
            //проверка на заполнение поля id. Если оно заполнено, то пробуем получить запись и выести её на экран
            if (_id.HasValue)
            {
                try
                {
                    _logger.LogInformation("Получение заготовки");

                    var view = _logic.ReadElement(new WorkPieceSearchModel { Id = _id.Value });

                    if(view != null)
                    {
                        textBoxName.Text = view.WorkPieceName;
                        textBoxCost.Text = view.Cost.ToString();
                    }
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex, "Ошибка получения компонента");

                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //обработка нажатия кнопки Сохранить. Либо пеердаёт данные для создания заготовки, либо её обновления
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            //проверка на заполнение поля с названием заготовки
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _logger.LogInformation("Сохранение заготовки");

            try
            {
                var model = new WorkPieceBindingModel
                {
                    Id = _id ?? 0,
                    WorkPieceName = textBoxName.Text,
                    Cost = Convert.ToDouble(textBoxCost.Text)
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
            catch(Exception ex )
            {
                _logger.LogError(ex, "Ошибка сохранения компонента");

                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //обработка нажатия кнопки Отмена. При нажатии просто закрываем форму
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}