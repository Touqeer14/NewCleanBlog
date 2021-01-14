using CleanBlog.Core.ViewModels;
using Umbraco.Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using CleanBlog.Core.Controllers;
using Umbraco.Web.Models;

namespace CleanBlog.Core.Services
{

    //public class SmtpService : ISmtpService
    //{
    //    private readonly ILogger _logger;

    //    public SmtpService(ILogger logger)
    //    {
    //        _logger = logger;
    //    }

    //    public bool SendEmail(ContactViewModel model)
    //    {
    //        try
    //        {
    //            MailMessage message = new MailMessage();
    //            SmtpClient client = new SmtpClient();

    //            string toAddress = "to@test.com";
    //            string fromAddress = "from@test.com";
    //            message.Subject = $"Enquiry from: {model.Name} - {model.Email}";
    //            message.Body = model.Message;
    //            message.To.Add(new MailAddress(toAddress, toAddress));
    //            message.From = new MailAddress(fromAddress, fromAddress);

    //            client.Send(message);
    //            return true;
    //        }
    //        catch (Exception ex)
    //        {
    //            _logger.Error(typeof(ContactSurfaceController), ex, "Error sending contact form.");
    //            return false;
    //        }
    //    }
    // }
    public void SendEmail(ContactViewModel model)
    {
        MailMessage message = new MailMessage(model.Email, "website@installumbraco.web.local");
        message.Subject = string.Format("Enquiry from {0} {1}  ", model.Name, model.Email);
        message.Body = model.Message;
        SmtpClient Client = new SmtpClient("127.0.0.1", 25);
        Client.Send(message);
    }
}
