using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopDataModels.Models
{
    //интерфейс, отвечающий за компоненты
    public interface IWorkPieceModel : IId
    {
        //название составляющей (изделие состоит из составляющих)
        string WorkPieceName { get; }

        //цена составляющей
        double Cost { get; }
    }
}
