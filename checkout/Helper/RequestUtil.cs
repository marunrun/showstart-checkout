using checkout.Entity.Qo;
using checkout.Entity.Vo;
using checkout.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;


namespace checkout.Helper
{

    class RequestUtil
    {
        private static readonly HttpClient client = getHttpClient();

        static Uri apiUri = new Uri(Helpers.readIni("apiUri", "https://pro2-api.showstart.com"));

        public const string DATA_KEY = "dataKey";
        public const string ARU_KEY = "aruKey";

        private static HttpClient getHttpClient()
        {
            var handler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip
            };
            HttpClient httpClient = new HttpClient(handler);
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Add("Host", "pro2-api.showstart.com");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "okhttp/4.6.0");
            httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip");
            httpClient.DefaultRequestHeaders.Add("Connection", "Keep-Alive");
            httpClient.DefaultRequestHeaders.Add("CTERMINAL", "android");
            httpClient.DefaultRequestHeaders.Add("CUUSERREF", Helpers.Md5(Helpers.Get32RandomID()));
            return httpClient;
        }


        // post请求
        public async static void post(RequestQo request, object param, Action<string> callback,string sessionId = null)
        {
            HttpContent content = new StringContent(JsonSerializer.Serialize(buildeRquest(request, param)));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            content.Headers.Add("CUSUT", UserService.getInstance().sign);
            content.Headers.Add("CUSYSTIME", Helpers.CurrentTimeStamp().ToString());

            // 如果 pathType 不是null
            if (!String.IsNullOrEmpty(sessionId)) {
                request.sessionId = sessionId;
            }
            Console.WriteLine(request);

            HttpResponseMessage httpResponseMessage = await client.PostAsync(apiUri + request.Geturi(), content);
            var res = await httpResponseMessage.Content.ReadAsStringAsync();
            Console.WriteLine(res);
            LogHelpers.write(res);

            callback(res);
        }

        // 定时post请求
        public async static void post(RequestQo request, Object param, Action<string> callback, DateTime dateTime, string sessionId = null)
        {
            // 线程停一下
            while (dateTime != null && DateTime.Now.CompareTo(dateTime) < 0)
            {
                Thread.Sleep(100);
            }

            Dictionary<string, string> dictionaries = buildeRquest(request, param, dateTime);
            HttpContent content = new StringContent(JsonSerializer.Serialize(dictionaries));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            content.Headers.Add("CUSUT", UserService.getInstance().sign);
            content.Headers.Add("CUSYSTIME", Helpers.CurrentTimeStamp().ToString());

            // 如果 pathType 不是null
            if (!String.IsNullOrEmpty(sessionId))
            {
                request.sessionId = sessionId;
            }

     
            HttpResponseMessage httpResponseMessage = await client.PostAsync(apiUri + request.Geturi(), content);
            var res = await httpResponseMessage.Content.ReadAsStringAsync();
            Console.WriteLine(res);
            LogHelpers.write(res);

            callback(res);
        }

        // get请求
        public async static void get(RequestQo request, Object param, Action<Stream> callback)
        {
            Console.WriteLine(request);

            string pram = BuildParam(request, param);
            Stream res = await client.GetStreamAsync(apiUri + request.Geturi() + "?" + pram);
            callback(res);
        }
        public static Dictionary<string, string> buildeRquest(RequestQo request, Object param)
        {
            return buildeRquest(request, param, DateTime.Now);
        }

        // 构建请求参数
        public static Dictionary<string, string> buildeRquest(RequestQo request, Object param, DateTime dateTime)
        {
            Dictionary<string, object> queryObj = new Dictionary<string, object> {
                {"action",request.action },
                {"deviceName","MI 10" },
                {"qtime",Helpers.DateToTicks(dateTime)},
                {"ranstr",Helpers.getRandom() },
                {"sysVersion","10" },
            };
            if (request.type == "REQUEST_BODY")
            {
                queryObj.Add("body", param);
            }
            else
            {
                queryObj.Add("query", param);
            }

            // 原始req
            var reqJson = JsonSerializer.Serialize(queryObj);
            Console.WriteLine("reqJson :" + reqJson);
            var dataKey = Helpers.readIni(DATA_KEY, "");
            var aruKey = Helpers.readIni(ARU_KEY, PublicData.ARU_KEY);
            if (request.bol)
            {
                dataKey = aruKey;
            }

            return new Dictionary<string, string> {
                { "appid","app"},
                { "terminal","android"},
                { "version",PublicData.appVersion},
                { "aru",Helpers.AesEncrypt(aruKey,request.action)},
                { "data",Helpers.AesEncrypt(dataKey,reqJson)},
                { "sign",Helpers.Md5(reqJson)},
            };
        }


        // getParams
        private static string BuildParam(RequestQo request, Object param)
        {
            var parms = "";

            Dictionary<string, string> dictionaries = buildeRquest(request, param);

            foreach (KeyValuePair<string, string> item in dictionaries)
            {
                parms += string.Format("{0}={1}&", item.Key, Uri.EscapeDataString(item.Value));

            }

            parms = parms.TrimEnd('&');

            return parms;
        }


    }
}
