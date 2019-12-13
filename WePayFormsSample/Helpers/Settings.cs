using Xamarin.Essentials;

namespace WePayFormsSample.Helpers
{
    public static class Settings
    {
        private const string WePayAccessTokenKey = "token_key";
        public static string WePayAccessToken
        {
            get
            {
                return Preferences.Get(WePayAccessTokenKey, "");
            }
            set
            {
                Preferences.Set(WePayAccessTokenKey, value);
            }
        }

        private const string WePayUserIdKey = "wepayuserId_key";
        public static string WePayUserId
        {
            get
            {
                return Preferences.Get(WePayUserIdKey, "");
            }
            set
            {
                Preferences.Set(WePayUserIdKey, value);
            }
        }

        private const string EmailKey = "email_key";
        public static string UserEmail
        {
            get
            {
                return Preferences.Get(EmailKey, "");
            }
            set
            {
                Preferences.Set(EmailKey, value);
            }
        }

        private const string AccountIdKey = "accountId";
        public static int AccountId
        {
            get
            {
                return Preferences.Get(AccountIdKey, 0);
            }
            set
            {
                Preferences.Set(AccountIdKey, value);
            }
        }

        public static void ClearSettings()
        {
            Preferences.Remove(AccountIdKey);
            Preferences.Remove(WePayUserIdKey);
            Preferences.Remove(WePayAccessTokenKey);
        }
    }
}
