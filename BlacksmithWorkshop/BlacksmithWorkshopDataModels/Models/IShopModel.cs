using BlacksmithWorkshopDataModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopDataModels.Models
{
    //интерфес сущности "Магазин"
    public interface IShopModel : IId
    {
        //название магазина
        string ShopName { get; }

        //адрес магазина
        string Address { get; }

        //дата открытия магазина
        DateTime DateOpen { get; }

        //максимальное кол-во изделий в магазине
        int MaxCountManufactures { get; }

        //изделия в магазине
        Dictionary<int, (IManufactureModel, int)> ShopManufactures { get; }
    }
}
