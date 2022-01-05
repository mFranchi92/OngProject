using Microsoft.Extensions.Configuration;
using OngProject.Core.Interfaces.IServices;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Services
{
    public class MailService : IMailService
    {
        private IConfiguration _configuration;
        private readonly IOrganizationService _organizationService;

        public MailService(IConfiguration configuration, IOrganizationService organizationService)
        {
            _configuration = configuration;
            _organizationService = organizationService;
        }
        public async Task SendMail(string ToEmail, string body, string subject)
        {

            try
            {
                var ong = _organizationService.GetAll().Result.FirstOrDefault();
                string html = File.ReadAllText("./MailTemplates/plantilla_email.html");
                html = html.Replace("{mail_title}", subject);
                html = html.Replace("{mail_body}", body);
                html = html.Replace("{mail_contact}", ong.Address + " <br> "+ ong.Phone);
                var apiKey = _configuration["MailService:SendGridAPI"];
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress(_configuration["MailService:VerifiedAPIMail"]);
                var to = new EmailAddress(ToEmail);
                var msg = MailHelper.CreateSingleEmail(from, to, subject, "", html);
                var response = await client.SendEmailAsync(msg).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
