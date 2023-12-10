using MimeKit;
using MailKit;
using stock_quote_exchange.Configuration;
using stock_quote_exchange.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Security;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;

namespace stock_quote_exchange.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;
        private ILogger<EmailService> _logger;

        public EmailService(IOptions<EmailSettings> emailSettings,
                            ILogger<EmailService> logger)
        {
            _emailSettings = emailSettings.Value;
            _logger = logger;
        }

        public async Task SendEmailAsync(string symbol, string price, double threshold, ThresholdType thresholdType)
        {
            _logger.LogInformation($"Sending email for {symbol}");

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_emailSettings.SenderConfiguration.SenderName
                                                , _emailSettings.SenderConfiguration.SenderEmail));

            foreach (var receiver in _emailSettings.ReceiverConfiguration.ReceiverEmails)
            {
                message.To.Add(new MailboxAddress("", receiver));
            }

            var body = thresholdType switch
            {
                ThresholdType.Sell => $"The stock {symbol} has reached your sell threshold with a current price of {price}",
                ThresholdType.Buy => $"The stock {symbol} has reached your buy threshold with a current price of {price}",
            };

            message.Subject = "Stock Quote Exchange Alert";
            message.Body = new TextPart("Plain") { Text = body };

            using (var client = new SmtpClient())
            {
                client.Connect(_emailSettings.SmtpConfiguration.Server,
                               _emailSettings.SmtpConfiguration.Port,
                               SecureSocketOptions.StartTls);
                client.Authenticate(_emailSettings.SenderConfiguration.SenderEmail,
                                    _emailSettings.SenderConfiguration.SenderPassword);
                client.Send(message);
                client.Disconnect(true);
            }

        }
    }
}
