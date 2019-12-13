using System;
using Newtonsoft.Json;

namespace WePayFormsSample.Models
{
    public class WePayEmailConfirmation
    {
        [JsonProperty("email_message")]
        public string Message { get; set; }
    }
}
