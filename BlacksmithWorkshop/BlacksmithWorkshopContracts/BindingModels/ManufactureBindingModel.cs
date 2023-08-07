using BlacksmithWorkshopDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopContracts.BindingModels
{
    //реализация сущности "Изделие"
    public class ManufactureBindingModel : IManufactureModel
    {
        public int Id { get; set; }

        public string ManufactureName { get; set; } = string.Empty;

        public double Price { get; set; }

        public Dictionary<int, (IWorkPieceModel, int)> ManufactureWorkPieces { get; set; } = new();
    }
}
