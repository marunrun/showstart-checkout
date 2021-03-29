using checkout.Entity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace checkout.Helper
{

    class RequestUtil
    {

        private static readonly HttpClient client = getHttpClient();

        static Uri apiUri = new Uri("https://api.showstart.com/");

        static Uri signUri = new Uri("http://127.0.0.1:9504");


        private static HttpClient getHttpClient()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Add("Host", "api.showstart.com");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "okhttp/4.6.0");
            httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate");
            httpClient.DefaultRequestHeaders.Add("Connection", "Keep-Alive");
            httpClient.DefaultRequestHeaders.Add("Cookie", "u_s=http://api.showstart.com/app/user/bind/list.json; o_s=http://api.showstart.com/app/user/bind/list.json");
            return httpClient;
        }

        public static string Sign(String args)
        {
            string content = "";
            try
            {
                StringContent stringContent = new StringContent(args, Encoding.UTF8, "application/json");
                Task<HttpResponseMessage> task = client.PostAsync(signUri + "showstart/sign", stringContent);
                HttpResponseMessage result = task.Result;
                content = result.Content.ReadAsStringAsync().Result;
            }
            catch (Exception e)
            {
                LogHelpers.write(e.ToString());
                MessageBox.Show("服务器异常 请重试");
            }


            return content;
        }

        public static string loginByPwd(String pSign)
        {
            try
            {

                HttpContent httpContent = getContent(pSign);
                HttpResponseMessage result = client.PostAsync(apiUri + "app/user/login.json", httpContent).Result;

                string result1 = result.Content.ReadAsStringAsync().Result;
            }
            catch (Exception e)
            {
                LogHelpers.write(e.ToString());
                MessageBox.Show("服务异常，请重试");
                return "";
            }
        }

        private static HttpContent getContent(String pSign)
        {
            PublicData publicData = new PublicData
            {
                p_json_dig = pSign
            };
            Dictionary<string, string> dictionaries = new Dictionary<string, string>
            {
                { "uuid", publicData.uuid },
                { "terminal", publicData.terminal },
                { "sysVersion", publicData.sysVersion },
                { "sign", publicData.sign },
                { "p_json_dig", publicData.p_json_dig },
                { "deviceName", publicData.deviceName },
                { "appVersion", publicData.appVersion }
            };

            return new FormUrlEncodedContent(dictionaries);
        }
    }
}
