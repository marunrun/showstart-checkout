using checkout.Constants;
using checkout.Entity.Qo;
using checkout.Entity.Vo;
using checkout.Exceptions;
using checkout.Helper;
using System.Text.Json;

namespace checkout.Services
{

    public static class UserService
    {

        // mobile
        private const string MOBILE = "mobile";

        // pwd
        private const string PWD = "pwd";

        // aesKey
        private const string AES_KEY = "aesKey";


        // uid
        private const string UID = "uid";

        // sign
        private const string SIGN = "sign";


        public static string getMobile()
        {
            return Preferences.Get(MOBILE, "");
        }

        public static void setMobile(string mobile)
        {
            Preferences.Set(MOBILE, mobile);
        }

        public static string getPwd()
        {
            return Preferences.Get(PWD, "");

        }

        public static void setPwd(string pwd)
        {
            Preferences.Set(PWD, pwd);
        }


        public static string getAESKey()
        {
            return Preferences.Get(AES_KEY, "");

        }
        public static void setAESKey(string AESKey)
        {
            Preferences.Set(AES_KEY, AESKey);

        }


        public static long getUid()
        {
            return Preferences.Get(UID, -1L);

        }
        public static void setUid(long uid)
        {
            Preferences.Set(UID, uid);

        }

        public static string getSign()
        {
            return Preferences.Get(SIGN, "");

        }
        public static void setSign(string sign)
        {
            Preferences.Set(SIGN, sign);

        }

        public static void Login(string moblie,string pwd)
        {
            LoginData loginData = new LoginData
            {
                name = moblie,
                password = pwd,
            };

            RequestUtil.post(Urls.LOGIN_PWD, loginData, (res) =>
            {
                LogHelpers.write(" 密码登陆：" + res);
                Result<UserInfo> result = JsonSerializer.Deserialize<Result<UserInfo>>(res);
                if (result.isSuccess())
                {
                    setMobile(moblie);
                    setPwd(pwd);
                    setUid(result.result.userId);
                    setSign(result.result.sign);
                }
                else
                {
                    throw new BusinessException(result.msg);
                }
            });
        }


        public static void initToken()
        {
            RequestUtil.post(Urls.MAKE_TOKEN, new object(), (res) =>
            {
                Result<string> result = JsonSerializer.Deserialize<Result<string>>(res);
                if (result.isSuccess())
                {
                    setAESKey(result.result);

                    Console.WriteLine("token 加载成功");
                }
                else
                {
                    throw new BusinessException("token 加载失败 : " + result.msg);
                }
            });
        }


    }
}
