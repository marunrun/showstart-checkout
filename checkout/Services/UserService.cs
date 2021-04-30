using checkout.Helper;


namespace checkout.Services
{

    class UserService
    {
        private static UserService instance;

        public static UserService getInstance() 
        {
            if (instance == null) {
                instance = new UserService();
            }

            return instance;
        }

        private UserService() { }

        public string tel { get; set; }

        public string sign { get; set; }

        public long userId { get; set; }

    }
}
