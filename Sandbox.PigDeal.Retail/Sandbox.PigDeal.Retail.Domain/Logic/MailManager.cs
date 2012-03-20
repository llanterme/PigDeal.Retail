using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using Mweb.Foundation.Practices.Logging;
using Sandbox.PigDeal.Retail.Domain.Entities;

namespace Sandbox.PigDeal.Retail.Domain.Logic
{
    public class MailManager
    {
        private static string TemplatePath
        {
            get { return GetConfig("TemplateBaseDirectory"); }

        }

        private static readonly ILogger Log = LogManager.GetLogger(typeof(MailManager));

        public void SendPublication(string mailto, Dictionary<string, string> configCollection)
        {
            var methodName = MethodBase.GetCurrentMethod().Name;

            try
            {
                // Pass the collection to popualte the template.
                Log.Info(methodName,
                         string.Format("Start Replacing Template Items. Template FileName: {0}",
                                       "PigDeal"));

                var tempFile = ReplaceInFile("Pigdeal.html", configCollection);


                //Send mail
                Log.Info(methodName,
                         string.Format("Sending Email with Subject: {0} and Temp File: {1}", "Welcome To Pigdeal",
                                       tempFile));

                SendEmail(mailto, "Admin@pigdeal.co.za", "Welcome To Pigdeal", tempFile);


            }

            catch (Exception ex)
            {
                Log.Info(methodName, string.Format("sending email Error: {0}", ex.Message.ToString()));
                throw new Exception(ex.Message);
            }

        }

        private static void SendEmail(string mailTo, string mailFrom, string subject, string tempTemplateName)
        {
            SmtpClient client = null;
            NetworkCredential mailCreds = null;
            var methodName = MethodBase.GetCurrentMethod().Name;

            var reader = new StreamReader(TemplatePath + @"\TempTemplates\" + tempTemplateName + @".html");
            var content = reader.ReadToEnd();

            var to = new MailAddress(mailTo);
            var from = new MailAddress(mailFrom);
            var message = new MailMessage(from, to)
            {
                Subject = subject,
                Body = content,
                IsBodyHtml = true
            };
            // DEBUG only
            if (GetConfig("SmtpServer") == null || GetConfig("SmtpServer") == string.Empty)
            {

                client = new SmtpClient("127.0.0.1")
                {
                    DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.SpecifiedPickupDirectory,
                    PickupDirectoryLocation = @"C:\temp\Pickup"
                };
                Log.Info(methodName, string.Format("TEST smtp server used."));
            }

            // Production
            else
            {
                client = new SmtpClient(GetConfig("SmtpServer"));
                mailCreds = new NetworkCredential { UserName = GetConfig("SmtpUserName"), Password = GetConfig("SmtpPassword") };

                Log.Info(methodName, string.Format("Production SMTP Server Used."));
            }

            try
            {
                client.Credentials = mailCreds;
                client.Send(message);

            }

            catch (Exception ex)
            {
                Log.Info(methodName, string.Format("The following exception(s) occured ---> Stack Trace: {0} ---> InnerExcetion {1}:  ", ex.StackTrace, ex.InnerException));
                throw new Exception("Error Sending Email.");

            }
        }

        private static string ReplaceInFile(string templatename, Dictionary<string, string> configCollection)
        {
            string tempFileName = null;
            var methodName = MethodBase.GetCurrentMethod().Name;

            try
            {

                var reader = new StreamReader(string.Format(@"{0}\{1}", TemplatePath, templatename));
                var content = reader.ReadToEnd();
                reader.Close();


                // Get the properties to be replaced.
                var properties = GetProperties(templatename);

                foreach (var property in properties)
                {

                    // Loop through the dictionary and match with the properties
                    foreach (var pair in configCollection.Where(a => a.Key.Equals(property)))
                    {
                        content = Regex.Replace(content, property, pair.Value);
                    }

                }

                // Write to a temp directory with the values that have been inserted.
                tempFileName = Guid.NewGuid().ToString();
                var writer = new StreamWriter(TemplatePath + @"\TempTemplates\" + tempFileName + @".html");
                writer.Write(content);
                writer.Close();

            }
            catch (Exception ex)
            {
                Log.Info(methodName, string.Format("Error: {0}", ex.Message));
                throw new Exception("Unable to set properties in template");
            }

            return tempFileName;

        }

        private static IEnumerable<string> GetProperties(string templatename)
        {
            var methodName = MethodBase.GetCurrentMethod().Name;
            string[] fields;

            try
            {
                var reader = new StreamReader(string.Format(@"{0}\{1}", TemplatePath, templatename));
                var content = reader.ReadToEnd();

                // Match all hashed fields
                var col = Regex.Matches(content, @"#(.*?)#");

                fields = new string[col.Count];
                for (int i = 0; i < fields.Length; i++)
                {
                    fields[i] = "#" + col[i].Groups[1].Value + "#";
                }

                reader.Close();

                return fields;
            }
            catch (Exception ex)
            {
                Log.Info(methodName, string.Format("Error: {0}", ex.Message));
                throw new Exception("Unable to extract template properties.");
            }

        }

        public static string GetConfig(string key)
        {
            string keyValue = null;
            try
            {
                keyValue = ConfigurationManager.AppSettings[key];
            }
            catch (Exception)
            {

                throw new Exception(string.Format("Unable to find a configuration item with the key {0} ", key));

            }

            return keyValue;
        }
    }
}
