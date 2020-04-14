using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CleaningApplication
{
    public partial class WebForm32 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblservicename.Text = "service name";
            lblprice.Text = "20.00";
            lbldatetime.Text = "date";

        }

        protected void btnfinish_Click1(object sender, EventArgs e)
        {
            Execute().Wait();
            lblmessage.Text = "the message has been sent successfully";
            //var mimeMessage = new MimeMessage();
            //mimeMessage.From.Add(new MailboxAddress("aastha2150@gmail.com", "aastha2150@gmail.com"));
            //mimeMessage.To.Add(new MailboxAddress("aastha2150@gmail.com", "aastha2150@gmail.com"));
            //mimeMessage.Subject = "subject";
            //mimeMessage.Body = new TextPart("plain")
            //{
            //    Text = " BodyContent"
            //};
            //    var apikey = System.Environment.GetEnvironmentVariable("SENDGRID_APIKEY");
            //    var client = new SendGridClient(apikey);
            //    var msg = new SendGridMessage();
            //    msg.SetFrom(new EmailAddress("aastha2150@gmail.com", "Swaach cleaning team"));

            //    var recipients = new List<EmailAddress>
            //    {
            //        new EmailAddress("aastha2150@gmail.com", "Aastha goyal")
            //};
            //    msg.AddTos(recipients);
            //    msg.SetSubject("Testing of email");
            //    msg.AddContent(MimeType.Text, "Hello world plain text");
            //    msg.AddContent(MimeType.Html, "<p> Hello world</p>");

            //    var response = await client.SendEmailAsync(msg);
            //    lblmessage.Text = response.ToString();
            //this is the MAIlKIT method
            //try
            //{
            //    string FromAddress = "aastha_goyal@outlook.com";
            //    string FromAddressTitle = "Aastha Goyal";
            //    string ToAddress = "aastha2150@gmail.com";
            //    string ToAddressTitle = "A service has been booked";

            //    string subject = "A new Booking request has been received";
            //    string BodyContent = "The booking details are:";
            //    BodyContent += "Email id: " + txtemail.Text;
            //    BodyContent += "Preferred Date: " + txtdate.Value;
            //    BodyContent += "Preferred Time: " + txttime.Value;
            //    BodyContent += "Additional Notes: " + txtnotes.Text;
            //    string SmtpServer = "smtp.office365.com";
            //    int SmtpPortNumber = 587;

            //    var mimeMessage = new MimeMessage();
            //    mimeMessage.From.Add(new MailboxAddress(FromAddressTitle, FromAddress));
            //    mimeMessage.To.Add(new MailboxAddress(ToAddressTitle, ToAddress));
            //    mimeMessage.Subject = subject;
            //    mimeMessage.Body = new TextPart("plain")
            //    {
            //        Text = BodyContent
            //    };

            //    using (var client = new SmtpClient())
            //    {
            //        client.Connect(SmtpServer, SmtpPortNumber,
            //                           false);
            //        client.Authenticate("aastha_goyal@outlook.com", "Aa$h10412");
            //        await client.SendAsync(mimeMessage);
            //        lblmessage.Text = "The message has been sent successfully";
            //        await client.DisconnectAsync(true);


            //    }
            //}
            //catch(Exception ex)
            //{
            //    lblmessage.Text = "Exception occured:" + ex.Message;
            //}

        }

        static async Task Execute()
        {
            var apiKey = Environment.GetEnvironmentVariable("MyApikey");

            var client = new SendGridClient(apiKey);

            // Send a Single Email using the Mail Helper
            var from = new EmailAddress("swaachclean@gmail.com", "Swaach Cleaning Services");
            var subject = "A new booking request has been received";
            var to = new EmailAddress("swaachclean@gmail.com", "Swaach Cleaning Services");
            var plainTextContent = "Plain text content";
            var htmlContent = "html content";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            var response = await client.SendEmailAsync(msg);
            Console.WriteLine(msg.Serialize());
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Headers);
            Console.WriteLine("\n\nPress <Enter> to continue.");
            Console.ReadLine();


        }
    }
}