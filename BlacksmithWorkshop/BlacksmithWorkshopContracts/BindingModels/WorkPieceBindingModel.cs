using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlacksmithWorkshopDataModels.Models;

namespace BlacksmithWorkshopContracts.BindingModels
{
    //реализация сущности "Компонент"
    public class WorkPieceBindingModel : IWorkPieceModel
    {
        public int Id { get; set; }

        public string WorkPieceName { get; set; } = string.Empty;

        public double Cost { get; set; }
    }
}
