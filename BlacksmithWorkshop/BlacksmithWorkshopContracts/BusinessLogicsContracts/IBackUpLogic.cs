using BlacksmithWorkshopContracts.BindingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopContracts.BusinessLogicsContracts
{
    //интерфейс создания бекапа
    public interface IBackUpLogic
    {
        //путь и имя файла для архивации
        void CreateBackUp(BackUpSaveBinidngModel model);
    }
}
