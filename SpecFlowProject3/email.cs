
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace SpecFlowProject3.email
{
    public class MailHelper
    {
        public static void SendMail(string[] adresses, string subject, string message)
        {
            Console.WriteLine("aaaaaaaaaaaaaaaaaaaaaaa");
            try
            {
                MailMessage mail = new MailMessage();
                //ajouter les destinataires
                foreach (string adress in adresses)
                {
                    mail.To.Add(adress);
                }

                mail.Subject = subject;
                mail.Body = message;
                //définir l'expéditeur
                mail.From = new MailAddress("no-replay@mon-site.fr", "Webmaster & News");
                //définir les paramètres smtp pour l'envoi
                SmtpClient smtpServer = new SmtpClient
                {
                    Host = "smtp.mon-site.fr",
                    Port = 587,
                    EnableSsl = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("mohamed.kamoun@ensi-uma.tn", "##########################")
                };
                //envoi du mail
                smtpServer.Send(mail);
            }
            catch (Exception e)
            {
                Console.WriteLine("jfaekmnglnegln elzn");
                Console.WriteLine(e.Message);
            }

        }
    }
}
