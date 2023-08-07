using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopDataModels.Models
{
    //интерфейс, отвечающий за продукт
    public interface IManufactureModel : IId
    {
        //наименование изделия
        string ManufactureName { get; }

        //цена изделия
        double Price { get; }

        //словарь, хранящий пары кол-во + компонент и его цена
        Dictionary<int, (IWorkPieceModel, int)> ManufactureWorkPieces { get; }
    }
}
