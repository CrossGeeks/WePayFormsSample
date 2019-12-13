using System;
using Newtonsoft.Json;

namespace WePayFormsSample.Models
{
    public class WePayAccountRequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("reference_id")]
        public string ReferenceId { get; set; }

        [JsonIgnore]
        public string BankName { get; set; }

    }
}