using System;
using Newtonsoft.Json;

namespace WePayFormsSample.Models
{
    public class WePayTokenRequest
    {
        [JsonProperty("client_id")]
        public int ClientId { get; set; }

        [JsonProperty("client_secret")]
        public string ClientSecret { get; set; }

        [JsonProperty("redirect_uri")]
        public string RedirectUri { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }
    }
}
