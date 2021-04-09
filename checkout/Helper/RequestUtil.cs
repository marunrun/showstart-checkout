using checkout.Entity.Qo;
using checkout.Entity.Vo;
using checkout.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
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

            var handler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip
            };
            HttpClient httpClient = new HttpClient(handler);
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Add("Host", "api.showstart.com");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "okhttp/4.6.0");
            httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate");
            httpClient.DefaultRequestHeaders.Add("Connection", "Keep-Alive");
            httpClient.DefaultRequestHeaders.Add("Cookie", "u_s=http://api.showstart.com/app/user/bind/list.json; o_s=http://api.showstart.com/app/user/bind/list.json");
            return httpClient;
        }


        // 密码登陆
        public static Result<UserInfo> loginByPwd(LoginData loginData)
        {
            try
            {
                HttpContent httpContent = getContent(sign(loginData).Result);
                HttpResponseMessage result = client.PostAsync(apiUri + "app/user/login.json", httpContent).Result;

                return (Result<UserInfo>)JsonConvert.DeserializeObject(result.Content.ReadAsStringAsync().Result, typeof(Result<UserInfo>));
            }
            catch (Exception e)
            {
                LogHelpers.write(e.ToString());
                MessageBox.Show("服务异常，请重试");
                return new Result<UserInfo>();
            }
        }


        // 验证码登陆
        public static Result<UserSession> loginByVCode(CodeLoginData codeLoginData)
        {
            try
            {
                HttpContent httpContent = getContent(sign(codeLoginData).Result);
                HttpResponseMessage response = client.PostAsync(apiUri + "app/user/vc_login.json", httpContent).Result;
                string result = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(result);

                return (Result<UserSession>)JsonConvert.DeserializeObject(result, typeof(Result<UserSession>));
            }
            catch (Exception e)
            {
                LogHelpers.write(e.ToString());
                MessageBox.Show("服务异常，请重试");
                return new Result<UserSession>();
            }
        }


        // 发送验证码
        public async static void sendCode(SendCodeData sendCodeData, TextBox logText)
        {
            try
            {
                HttpContent httpContent = getContent(await sign(sendCodeData));
                HttpResponseMessage result = await client.PostAsync(apiUri + "app/sms/verifyCode.json", httpContent);
                string content = await result.Content.ReadAsStringAsync();
                Result<object> res = (Result<object>)JsonConvert.DeserializeObject(content, typeof(Result<object>));
                if (res.isSuccess())
                {
                    LogHelpers.write("验证码发送成功", logText);
                }
                else
                {
                    LogHelpers.write("验证码发送失败：" + res.msg, logText);
                }
            }
            catch (Exception e)
            {
                LogHelpers.write(e.ToString());
                MessageBox.Show("服务异常，请重试");
            }
        }


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
        }

        public async static void handleAddress(AddressQo addressQo, ComboBox comboBox)
        {
            HttpContent httpContent = getContent(await sign(addressQo));
            HttpResponseMessage httpResponseMessage = await client.PostAsync(apiUri + "app/address/list.json", httpContent);
            string result = await httpResponseMessage.Content.ReadAsStringAsync();
            Result<List<AddressInfo>> res = (Result<List<AddressInfo>>)JsonConvert.DeserializeObject(result, typeof(Result<List<AddressInfo>>));
            if (res.isSuccess())
            {
                comboBox.DataSource = res.result;
            }
        }

        // 获取post对应的HttpConten
        private static HttpContent getContent(String pSign)
        {
            return new FormUrlEncodedContent(getPublicList(pSign));
        }

        // 获取公共参数
        private static Dictionary<string, string> getPublicList(string pSign)
        {
            PublicData publicData = new PublicData
            {
                p_json_dig = pSign,
                sign = new UserService().getSign(),
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
            return dictionaries;
        }


        // getParams
        private static string BuildParam(string pSigny)
        {
            string parms = "";

            Dictionary<string, string> dictionaries = getPublicList(pSigny);

            foreach (KeyValuePair<string, string> item in dictionaries)
            {
                parms += string.Format("{0}={1}&", item.Key, Uri.EscapeDataString(item.Value));

            }

            parms = parms.TrimEnd('&');

            Console.WriteLine(parms);
            return parms;
        }


        public async static Task<string> sign(Object obj)
        {
            return await sign(JsonConvert.SerializeObject(obj));
        }

        // 加签
        public async static Task<string> sign(String args)
        {
            string content = "";
            try
            {
                StringContent stringContent = new StringContent(args, Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponseMessage = client.PostAsync(signUri + "showstart/sign", stringContent).Result;
                content = await httpResponseMessage.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                LogHelpers.write(e.ToString());
                MessageBox.Show("服务器异常 请重试");
            }

            return content;
        }


        public async static void post(string uri, Object param, Action<string> callback)
        {
            HttpContent httpContent = getContent(await sign(param));
            HttpResponseMessage httpResponseMessage = await client.PostAsync(apiUri + uri, httpContent);
            string res = await httpResponseMessage.Content.ReadAsStringAsync();
            callback(res);
        }


        public async static void get(string uri, Object param, Action<string> callback)
        {
            string pram = BuildParam(await sign(param));
            HttpResponseMessage httpResponseMessage = await client.GetAsync(apiUri + uri + "?" + pram);
            string res = await httpResponseMessage.Content.ReadAsStringAsync();
            callback(res);
        }

        public async static void get(string uri, Object param, Action<string> callback,bool signed = true)
        {
            string pram = BuildParam(await sign(param));
            HttpResponseMessage httpResponseMessage = await client.GetAsync(apiUri + uri + "?" + pram);
            string res = await httpResponseMessage.Content.ReadAsStringAsync();
            callback(res);
        }
    }
}
