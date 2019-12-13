using System;
namespace WePayFormsSample.Models
{
    public class WepayConnectRequest
    {
        public string WepayUserId { get; set; }
        public string Email { get; set; }
        public string OriginalIpAddress { get; set; }
        public string OriginalDevice { get; set; }
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
    }
}
