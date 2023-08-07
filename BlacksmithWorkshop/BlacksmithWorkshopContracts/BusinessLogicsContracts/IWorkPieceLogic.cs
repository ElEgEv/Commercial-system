using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.SearchModels;
using BlacksmithWorkshopContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopContracts.BusinessLogicsContracts
{
    //бизнес-логика для компонентов
    public interface IWorkPieceLogic
    {
        List<WorkPieceViewModel>? ReadList(WorkPieceSearchModel? model);

        WorkPieceViewModel? ReadElement(WorkPieceSearchModel model);

        bool Create(WorkPieceBindingModel model);

        bool Update(WorkPieceBindingModel model);

        bool Delete(WorkPieceBindingModel model);
    }
}
