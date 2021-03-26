using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace checkout.Helper
{

    class RequestUtil
    {

        private static readonly HttpClient client = new HttpClient();

        static Uri apiUri = new Uri("https://api.showstart.com/");

        static Uri signUri = new Uri("http://127.0.0.1:9504");


        public static String Sign(String args)
        {
            Console.WriteLine(args);
            StringContent stringContent = new StringContent(args, Encoding.UTF8, "application/json");
            Task<HttpResponseMessage> task = client.PostAsync(signUri + "showstart/sign", stringContent);
            HttpResponseMessage result = task.Result;
            string content = result.Content.ReadAsStringAsync().Result;

            Console.WriteLine(content);
            return content;
        }

        public static void loginByPwd(String args)
        {

        }

        private static String putPublicArgs(String args)
        {

        }
    }
}
