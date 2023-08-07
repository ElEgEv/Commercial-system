using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.SearchModels;
using BlacksmithWorkshopContracts.StoragesContracts;
using BlacksmithWorkshopContracts.ViewModels;
using BlacksmithWorkshopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopFileImplement.Implements
{
	public class MessageInfoStorage : IMessageInfoStorage
	{
		private readonly DataFileSingleton source;

		public MessageInfoStorage()
		{
			source = DataFileSingleton.GetInstance();
		}

		public List<MessageInfoViewModel> GetFullList()
		{
			return source.Messages.Select(x => GetViewModel(x)).ToList();
		}

		public List<MessageInfoViewModel> GetFilteredList(MessageInfoSearchModel model)
		{
			if (!model.ClientId.HasValue)
			{
				return source.Messages
					.Select(x => GetViewModel(x))
					.ToList();
			}

			return source.Messages
				.Where(x => x.ClientId == model.ClientId)
				.Select(x => GetViewModel(x))
				.ToList();
		}

		public MessageInfoViewModel? GetElement(MessageInfoSearchModel model)
		{
			if (!model.ClientId.HasValue)
			{
				return null;
			}

			return source.Messages.FirstOrDefault(x => (model.ClientId.HasValue && x.ClientId == model.ClientId))?.GetViewModel;
		}

		public MessageInfoViewModel? Insert(MessageInfoBindingModel model)
		{
			model.MessageId = source.Messages.Count > 0 ? Convert.ToString(source.Messages.Count + 1) : "1";

			var newMessage = MessageInfo.Create(model);

			if (newMessage == null)
			{
				return null;
			}

			source.Messages.Add(newMessage);
			source.SaveOrders();

			return GetViewModel(newMessage);
		}


        public MessageInfoViewModel? Update(MessageInfoBindingModel model)
        {
            var message = source.Messages.FirstOrDefault(x => x.MessageId.Equals(model.MessageId));

            if (message == null)
            {
                return null;
            }

            message.Update(model);
            source.SaveClients();

            return message.GetViewModel;
        }

        //для загрузки названий и имён в заказ
        private MessageInfoViewModel GetViewModel(MessageInfo message)
		{
			return message.GetViewModel;
		}
    }
}
