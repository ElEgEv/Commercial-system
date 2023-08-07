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
	public interface IImplementerLogic
	{
		List<ImplementerViewModel>? ReadList(ImplementerSearchModel? model);

		ImplementerViewModel? ReadElement(ImplementerSearchModel model);

		bool Create(ImplementerBindingModel model);

		bool Update(ImplementerBindingModel model);

		bool Delete(ImplementerBindingModel model);
	}
}
