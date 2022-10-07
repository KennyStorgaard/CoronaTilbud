using CoronaTilbud_V2.Data.Interfaces;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaTilbud_V2.Models
{
    public class EmailService : IEmailService
    {
		private readonly IEmailConfiguration _emailConfiguration;
		private readonly IHostingEnvironment _env;

		public EmailService(IEmailConfiguration emailConfiguration, IHostingEnvironment env)
		{
			_emailConfiguration = emailConfiguration;
			_env = env;
		}
		public async Task Send(EmailForm emailForm)
		{
			var message = new MimeMessage();
			string ToAddress = "mail@coronatilbud.nu";

			message.From.Add(new MailboxAddress(emailForm.Name, emailForm.Email));
			message.To.Add(new MailboxAddress("Kontakt_Email", ToAddress));

			message.Subject = emailForm.Subject;

			//We will say we are sending HTML. But there are options for plaintext etc. 
			message.Body = new TextPart(TextFormat.Html)
			{
				Text = emailForm.Message
			};

			try
			{
				//Be careful that the SmtpClient class is the one from Mailkit not the framework!
				using (var emailClient = new SmtpClient())
				{
					// For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
					emailClient.ServerCertificateValidationCallback = (s, c, h, e) => true;

					if (_env.IsDevelopment())
					{
						// The third parameter is useSSL (true if the client should make an SSL-wrapped
						// connection to the server; otherwise, false).
						await emailClient.ConnectAsync(_emailConfiguration.SmtpServer, _emailConfiguration.SmtpPort, true);
					}
					else
					{
						await emailClient.ConnectAsync(_emailConfiguration.SmtpServer);
					}

					await emailClient.AuthenticateAsync(_emailConfiguration.SmtpUsername, _emailConfiguration.SmtpPassword);

					await emailClient.SendAsync(message);

					await emailClient.DisconnectAsync(true);
				}
			}
			catch (Exception ex)
			{

				throw new InvalidOperationException(ex.Message);
			}

		}

		public async Task SendAdd(AddForm addForm)
		{
			var message = new MimeMessage();
			string ToAddress = "mail@coronatilbud.nu";

			message.From.Add(new MailboxAddress(addForm.CompanyName, addForm.Email));
			message.To.Add(new MailboxAddress("Annonce_Email", ToAddress));

			message.Subject = addForm.Subject;
			
			string headline = addForm.Headline;
			var bodyBuilder = new BodyBuilder { HtmlBody = string.Format("<h1 style='color:red;'>{0}</h1> \n <h2>{1}</h2>", addForm.Message, addForm.Headline) };
			
			//string fileName = Path.GetFileName(addForm.Attachments.FileName);
			var attachment = new MimePart("image", "jpg")
			{
				Content = new MimeContent(File.OpenRead(addForm.Attachments.FileName), ContentEncoding.Default),
				ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
				ContentTransferEncoding = ContentEncoding.Base64,
				FileName = Path.GetFileName(addForm.Attachments.FileName)
			};
			attachment.ContentTransferEncoding = ContentEncoding.Base64;
			bodyBuilder.Attachments.Add(attachment);
			message.Body = bodyBuilder.ToMessageBody();
			

			try
			{
				//Be careful that the SmtpClient class is the one from Mailkit not the framework!
				using (var emailClient = new SmtpClient())
				{
					// For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
					emailClient.ServerCertificateValidationCallback = (s, c, h, e) => true;

					if (_env.IsDevelopment())
					{
						// The third parameter is useSSL (true if the client should make an SSL-wrapped
						// connection to the server; otherwise, false).
						await emailClient.ConnectAsync(_emailConfiguration.SmtpServer, _emailConfiguration.SmtpPort, true);
					}
					else
					{
						await emailClient.ConnectAsync(_emailConfiguration.SmtpServer);
					}
					//The last parameter here is to use SSL (Which you should!)
					//emailClient.Connect(_emailConfiguration.SmtpServer, _emailConfiguration.SmtpPort, true);

					//Remove any OAuth functionality as we won't be using it. 
					//emailClient.AuthenticationMechanisms.Remove("XOAUTH2");

					await emailClient.AuthenticateAsync(_emailConfiguration.SmtpUsername, _emailConfiguration.SmtpPassword);

					await emailClient.SendAsync(message);

					await emailClient.DisconnectAsync(true);
				}
			}
			catch (Exception ex)
			{

				throw new InvalidOperationException(ex.Message);
			}
		}
	}
}

