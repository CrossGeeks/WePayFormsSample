using Newtonsoft.Json;

namespace WePayFormsSample.Models
{
    public class WePayUserResponse
    {
        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
    }
}
