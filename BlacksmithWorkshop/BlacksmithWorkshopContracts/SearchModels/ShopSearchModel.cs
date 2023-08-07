using BlacksmithWorkshopDataModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopContracts.SearchModels
{
    public class ShopSearchModel
    {
        //для поиска по идентификатору
        public int? Id { get; set; }

        //для поиска по названию
        public string? ShopName { get; set; }
    }
}
