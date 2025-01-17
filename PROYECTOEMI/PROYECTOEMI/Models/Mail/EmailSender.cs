﻿using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using PROYECTOEMI.Models.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public interface IEmailSenderP
    {
        Task SendEmailAsync(string email, string subject, string message);
    }

    public class EmailSender : IEmailSenderP
    {
        private readonly SmtpSettings _emailSettings;

        public EmailSender(IOptions<SmtpSettings> smtpSettings)
        {
            _emailSettings = smtpSettings.Value;
        }
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                var mimeMessage = new MimeMessage();
                mimeMessage.From.Add(new MailboxAddress(_emailSettings.SenderName, _emailSettings.SenderEmail));
                mimeMessage.To.Add(new MailboxAddress(email));
                mimeMessage.Subject = subject;
                mimeMessage.Body = new TextPart("html")
                {
                    Text = message
                };

                using (var client = new SmtpClient())
                {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                await client.ConnectAsync(_emailSettings.Server, _emailSettings.Port, true);

                await client.AuthenticateAsync(_emailSettings.Username, _emailSettings.Password);
                await client.SendAsync(mimeMessage);
                await client.DisconnectAsync(true);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

    }

