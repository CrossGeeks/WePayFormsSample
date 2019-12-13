using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WePayFormsSample.Models
{
    public class EmailMessage
    {

        [JsonProperty("to_payer")]
        public string ToPayer { get; set; }

        [JsonProperty("to_payee")]
        public string ToPayee { get; set; }
    }

    public class Fee
    {

        [JsonProperty("app_fee")]
        public decimal AppFee { get; set; }

        [JsonProperty("fee_payer")]
        public string FeePayer { get; set; }
    }

    public class PrefillInfo
    {

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("zip")]
        public string Zip { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }
    }

    public class ThemeObject
    {

        [JsonProperty("name")]
        public string Name { get; set; } = "TallySheet App Theme";

        [JsonProperty("primary_color")]
        public string PrimaryColor { get; set; } = "EF5D34";

        [JsonProperty("background_color")]
        public string BackgroundColor { get; set; } = "E9E9E9";

        [JsonProperty("button_color")]
        public string ButtonColor { get; set; } = "7ECAB5";

        [JsonProperty("secondary_color")]
        public string SecondaryColor { get; set; } = "7ECAB5";
    }

    public class HostedCheckout
    {
        [JsonProperty("theme_object")]
        public ThemeObject ThemeObject { get; set; } = new ThemeObject();

        [JsonProperty("funding_sources")]
        public IList<string> FundingSources { get; set; } = new List<string>()
        {
            "credit_card"
        };
    }

    public class WePayCheckout
    {

        [JsonProperty("account_id")]
        public int AccountId { get; set; }

        [JsonProperty("unique_id")]
        public string UniqueId { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("short_description")]
        public string ShortDescription { get; set; }

        [JsonProperty("long_description")]
        public string LongDescription { get; set; }

        [JsonProperty("email_message")]
        public EmailMessage EmailMessage { get; set; }

        [JsonProperty("delivery_type")]
        public string DeliveryType { get; set; }

        [JsonProperty("fee")]
        public Fee Fee { get; set; }

        [JsonProperty("callback_uri")]
        public string CallbackUri { get; set; }

        [JsonProperty("auto_release")]
        public bool AutoRelease { get; set; }

        [JsonProperty("payment_method")]
        public WePayPaymentMethod PaymentMethod { get; set; }

        [JsonProperty("hosted_checkout")]
        public HostedCheckout HostedCheckout { get; set; } = new HostedCheckout();
    }

    public class WePayCheckoutRequest
    {
        [JsonProperty("checkout_id")]
        public int CheckoutId { get; set; }
    }

    public class CreditCardIdentifier
    {
        [JsonProperty("id")]
        public long Id { get; set; }
    }

    public class WePayPaymentMethod
    {

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("credit_card")]
        public CreditCardIdentifier CreditCardIdentifier { get; set; }
    }
}
