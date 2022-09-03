using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BucketAuditor
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseUri = "https://storage.yandexcloud.net/";

            BucketsDB db = new BucketsDB();
            foreach(var bucket in db.Buckets)
            {
                NotificationSender.SendNotification(baseUri, bucket);
            }
            Console.Read();
        }
    }
}
