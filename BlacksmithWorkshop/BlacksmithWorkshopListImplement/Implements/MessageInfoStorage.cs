using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.SearchModels;
using BlacksmithWorkshopContracts.StoragesContracts;
using BlacksmithWorkshopContracts.ViewModels;
using BlacksmithWorkshopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopListImplement.Implements
{
	public class MessageInfoStorage : IMessageInfoStorage
	{
		//поле для работы со списком изделий
		private readonly DataListSingleton _source;

		public MessageInfoStorage()
		{
			_source = DataListSingleton.GetInstance();
		}

		public List<MessageInfoViewModel> GetFullList()
		{
			var result = new List<MessageInfoViewModel>();

			foreach (var messageInfo in _source.MessageInfos)
			{
				result.Add(messageInfo.GetViewModel);
			}

			return result;
		}

		public List<MessageInfoViewModel> GetFilteredList(MessageInfoSearchModel model)
		{
			var result = new List<MessageInfoViewModel>();

			if (string.IsNullOrEmpty(model.MessageId))
			{
				return result;
			}

			foreach (var messageInfo in _source.MessageInfos)
			{
				if (messageInfo.ClientId == model.ClientId)
				{
					result.Add(messageInfo.GetViewModel);
				}
			}

			return result;
		}

		public MessageInfoViewModel? GetElement(MessageInfoSearchModel model)
		{
			if (string.IsNullOrEmpty(model.MessageId))
			{
				return null;
			}

			foreach (var messageInfo in _source.MessageInfos)
			{
				if (messageInfo.MessageId == model.MessageId)
				{
					return messageInfo.GetViewModel;
				}
			}

			return null;
		}

		public MessageInfoViewModel? Insert(MessageInfoBindingModel model)
		{
			var newMessage = MessageInfo.Create(model);

			if (newMessage == null)
			{
				return null;
			}

			_source.MessageInfos.Add(newMessage);

			return newMessage.GetViewModel;
		}

        public MessageInfoViewModel? Update(MessageInfoBindingModel model)
        {
            foreach (var message in _source.MessageInfos)
            {
                if (message.MessageId.Equals(model.MessageId))
                {
                    message.Update(model);

                    return message.GetViewModel;
                }
            }

            return null;
        }
    }
}
