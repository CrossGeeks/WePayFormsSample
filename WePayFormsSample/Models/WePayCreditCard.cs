using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace WePayFormsSample.Models
{
    public class WePayAddress
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }
    }

    public class WePayCreditCard: INotifyPropertyChanged
    {
        [JsonProperty("client_id")]
        public int ClientId { get; set; }

        [JsonProperty("user_name")]
        public string UserName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("cc_number")]
        public string CcNumber { get; set; }

        [JsonProperty("cvv")]
        public string Cvv { get; set; }

        [JsonProperty("expiration_month")]
        public int ExpirationMonth { get { return (!string.IsNullOrEmpty(ExpirationDate)) ? int.Parse(ExpirationDate.Substring(0, 2)) : 0; } }

        [JsonProperty("expiration_year")]
        public int ExpirationYear { get { return (!string.IsNullOrEmpty(ExpirationDate)) ? int.Parse($"{DateTime.Now.ToString("yyyy").Substring(0, 2)}{ExpirationDate.Substring(2, 2)}") : 0; } }

        [JsonProperty("address")]
        public WePayAddress Address { get; set; }

        [JsonIgnore]
        public string ExpirationDate { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class WePayCreditCardResponse
    {

        [JsonProperty("credit_card_id")]
        public long CreditCardId { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }
    }

}
