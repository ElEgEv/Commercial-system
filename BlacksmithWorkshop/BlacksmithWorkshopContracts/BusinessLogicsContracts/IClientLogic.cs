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
    public interface IClientLogic
    {
        List<ClientViewModel>? ReadList(ClientSearchModel? model);

        ClientViewModel? ReadElement(ClientSearchModel model);

        bool Create(ClientBindingModel model);

        bool Update(ClientBindingModel model);

        bool Delete(ClientBindingModel model);
    }
}
