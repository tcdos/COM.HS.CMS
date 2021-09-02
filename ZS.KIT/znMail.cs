using System.Net;
using System.Net.Mail;

namespace ZS.KIT
{
    public class znMail
    {
        /// <summary>
        /// 在线发送邮件
        /// </summary>
        public static void sendMail(string receiveMail, string subjects, string bodys, string attachmentUrl, string postMail, string mailUserName, string mailUserPwd, string smtpHost, int smtpPort)
        {
            MailMessage mailMsg = new MailMessage();
            mailMsg.From = new MailAddress(postMail);
            mailMsg.To.Add(receiveMail);
            mailMsg.Subject = subjects;
            mailMsg.Body = bodys;
            mailMsg.BodyEncoding = System.Text.Encoding.UTF8;
            mailMsg.IsBodyHtml = true;
            mailMsg.Priority = MailPriority.High;
            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new NetworkCredential(mailUserName, mailUserPwd);
            smtp.Host = smtpHost;
            smtp.Port = smtpPort;
            smtp.EnableSsl = false;
            smtp.Send(mailMsg);
            mailMsg.Dispose();
        }
    }
}
