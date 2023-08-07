using BlacksmithWorkshopContracts.BusinessLogicsContracts;
using BlacksmithWorkshopContracts.ViewModels;
using BlacksmithWorkshopDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlacksmithWorkshop
{
    public partial class FormManufactureWorkPiece : Form
    {
        private readonly List<WorkPieceViewModel>? _list;

        public int Id { get { return Convert.ToInt32(comboBoxWorkPiece.SelectedValue); } 
            set { comboBoxWorkPiece.SelectedValue = value; } }

        public IWorkPieceModel? WorkPieceModel
        {
            get
            {
                if(_list == null)
                {
                    return null;
                }

                foreach(var elem in _list)
                {
                    if(elem.Id == Id)
                    {
                        return elem;
                    }
                }

                return null;
            }
        }

        public int Count { get { return Convert.ToInt32(textBoxCount.Text); } set {
                textBoxCount.Text = value.ToString(); } }

        public FormManufactureWorkPiece(IWorkPieceLogic logic)
        {
            InitializeComponent();

            _list = logic.ReadList(null);

            if(_list != null)
            {
                comboBoxWorkPiece.DisplayMember = "WorkPieceName";
                comboBoxWorkPiece.ValueMember = "Id";
                comboBoxWorkPiece.DataSource = _list;
                comboBoxWorkPiece.SelectedItem = null;
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                return;
            }

            if (comboBoxWorkPiece.SelectedValue == null)
            {
                MessageBox.Show("Выберите заготовку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                return;
            }

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
