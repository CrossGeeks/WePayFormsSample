using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WePayFormsSample.Models
{
    public class WePayErrorResponse
    {
        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }

        [JsonProperty("error_code")]
        public int ErrorCodeValue { get; set; }

        [JsonIgnore]
        public WePayErrorCode ErrorCode { get => (WePayErrorCode)ErrorCodeValue; }

        [JsonProperty("details")]
        public IList<object> Details { get; set; }

        [JsonProperty("documentation_url")]
        public string DocumentationUrl { get; set; }
    }
    public enum WePayErrorCode
    {
        AccountDoesNotExist = 3001,
        AccountTokenDoesNotHavePermission = 3002,
        AccountHasBeenDeleted = 3003,
        AccountCannotTransact = 3004
    }
}
