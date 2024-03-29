﻿using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.BusinessLogicsContracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Pop3;
using MailKit.Security;

namespace BlacksmithWorkshopBusinessLogic.MailWorker
{
	public class MailKitWorker : AbstractMailWorker
	{
		public MailKitWorker(ILogger<MailKitWorker> logger, IMessageInfoLogic messageInfoLogic, IClientLogic clientLogic) 
			: base(logger, messageInfoLogic, clientLogic) { }
		
		protected override async Task SendMailAsync(MailSendInfoBindingModel info)
		{
			using var objMailMessage = new MailMessage();

			using var objSmtpClient = new SmtpClient(_smtpClientHost, _smtpClientPort);

			try
			{
				objMailMessage.From = new MailAddress(_mailLogin);
				objMailMessage.To.Add(new MailAddress(info.MailAddress));
				objMailMessage.Subject = info.Subject;
				objMailMessage.Body = info.Text;
				objMailMessage.SubjectEncoding = Encoding.UTF8;
				objMailMessage.BodyEncoding = Encoding.UTF8;

				objSmtpClient.UseDefaultCredentials = false;
				objSmtpClient.EnableSsl = true;
				objSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
				objSmtpClient.Credentials = new NetworkCredential(_mailLogin, _mailPassword);

				await Task.Run(() => objSmtpClient.Send(objMailMessage));
			}
			catch (Exception)
			{
				throw;
			}
		}

		protected override async Task<List<MessageInfoBindingModel>> ReceiveMailAsync()
		{
			var list = new List<MessageInfoBindingModel>();

			using var client = new Pop3Client();

			await Task.Run(() =>
			{
				try
				{
					client.Connect(_popHost, _popPort, SecureSocketOptions.SslOnConnect);

					client.Authenticate(_mailLogin, _mailPassword);

					for (int i = 0; i < client.Count; i++)
					{
						var message = client.GetMessage(i);

						foreach (var mail in message.From.Mailboxes)
						{
							list.Add(new MessageInfoBindingModel
							{
								DateDelivery = message.Date.DateTime,
								MessageId = message.MessageId,
								SenderName = mail.Address,
								Subject = message.Subject,
								Body = message.TextBody
							});
						}
					}
				}
				catch (AuthenticationException)
				{ }
				finally
				{
					client.Disconnect(true);
				}
			});

			return list;
		}
	}
}
