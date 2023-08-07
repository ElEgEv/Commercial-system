using BlacksmithWorkshopDataModels.Models;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlacksmithWorkshopContracts.Attributes;

namespace BlacksmithWorkshopContracts.ViewModels
{
    //класс для отображения пользователю данных о заготовких (заготовках)
    public  class WorkPieceViewModel : IWorkPieceModel
    {
        [Column(visible: false)]
        public int Id { get; set; }

        [Column(title: "Название заготовки", width: 150, format: "0.00")]
        public string WorkPieceName { get; set; } = string.Empty;

        [Column(title: "Цена", width: 150)]
        public double Cost { get; set; }
    }
}
