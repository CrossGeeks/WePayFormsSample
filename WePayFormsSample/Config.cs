using System;
namespace WePayFormsSample
{
    public class Config
    {
        public const int WePayClientId = 0;
        public const int WePayAccountId = 0;
        public const string WePayClientSecret = "";
        public static string WePayRedirectUri ="";
        public const string WePayAuthorizationUrl = "https://stage.wepay.com/v2/oauth2/authorize";
        public const string WePayApiUrl = "https://stage.wepayapi.com/v2";
        public const string WePayScope = "manage_accounts,collect_payments,view_user,send_money,preapprove_payments";
        public const int WePayAcceptTime = 1209600;
    }
}
