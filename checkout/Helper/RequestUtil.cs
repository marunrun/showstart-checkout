using checkout.Entity.Qo;
using checkout.Entity.Vo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace checkout.Helper
{

    class RequestUtil
    {
        private static readonly HttpClient client = getHttpClient();

        static Uri apiUri = new Uri(Helpers.readIni("apiUri", "http://pro2-api.showstart.com"));

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
            httpClient.DefaultRequestHeaders.Add("CUUSERREF", "e31d1cf2e8778e5ee9f0d5191a52ab02");
            httpClient.DefaultRequestHeaders.Add("CUSUT", "");
            httpClient.DefaultRequestHeaders.Add("CUSYSTIME", Helpers.DateToTicks(DateTime.Now).ToString());
            return httpClient;
        }



 /*       // 验证码登陆
        public static Result<UserSession> loginByVCode(CodeLoginData codeLoginData)
        {
            try
            {
                HttpContent httpContent = getContent(sign(codeLoginData).Result);
                HttpResponseMessage response = client.PostAsync(apiUri + "app/user/vc_login.json", httpContent).Result;
                string result = response.Content.ReadAsStringAsync().Result;

                return (Result<UserSession>)JsonConvert.DeserializeObject(result, typeof(Result<UserSession>));
            }
            catch (Exception e)
            {
                LogHelpers.write(e.ToString());
                MessageBox.Show("服务异常，请重试");
                return new Result<UserSession>();
            }
        }
*/



/*
        // 获取用户身份证信息
        public async static Task<Result<List<UserIdInfo>>> getUserIdInfo(getUserIdListQo getUserIdListQo)
        {
            try
            {
                string pSign = await sign(getUserIdListQo);
                HttpResponseMessage response = await client.GetAsync(apiUri + "app/commonPerformer/list.json?" + BuildParam(pSign));
                string result = await response.Content.ReadAsStringAsync();
                Result<List<UserIdInfo>> res = (Result<List<UserIdInfo>>)JsonConvert.DeserializeObject(result, typeof(Result<List<UserIdInfo>>));
                return res;
            }
            catch (Exception e)
            {
                LogHelpers.write(e.ToString());
                MessageBox.Show("服务异常，请重试");
                return new Result<List<UserIdInfo>>();
            }
        }*/

/*        public async static void handleAddress(AddressQo addressQo, ComboBox comboBox)
        {
            HttpContent httpContent = new FormUrlEncodedContent(buildeRquest(Urls, addressQo));
            HttpResponseMessage httpResponseMessage = await client.PostAsync(apiUri + "app/address/list.json", httpContent);
            string result = await httpResponseMessage.Content.ReadAsStringAsync();
            Result<List<AddressInfo>> res = (Result<List<AddressInfo>>)JsonConvert.DeserializeObject(result, typeof(Result<List<AddressInfo>>));
            if (res.isSuccess())
            {
                comboBox.DataSource = res.result;
            }
        }
*/


        // post请求
        public async static void post(RequestQo request, Object param, Action<Stream> callback)
        {
           
            HttpContent httpContent = new FormUrlEncodedContent(buildeRquest(request, param));
            HttpResponseMessage httpResponseMessage = await client.PostAsync(apiUri + request.uri, httpContent);
            Stream res = await httpResponseMessage.Content.ReadAsStreamAsync();
            callback(res);
        }

        // 定时post请求
        public async static void post(RequestQo request, Object param, Action<Stream> callback, DateTime dateTime)
        {
            HttpContent httpContent = new FormUrlEncodedContent(buildeRquest(request, param));
            Console.WriteLine(dateTime.ToString("HH:mm:ss.ffff"));

            while (dateTime != null && DateTime.Now.CompareTo(dateTime) < 0)
            {
                Thread.Sleep(10);
            }
            HttpResponseMessage httpResponseMessage = await client.PostAsync(apiUri + request.uri, httpContent);
            Stream res = await httpResponseMessage.Content.ReadAsStreamAsync();
            callback(res);
        }

        // get请求
        public async static void get(RequestQo request, Object param, Action<Stream> callback)
        {
            string pram = BuildParam(request, param);
            Stream res = await client.GetStreamAsync(apiUri + request.uri + "?" + pram);
            callback(res);
        }


        // 构建请求参数
        public static Dictionary<string, string> buildeRquest(RequestQo request, Object param)
        {
            Dictionary<string, object> queryObj = new Dictionary<string, object> {
                {"action",request.action },
                {"deviceName","MI 10" },
                {"qtime",Helpers.DateToTicks(DateTime.Now) },
                {"ranstr",Helpers.getRandom() },
                {"sysVersion","10" },
            };
            string jsonRes = JsonConvert.SerializeObject(param);
            if (request.type == "REQUEST_BODY")
            {
                queryObj.Add("body", jsonRes);
            }
            else
            {
                queryObj.Add("query", jsonRes);
            }

            // 原始req
            var reqJson = JsonConvert.SerializeObject(queryObj);

            var dataKey = Helpers.readIni("dataKey", "");
            var aruKey = Helpers.readIni("aruKey", "lMOEEdGup12IvTv1");
            if (request.bol)
            {
                dataKey = aruKey;
            }

            return new Dictionary<string, string> {
                { "appid","app"},
                { "terminal","android"},
                { "version","4.8.0"},
                { "aru",Helpers.AesEncrypt(aruKey,request.action)},
                { "data",Helpers.AesEncrypt(dataKey,reqJson)},
                { "sign",Helpers.Md5(reqJson)},
            };
        }


        // getParams
        private static string BuildParam(RequestQo request, Object param)
        {
            var parms = "";

            Dictionary<string, string> dictionaries = buildeRquest(request,param);

            foreach (KeyValuePair<string, string> item in dictionaries)
            {
                parms += string.Format("{0}={1}&", item.Key, Uri.EscapeDataString(item.Value));

            }

            parms = parms.TrimEnd('&');

            return parms;
        }



    }
}
