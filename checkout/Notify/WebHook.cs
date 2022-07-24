using checkout.Entity.Vo;
using checkout.Helper;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace checkout.Notify
{



    internal class WebHook : BaseNotifyer
    {
        public const string DING = "dingtalk";
        public const string WE = "wechat";


        public const string WEB_HOOK_URL = "web_hook_url";
        public const string WEB_HOOK_SECRET = "web_hook_secret";

        public const string TYPE_SELECT = "webhook_type_select";


        protected override async void execute(string content, Action<string> action)
        {

            var type = Helpers.readIni(TYPE_SELECT, DING);

            var url = Helpers.readIni(WEB_HOOK_URL, "");

            HttpContent httpContent;
            var client = new HttpClient();
            var param = new Dictionary<string, Object>();
            string result = "";
            switch (type)
            {
                case DING:

                    var secret = Helpers.readIni(WEB_HOOK_SECRET, "");
                    if (!string.IsNullOrEmpty(secret.Trim()))
                    {
                        var timestamp = Helpers.CurrentTimeStamp();
                        String stringToSign = timestamp + "\n" + secret;
                        //Mac mac = Mac.getInstance("HmacSHA256");
                        var mac = new HMACSHA256(Encoding.UTF8.GetBytes(secret));
                        //
                        var hash = mac.ComputeHash(Encoding.UTF8.GetBytes(stringToSign));
                        var sign = Convert.ToBase64String(hash);

                        url += ("&timestamp=" + timestamp);
                        url += ("&sign=" + sign);
                    }


                    param.Add("msgtype", "markdown");
                    var markdown = new DingtalkMarkdown();
                    markdown.title = "秀动辅助";
                    markdown.text = content;
                    param.Add("markdown", markdown);

                    httpContent = new StringContent(JsonSerializer.Serialize(param));
                    httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    var response = await client.PostAsync(url, httpContent);
                    result = await response.Content.ReadAsStringAsync();


                    break;
                case WE:
                    param.Add("msgtype", "markdown");
                    var wemarkdown = new WeMarkdown();
                    wemarkdown.content = content;

                    param.Add("markdown", wemarkdown);

                    httpContent = new StringContent(JsonSerializer.Serialize(param));
                    httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    var weResponse = await client.PostAsync(url, httpContent);
                    result = await weResponse.Content.ReadAsStringAsync();
                    break;
            }
            action(result);
        }

        public class DingtalkMarkdown
        {
            public string title { get; set; }

            public string text { get; set; }

        }

        public class WeMarkdown
        {
            public string content { get; set; }
        }


    }
}
