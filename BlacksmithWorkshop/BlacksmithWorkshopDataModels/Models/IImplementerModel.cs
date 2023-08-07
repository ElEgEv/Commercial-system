using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopDataModels.Models
{
	//модель исполнителя
	public interface IImplementerModel : IId
	{
		string ImplementerFIO { get; }

		string Password { get; }

		int WorkExperience { get; }

		int Qualification { get; }
	}

}
