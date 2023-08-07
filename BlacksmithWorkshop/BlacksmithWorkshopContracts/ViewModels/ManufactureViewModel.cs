using BlacksmithWorkshopContracts.Attributes;
using BlacksmithWorkshopDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopContracts.ViewModels
{
    //класс для отображения пользователю информаци о продуктах (изделиях)
    public class ManufactureViewModel : IManufactureModel
    {
        [Column(visible: false)]
        public int Id { get; set; }

        [Column(title: "Навание изделия", gridViewAutoSize: GridViewAutoSize.Fill, isUseAutoSize: true)]
        public string ManufactureName { get; set; } = string.Empty;

        [Column(title: "Цена", width: 150, format: "0.00")]
        public double Price { get; set; }

        [Column(visible: false)]
        public Dictionary<int, (IWorkPieceModel, int)> ManufactureWorkPieces { get; set; } = new();
    }
}
