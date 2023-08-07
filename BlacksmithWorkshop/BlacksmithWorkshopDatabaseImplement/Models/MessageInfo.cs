using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.ViewModels;
using BlacksmithWorkshopDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopDatabaseImplement.Models
{
	[DataContract]
	public class MessageInfo : IMessageInfoModel
	{
        public int Id => throw new NotImplementedException();

        [Key]
        [DataMember]
        public string MessageId { get; set; } = string.Empty;

		[DataMember]
		public int? ClientId { get; set; }

		public bool IsRead { get; private set; } = false;

        [Required]
		[DataMember]
		public string SenderName { get; set; } = string.Empty;

		[DataMember]
		public DateTime DateDelivery { get; set; } = DateTime.Now;

		[DataMember]
		public string Subject { get; set; } = string.Empty;

		[DataMember]
		public string Body { get; set; } = string.Empty;

		public string? Answer { get; private set; } = string.Empty;

        public virtual Client? Client { get; set; }

		public static MessageInfo? Create(MessageInfoBindingModel model)
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
				Body = model.Body,
				DateDelivery = model.DateDelivery,
				Subject = model.Subject,
				IsRead = model.IsRead,
				Answer = model.Answer
			};
		}

        public void Update(MessageInfoBindingModel model)
        {
            if (model == null)
            {
                return;
            }

			IsRead = model.IsRead;
			Answer = model.Answer;
        }

        public MessageInfoViewModel GetViewModel => new()
		{
			MessageId = MessageId,
			ClientId = ClientId,
			SenderName = SenderName,
			Body = Body,
			DateDelivery = DateDelivery,
			Subject = Subject,
            IsRead = IsRead,
            Answer = Answer
        };
    }
}
