using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.BusinessLogicsContracts;
using BlacksmithWorkshopContracts.SearchModels;
using BlacksmithWorkshopContracts.StoragesContracts;
using BlacksmithWorkshopContracts.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopBusinessLogic.BusinessLogic
{
	public class MessageInfoLogic : IMessageInfoLogic
	{
		private readonly ILogger _logger;

		private readonly IMessageInfoStorage _messageInfoStorage;

		public MessageInfoLogic(ILogger<MessageInfoLogic> logger, IMessageInfoStorage messageInfoStorage)
		{
			_logger = logger;
			_messageInfoStorage = messageInfoStorage;
		}

		public List<MessageInfoViewModel>? ReadList(MessageInfoSearchModel? model)
		{
			_logger.LogInformation("ReadList. MessageId:{MessageId}", model?.MessageId);

			//list хранит весь список в случае, если model пришло со значением null на вход метода
			var list = model == null ? _messageInfoStorage.GetFullList() : _messageInfoStorage.GetFilteredList(model);

			if (list == null)
			{
				_logger.LogWarning("ReadList return null list");
				return null;
			}

			_logger.LogInformation("ReadList. Count:{Count}", list.Count);

			return list;
		}

		MessageInfoViewModel? IMessageInfoLogic.ReadElement(MessageInfoSearchModel model)
		{
			if (model == null)
			{
				throw new ArgumentNullException(nameof(model));
			}

			_logger.LogInformation("ReadList. ClientId:{ClientId}. MessageId:{MessageId}", model.ClientId, model?.MessageId);

			var element = _messageInfoStorage.GetElement(model);

			if (element == null)
			{
				_logger.LogWarning("ReadElement element not found");

				return null;
			}

			_logger.LogInformation("ReadElement find. Id:{Id}", element.MessageId);

			return element;
		}

		public bool Create(MessageInfoBindingModel model)
		{
			if (_messageInfoStorage.Insert(model) == null)
			{
				_logger.LogWarning("Insert operation failed");

				return false;
			}

			return true;
		}

        public bool Update(MessageInfoBindingModel model)
        {
            if (_messageInfoStorage.Update(model) == null)
            {
                _logger.LogWarning("Insert operation failed");

                return false;
            }

            return true;
        }
	}
}
