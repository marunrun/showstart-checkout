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



        private static string mobile = "";

        public static string getMobile()
        {
            return Preferences.Default.Get(MOBILE, mobile);
        }

        public static void setMobile(string mobile)
        {
            mobile = mobile;
            Preferences.Default.Set(MOBILE, mobile);
        }

        private static string pwd = "";

        public static string getPwd()
        {
            return Preferences.Default.Get(PWD, pwd);

        }

        public static void setPwd(string pwd)
        {
            pwd = pwd;
            Preferences.Default.Set(PWD, pwd);
        }

        private static string aesKey = "";

        public static string getAESKey()
        {
            if (!string.IsNullOrWhiteSpace(aesKey)) {
                return aesKey;
            }
            return Preferences.Default.Get(AES_KEY, aesKey);

        }
        public static void setAESKey(string AESKey)
        {
            
            Preferences.Default.Set(AES_KEY, AESKey);
            aesKey = AESKey;
        }


        private static long uid = -1L;

        public static long getUid()
        {
            return Preferences.Default.Get(UID, uid);

        }
        public static void setUid(long uid)
        {
            uid = uid;
            Preferences.Default.Set(UID, uid);

        }
        private static string sign = "";

        public static string getSign()
        {
            return Preferences.Default.Get(SIGN, sign);

        }
        public static void setSign(string sign)
        {
            sign = sign;
            Preferences.Default.Set(SIGN, sign);

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


        public async static void initToken()
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
