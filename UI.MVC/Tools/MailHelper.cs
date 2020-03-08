using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace UI.MVC.Tools
{
    public class MailHelper
    {
        public static bool SendConfirmationMail(string username, string mail)
        {
            bool result = false;
            MailMessage msg = new MailMessage();
            msg.To.Add(mail);
            msg.Subject = "Welcome "+username;
            msg.IsBodyHtml = true;
            msg.Body = "<b>Metro Turizm<b>";
            msg.From = new MailAddress("sinifmuazzam@gmail.com");
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            NetworkCredential credential = new NetworkCredential("sinifmuazzam@gmail.com", "123456**sinif");
            smtpClient.Credentials = credential;
            try
            {
                smtpClient.Send(msg);
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        public static bool SendTicketMail(string username, string mail,Bus bus)
        {
            bool result = false;
            MailMessage msg = new MailMessage();
            msg.To.Add(mail);
            msg.Subject = "Hello " + username;
            msg.IsBodyHtml = true;
            msg.Body = bus.BusDate+"<b> tarihli, <b>"+bus.BusTime + "<b> saatinde <b>"+bus.DepartureCity+"<b>-<b>"+bus.ReturnCity+"<b> biletiniz oluşturulmuştur.<b>";
            msg.From = new MailAddress("sinifmuazzam@gmail.com");
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            NetworkCredential credential = new NetworkCredential("sinifmuazzam@gmail.com", "123456**sinif");
            smtpClient.Credentials = credential;
            try
            {
                smtpClient.Send(msg);
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }
    }
}