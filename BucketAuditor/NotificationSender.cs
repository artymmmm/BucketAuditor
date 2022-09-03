using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace BucketAuditor
{
    class NotificationSender
    {
        public static void SendNotification(string baseUri, Bucket bucket)
        {
            StringBuilder sb = new StringBuilder(baseUri);
            sb.Append(bucket.Buckets_name);
            string bucketUri = sb.ToString();

            if (HttpResponseGetter.GetResponse(bucketUri) == 200 && bucket.Bucket_isPublic == false)
            {
                EmailSender.SendEmail(bucket);
                Console.WriteLine("Хранилище {0} является публичным несанкционированно. \nУведомление отправлено администратору {1} на электронную почту {2}", bucketUri, bucket.Admin.Admins_FIO, bucket.Admin.Admins_email);
            }
        }
    }
}
