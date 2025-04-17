using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;
using NETCore.MailKit.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebVotingSystem.Utility
{
    public class EmailSender : IEmailSender
    {
        private readonly IEmailService _EmailService;
        private readonly ILogger<EmailSender> _logger;

        public EmailSender(IEmailService emailService, ILogger<EmailSender> logger)
        {
            _EmailService = emailService;
            _logger = logger;
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Execute(subject, message, email);
        }

        public Task Execute(string subject, string message, string email)
        {
            try
            {
                return _EmailService.SendAsync(email, subject, message, true);
            }
            catch (MailKit.Net.Smtp.SmtpProtocolException ex)
            {
                _logger.LogInformation(ex.ToString());
            }
            catch (MailKit.Net.Smtp.SmtpCommandException ex)
            {
                _logger.LogInformation(ex.ToString());
            }
            return null;
        }
    }
}
