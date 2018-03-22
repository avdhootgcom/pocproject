using Inspinia_MVC5.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace Inspinia_MVC5.Helpers
{
    public class EmailHelper : System.Net.Mail.SmtpClient
    {
        #region Member Variables
        /// <summary>
        /// Smtp server host address.
        /// </summary>
        public string SmtpHost;

        /// <summary>
        /// Smtp server host port.
        /// </summary>
        public int SmtpPort;

        /// <summary>
        /// SSL support.
        /// </summary>
        public bool SmtpSslEnabled;

        /// <summary>
        /// Smtp username.
        /// </summary>
        public string SmtpUsername;

        /// <summary>
        /// Smtp password.
        /// </summary>
        public string SmtpPassword;

        /// <summary>
        /// Smtp mail sender. "From" field of email. This should default to Administrator.
        /// </summary>
        public string MailSender;

        #endregion

        #region Singleton

        private static EmailHelper instance;

        public static EmailHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EmailHelper();
                }
                return instance;
            }
        }

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor that loads default configuration.
        /// </summary>
        public EmailHelper()
        {
            // Load default smtp/email server configuration.
            LoadDefaultConfiguration();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Load default configuration for SMTP Server and Default mail sender
        /// </summary>
        private void LoadDefaultConfiguration()
        {
            // Check for null or empty.
            try
            {
                SmtpHost = ConfigurationManager.AppSettings["SmtpHost"];
                int.TryParse(ConfigurationManager.AppSettings["SmtpPort"], out this.SmtpPort);
                Boolean.TryParse(ConfigurationManager.AppSettings["SmtpSslEnabled"], out this.SmtpSslEnabled);
                SmtpUsername = ConfigurationManager.AppSettings["SmtpUsername"];
                SmtpPassword = ConfigurationManager.AppSettings["SmtpPassword"];
                MailSender = ConfigurationManager.AppSettings["MailSender"];
                if (string.IsNullOrEmpty(SmtpHost) || string.IsNullOrEmpty(SmtpUsername) ||
                    string.IsNullOrEmpty(SmtpPassword) || string.IsNullOrEmpty(MailSender))
                {
                    // Log unable to load default configuration for Smtp Server.
                    // Invalid SMTP configuration in settings(Host, Username, Password or MailSender might be empty. This is not recommended.)
                }
            }
            catch (Exception ex)
            {
                // log here.
                throw ex; // rethrow exception.
            }
        }
        public void Send(string mailTo, string mailSubject, string mailBody, bool isBodyHtml = true, IEnumerable<string> ccList = null, IEnumerable<string> bccList = null)
        {
            Send(MailSender, mailTo, mailSubject, mailBody, isBodyHtml, ccList, bccList);
        }

        /// <summary>
        /// Send email with configuration set to this provider.
        /// </summary>
        /// <param name="mailTo">Email address of the sender.</param>
        /// <param name="mailSubject">Subject of the mail.</param>
        /// <param name="mailBody">Body of the mail.</param>
        /// <param name="isBodyHtml">True if mail body is in html format.</param>
        public void Send(string mailTo, string mailSubject, string mailBody, MemoryStream ms, bool isBodyHtml = true)
        {
            Send(MailSender, mailTo, mailSubject, mailBody, ms, isBodyHtml);
        }

        public void SendComplaintEmail(string mailTo, string mailSubject, string mailBody, bool isBodyHtml = true, IEnumerable<string> ccList = null, IEnumerable<string> bccList = null)
        {
            Send(MailSender, mailTo, mailSubject, mailBody, isBodyHtml, ccList, bccList);
        }

        /// <summary>
        /// Send email with configuration set to this provider.
        /// </summary>
        /// <param name="mailSender">Email sender.</param>
        /// <param name="mailTo">Email address of the recipient.</param>
        /// <param name="mailSubject">Subject of the mail.</param>
        /// <param name="mailBody">Body of the mail.</param>
        /// <param name="isBodyHtml">True if mail body is in html format.</param>
        /// 
        public void Send(string mailSender, string mailTo, string mailSubject, string mailBody, MemoryStream ms, bool isBodyHtml = true)
        {
            try
            {
                MailMessage mailMessage = new MailMessage(mailSender, mailTo, mailSubject, mailBody);
                mailMessage.IsBodyHtml = isBodyHtml;
                mailMessage.Attachments.Add(new Attachment(ms, "sample.pdf"));
                //if (attachments != null)
                //{
                //    foreach (string attachedFile in attachments)
                //    {
                //        mailMessage.Attachments.Add(new Attachment(attachedFile));
                //    }
                //}

                SmtpClient smtpClient = new SmtpClient(SmtpHost, SmtpPort);
                smtpClient.EnableSsl = SmtpSslEnabled;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential(SmtpUsername, SmtpPassword);
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                throw ex; // rethrow exception.
            }
        }
        public void Send(string mailSender, string mailTo, string mailSubject, string mailBody, bool isBodyHtml = true, IEnumerable<string> ccList = null, IEnumerable<string> bccList = null)
        {
            try
            {
                MailMessage mailMessage = new MailMessage(mailSender, mailTo, mailSubject, mailBody);
                if (ccList != null)
                {
                    foreach (var ccmail in ccList)
                    {
                        mailMessage.CC.Add(ccmail);
                    }
                }
                if (bccList != null)
                {
                    foreach (var bccmail in bccList)
                    {
                        mailMessage.Bcc.Add(bccmail);
                    }
                }
                mailMessage.IsBodyHtml = isBodyHtml;
                SmtpClient smtpClient = new SmtpClient(SmtpHost, SmtpPort);
                smtpClient.EnableSsl = SmtpSslEnabled;
                smtpClient.Credentials = new System.Net.NetworkCredential(SmtpUsername, SmtpPassword);
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                // ToDo: Log here
                throw ex; // rethrow exception.
            }
        }

        /// <summary>
        /// Send email with configuration set to this provider.
        /// </summary>
        /// <param name="mailTo">Email address of the sender.</param>
        /// <param name="mailSubject">Subject of the mail.</param>
        /// <param name="mailBody">Body of the mail.</param>
        /// <param name="attachments">File names including path to send as attachments.</param>
        /// <param name="isBodyHtml">True if mail body is in html format.</param>
        public void Send(string mailTo, string mailSubject, string mailBody, IEnumerable<string> attachments, bool isBodyHtml = true)
        {
            Send(MailSender, mailTo, mailSubject, mailBody, attachments, isBodyHtml);
        }

        /// <summary>
        /// Send email with configuration set to this provider.
        /// </summary>
        /// <param name="mailSender">Email sender.</param>
        /// <param name="mailTo">Email address of the recipient.</param>
        /// <param name="mailSubject">Subject of the mail.</param>
        /// <param name="mailBody">Body of the mail.</param>
        /// <param name="attachments">File names including path to send as attachments.</param>
        /// <param name="isBodyHtml">True if mail body is in html format.</param>
        public void Send(string mailSender, string mailTo, string mailSubject, string mailBody, IEnumerable<string> attachments, bool isBodyHtml = true)
        {
            try
            {
                MailMessage mailMessage = new MailMessage(mailSender, mailTo, mailSubject, mailBody);
                mailMessage.IsBodyHtml = isBodyHtml;

                if (attachments != null)
                {
                    foreach (string attachedFile in attachments)
                    {
                        mailMessage.Attachments.Add(new Attachment(attachedFile));
                    }
                }

                SmtpClient smtpClient = new SmtpClient(SmtpHost, SmtpPort);
                smtpClient.EnableSsl = SmtpSslEnabled;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential(SmtpUsername, SmtpPassword);
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                throw ex; // rethrow exception.
            }
        }

        /// <summary>
        /// Send email with configuration set to this provider.
        /// </summary>
        /// <param name="mailSender">Email sender.</param>
        /// <param name="mailTo">Email address of the recipient.</param>
        /// <param name="mailSubject">Subject of the mail.</param>
        /// <param name="mailBody">Body of the mail.</param>
        /// <param name="attachments">Attachments using FileModel.</param>
        /// <param name="isBodyHtml">True if mail body is in html format.</param>
        public void Send(string mailTo, string mailSubject, string mailBody, List<FileModel> attachments,
            bool isBodyHtml = true, IEnumerable<string> ccList = null, IEnumerable<string> bccList = null)
        {
            try
            {
                MailMessage mailMessage = new MailMessage(MailSender, mailTo, mailSubject, mailBody);
                if (ccList != null)
                {
                    foreach (var ccmail in ccList)
                    {
                        mailMessage.CC.Add(ccmail);
                    }
                }

                if (bccList != null)
                {
                    foreach (var bccmail in bccList)
                    {
                        mailMessage.Bcc.Add(bccmail);
                    }
                }

                if (attachments != null)
                {
                    MemoryStream ms;
                    foreach (FileModel attachedFile in attachments)
                    {
                        ms = new MemoryStream();
                        using (BinaryWriter bw = new BinaryWriter(ms))
                        {
                            bw.Write(attachedFile.Content);
                            bw.Flush();
                            bw.Close();
                            bw.Dispose();
                        }
                        mailMessage.Attachments.Add(new Attachment(ms, attachedFile.Name));
                    }
                }

                mailMessage.IsBodyHtml = isBodyHtml;
                SmtpClient smtpClient = new SmtpClient(SmtpHost, SmtpPort);
                smtpClient.EnableSsl = SmtpSslEnabled;
                smtpClient.Credentials = new System.Net.NetworkCredential(SmtpUsername, SmtpPassword);
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                // ToDo: Log here
                throw ex; // rethrow exception.
            }
        }

        #endregion
    }
}