using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace BucketAuditor
{
    class EmailSender
    {
        public static void SendEmail(Bucket bucket)
        {
            //Отправитель
            MailAddress from = new MailAddress("arty1303@gmail.com", "Automatic Bucket Audit");
            //Получатель
            MailAddress to = new MailAddress(bucket.Admin.Admins_email);
            //Создание объекта письма
            MailMessage message = new MailMessage(from, to);
            //Тема письма
            message.Subject = "Аудит бакета";
            //Текст письма
            message.Body = "Ваш бакет является публичным. Срочно измените настройки бакета!";
            //SMTP-сервер
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            // логин и пароль
            smtp.Credentials = new NetworkCredential("arty1303@gmail.com", "iwodsbvnphcfxmno");
            smtp.EnableSsl = true;
            smtp.Send(message);
        }
    }
}
