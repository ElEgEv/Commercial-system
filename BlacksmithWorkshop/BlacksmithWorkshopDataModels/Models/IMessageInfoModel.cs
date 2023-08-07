using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopDataModels.Models
{
	public interface IMessageInfoModel : IId
	{
		string MessageId { get; }

		int? ClientId { get; }

		string SenderName { get; }

		DateTime DateDelivery { get; }

		string Subject { get; }

		string Body { get; }

		public bool IsRead { get; }

		public string Answer { get; }
	}
}
