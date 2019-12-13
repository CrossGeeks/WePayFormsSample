using System;
using Newtonsoft.Json;

namespace WePayFormsSample.Models
{
    public class WePayUserRequest
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("original_ip")]
        public string OriginalIp { get; set; }

        [JsonProperty("original_device")]
        public string OriginalDevice { get; set; }

        [JsonProperty("tos_acceptance_time")]
        public int AcceptanceTime { get; set; } = Config.WePayAcceptTime;

        [JsonProperty("client_id")]
        public int ClientId { get; set; } = Config.WePayClientId;

        [JsonProperty("client_secret")]
        public string ClientSecret { get; set; } = Config.WePayClientSecret;

        [JsonProperty("scope")]
        public string Scope { get; set; } = Config.WePayScope;
    }
}
