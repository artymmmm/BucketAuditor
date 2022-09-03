using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace BucketAuditor
{
    class HttpResponseGetter
    {
        //Получение HTTP ответа
        //Параметры: список URI, от которых необходимо получить ответ
        //Возвращает список бакетов
        public static int GetResponse(string uri)
        {
            //Переменная, которая будет содержать код состояния
            int statusCode;

            //Создание HTTP запроса на URI, переданный в виде параметра
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);

            //Установка ограничений на использование ресурсов запросом
            //Макисмальное количество переадресаций
            request.MaximumAutomaticRedirections = 4;
            //Максимальная длина заголовка ответов
            request.MaximumResponseHeadersLength = 4;
            //Установка учётных данных для запроса
            request.Credentials = CredentialCache.DefaultCredentials;

            try
            {
                //Получение HTTP ответа
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                //Запись код статуса в переменную
                statusCode = (int)response.StatusCode;
                //Заркытие ответа и освобождение подключения
                response.Close();
            }
            //Поймана ошибка WebException (не удалось установить соединение или доступ запрещён)
            catch (WebException e)
            {
                //Ошибка содержит код статуса 403
                if (e.Message.Contains("403"))
                {
                    statusCode = 403;
                }
                //Ошибка содержит код статуса 403
                else if (e.Message.Contains("404"))
                {
                    statusCode = 404;
                }
                //Ошибка содержит код статуса 403
                else if (e.Message.Contains("400"))
                {
                    statusCode = 400;
                }
                //Ошибка содержит другой код статуса
                else
                {
                    statusCode = -1;
                }
            }

            //Установка состояния в виде текста в зависимости от кода
            return statusCode;
        }
    }
}
