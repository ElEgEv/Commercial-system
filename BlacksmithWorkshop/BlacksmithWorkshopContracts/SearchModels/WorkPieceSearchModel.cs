using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopContracts.SearchModels
{
    //модель для поиска сущности "Компонент" (она же заготовка)
    public class WorkPieceSearchModel
    {
        //для поиска по идентификатору
        public int? Id { get; set; }

        //для поиска по названию
        public string? WorkPieceName { get; set; }
    }

}
