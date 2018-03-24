using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Security;

namespace eMSP.WebAPI.Utility
{
    public enum SupportMailType
    {
        Verification,
        ResetPassword
    }
    public interface IMembershipService
    {

        // Additions to Interface for EmailConfirmation...
        bool SendEmail(MailModel mailmodel);

        bool SendVerification(string userId, string email, string confirmationtoken, SupportMailType Subject);


    }

    public class MailModel
    {
        private string _from;
        private string _to;
        private string _sub;
        private string _message;

        private MailType _mailtype;


        public string From
        {
            get { return _from; }
            set { _from = value; }
        }


        public string To
        {
            get { return _to; }
            set { _to = value; }
        }

        public string Sub
        {
            get { return _sub; }
            set { _sub = value; }
        }


        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }


        public MailType Type
        {
            get { return _mailtype; }
            set { _mailtype = value; }
        }

    }

    public enum MailType
    {
        EmailVerification        

    }

    public class AccountMembershipService : IMembershipService
    {

        private readonly MembershipProvider _provider;

        public AccountMembershipService()
            : this(null)
        {

        }

        public AccountMembershipService(MembershipProvider provider)
        {
            _provider = provider ?? Membership.Provider;

        }


        public bool SendVerification( string userId,string email,string confirmationtoken, SupportMailType Subject)
        {
            bool success = false;
            MailModel mailmodel = new MailModel();
            string verifyUrl = "";
            mailmodel.From = ConfigurationManager.AppSettings["EmailFrom"];
            mailmodel.To = email;
            mailmodel.Type = MailType.EmailVerification;

            if (mailmodel.To != "")
            {
                switch (Subject)
                {
                    case SupportMailType.Verification:

                        mailmodel.Sub = " Verfication Email ";

                        verifyUrl = String.Format(ConfigurationManager.AppSettings["User_Verification_Link"], userId, confirmationtoken);

                        mailmodel.Message = "Click the following link or Copy and paste the link in your browser address bar to validate your Account " + verifyUrl;

                        break;

                    case SupportMailType.ResetPassword:

                        mailmodel.Sub = " Reset Password ";

                        verifyUrl = String.Format(ConfigurationManager.AppSettings["Password_Reset_Link"], userId, confirmationtoken);

                        mailmodel.Message = "Click the following link or Copy and paste the link in your browser address bar to Reset your Password " + verifyUrl;

                        break;
                    

                }


                success = SendEmail(mailmodel);
            }
            

            return success;
        }


        public bool SendEmail(MailModel mailmodel)
        {

            SmtpClient mailClient = null;
            string userName = null, password = null, Mailbody = null;
            string Host;
            int port;
            var templatePath = "";
            string[] arry = null;
            string eMailProvider = ConfigurationManager.AppSettings["eMailProvider"];
            StreamReader filereader = null;
            System.Net.Mail.Attachment attachment = null ;
            switch (mailmodel.Type)
            {
                

                case MailType.EmailVerification:

                    templatePath = ConfigurationManager.AppSettings["EmailVerificationTemplate"];
                    templatePath = HttpContext.Current.Server.MapPath(templatePath);

                    filereader = new StreamReader(templatePath);
                    Mailbody = filereader.ReadToEnd();
                    filereader.Close();
                    Mailbody = string.Format(Mailbody, mailmodel.From, mailmodel.To, mailmodel.Sub, mailmodel.Message);

                    break;

            }




            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.IsBodyHtml = true;
            msg.To.Add(new MailAddress(mailmodel.To));
            msg.From =  new MailAddress(ConfigurationManager.AppSettings["EmailFrom"]); 
            
            msg.Subject = mailmodel.Sub;
            msg.Body = Mailbody;
            if (mailmodel.Type != MailType.EmailVerification && attachment != null)
            {
               
                    msg.Attachments.Add(attachment);
               
            }
            
            try
            {
                mailClient = new SmtpClient();
                if (eMailProvider == "gmail")
                {
                    //gmail Settings
                    Host = "smtp.gmail.com";
                    port = 587;
                    userName = "rajamailtest@gmail.com";
                    password = "raja2014";
                    mailClient.Host = Host;
                    mailClient.Port = port;
                    mailClient.Timeout = 10000;
                    mailClient.UseDefaultCredentials = false;
                    mailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    mailClient.Credentials = new NetworkCredential(userName, password);
                    mailClient.EnableSsl = true;
                }
                else
                {
                    Host = ConfigurationManager.AppSettings["EmailHost"]; 
                    port = 25;
                    userName = ConfigurationManager.AppSettings["EmailHostUserName"]; 
                    password = ConfigurationManager.AppSettings["EmailHostPassword"]; 
                    mailClient.Host = Host;
                    mailClient.Port = port;
                    mailClient.Timeout = 10000;
                    mailClient.UseDefaultCredentials = false;
                    mailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    mailClient.Credentials = new NetworkCredential(userName, password);
                    
                }

                mailClient.Send(msg);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}