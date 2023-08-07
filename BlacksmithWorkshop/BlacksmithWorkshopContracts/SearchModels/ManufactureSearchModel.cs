using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopContracts.SearchModels
{
    //модель для поиска заготовки "Продукт" (она же изделие)
    public class ManufactureSearchModel
    {
        //для поиска по идентификатору
        public int? Id { get; set; }

        //для поиска по названию
        public string? ManufactureName { get; set; }
    }
}
