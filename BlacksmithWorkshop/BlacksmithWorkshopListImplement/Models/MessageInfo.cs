using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.ViewModels;
using BlacksmithWorkshopDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopListImplement.Models
{
	public class MessageInfo : IMessageInfoModel
	{
        public int Id { get; private set; }

        public string MessageId { get; private set; } = string.Empty;

		public int? ClientId { get; private set; }

        public bool IsRead { get; private set; }

        public string SenderName { get; private set; } = string.Empty;

		public DateTime DateDelivery { get; private set; } = DateTime.Now;

		public string Subject { get; private set; } = string.Empty;

		public string Body { get; private set; } = string.Empty;

		public string? Answer { get; private set; } = string.Empty;

        //метод для создания объекта от класса-компонента на основе класса-BindingModel
        public static MessageInfo? Create(MessageInfoBindingModel? model)
		{
			if (model == null)
			{
				return null;
			}

			return new MessageInfo()
			{
				MessageId = model.MessageId,
				ClientId = model.ClientId,
				SenderName = model.SenderName,
				DateDelivery = model.DateDelivery,
				Subject = model.Subject,
				Body = model.Body,
				IsRead = model.IsRead,
				Answer = model.Answer
			};
		}

		//метод изменения существующего объекта
		public void Update(MessageInfoBindingModel? model)
		{
			if (model == null)
			{
				return;
			}

			MessageId = model.MessageId;
			ClientId = model.ClientId;
			SenderName = model.SenderName;
			DateDelivery = model.DateDelivery;
			Subject = model.Subject;
			Body = model.Body;
			IsRead = model.IsRead;
			Answer = model.Answer;

        }

		//метод для создания объекта класса ViewModel на основе данных объекта класса-компонента
		public MessageInfoViewModel GetViewModel => new()
		{
			MessageId = MessageId,
			ClientId = ClientId,
			SenderName = SenderName,
			DateDelivery = DateDelivery,
			Subject = Subject,
			Body = Body,
            IsRead = IsRead,
            Answer = Answer
        };
    }
}
