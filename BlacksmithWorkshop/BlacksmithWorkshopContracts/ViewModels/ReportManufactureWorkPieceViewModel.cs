using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopContracts.ViewModels
{
    public class ReportManufactureWorkPieceViewModel
    {
        public string ManufactureName { get; set; } = string.Empty;

        public int TotalCount { get; set; }

        //список кортежей
        public List<(string WorkPiece, int Count)> WorkPieces { get; set; } = new();
    }
}
