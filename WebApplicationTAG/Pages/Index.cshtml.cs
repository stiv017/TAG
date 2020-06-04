using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EASendMail;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplicationTAG.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {

        }
        public void OnPost()
        {
            try
            {
                var message = Request.Form["message"];
                var email = Request.Form["email"];
                var name = Request.Form["name"];
                SmtpMail oMail = new SmtpMail("TryIt");

                // Your gmail email address
                oMail.From = "test@prevodilac.co.rs";

                // Set recipient email address
                oMail.To = "sasajov.tag@gmail.com";

                // Set email subject
                oMail.Subject = "Pitanje Sa TAG Sajta";

                // Set email body
                //oMail.TextBody = "this is a test email sent from c# project with gmail.";
                oMail.TextBody = name + "\n" + email + "\n" + message;

                // Gmail SMTP server address
                SmtpServer oServer = new SmtpServer("mailcluster.loopia.se");

                // Gmail user authentication
                // For example: your email is "gmailid@gmail.com", then the user should be the same
                oServer.User = "test@prevodilac.co.rs";
                oServer.Password = "loopiatag99";

                // If you want to use direct SSL 465 port,
                // please add this line, otherwise TLS will be used.
                // oServer.Port = 465;

                // set 587 TLS port;
                oServer.Port = 587;

                // detect SSL/TLS automatically
                oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

                Console.WriteLine("start to send email over SSL ...");

                EASendMail.SmtpClient oSmtp = new EASendMail.SmtpClient();
                oSmtp.SendMail(oServer, oMail);

                Console.WriteLine("email was sent successfully!");
            }
            catch (Exception ep)
            {
                Console.WriteLine("failed to send email with the following error:");
                Console.WriteLine(ep.Message);
            }
        }
    }
}
