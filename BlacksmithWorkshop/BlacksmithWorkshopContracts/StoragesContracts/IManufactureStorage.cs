using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.SearchModels;
using BlacksmithWorkshopContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopContracts.StoragesContracts
{
    //класс для хранилища продуктов (изделий)
    public interface IManufactureStorage
    {
        List<ManufactureViewModel> GetFullList();

        List<ManufactureViewModel> GetFilteredList(ManufactureSearchModel model);

        ManufactureViewModel? GetElement(ManufactureSearchModel model);

        ManufactureViewModel? Insert(ManufactureBindingModel model);

        ManufactureViewModel? Update(ManufactureBindingModel model);

        ManufactureViewModel? Delete(ManufactureBindingModel model);
    }
}
