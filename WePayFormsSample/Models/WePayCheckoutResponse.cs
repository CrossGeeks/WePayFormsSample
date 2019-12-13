using System;
using Newtonsoft.Json;

namespace WePayFormsSample.Models
{
    public class ResponseFee
    {
        [JsonProperty("app_fee")]
        public decimal AppFee { get; set; }

        [JsonProperty("processing_fee")]
        public decimal ProcessingFee { get; set; }

        [JsonProperty("fee_payer")]
        public string FeePayer { get; set; }
    }

    public class Chargeback
    {

        [JsonProperty("amount_charged_back")]
        public int AmountChargedBack { get; set; }

        [JsonProperty("dispute_uri")]
        public object DisputeUri { get; set; }
    }

    public class Refund
    {

        [JsonProperty("amount_refunded")]
        public int AmountRefunded { get; set; }

        [JsonProperty("refund_reason")]
        public object RefundReason { get; set; }
    }

    public class ResponseHostedCheckout
    {

        [JsonProperty("checkout_uri")]
        public string CheckoutUri { get; set; }

        [JsonProperty("redirect_uri")]
        public object RedirectUri { get; set; }

        [JsonProperty("shipping_fee")]
        public int ShippingFee { get; set; }

        [JsonProperty("require_shipping")]
        public bool RequireShipping { get; set; }

        [JsonProperty("shipping_address")]
        public object ShippingAddress { get; set; }

        [JsonProperty("theme_object")]
        public object ThemeObject { get; set; }

        [JsonProperty("mode")]
        public string Mode { get; set; }

        [JsonProperty("auto_capture")]
        public bool AutoCapture { get; set; }
    }

    public class Payer
    {

        [JsonProperty("name")]
        public object Name { get; set; }

        [JsonProperty("email")]
        public object Email { get; set; }

        [JsonProperty("home_address")]
        public object HomeAddress { get; set; }
    }

    public class WePayCheckoutResponse
    {

        [JsonProperty("checkout_id")]
        public int CheckoutId { get; set; }

        [JsonProperty("account_id")]
        public int AccountId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("short_description")]
        public string ShortDescription { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("soft_descriptor")]
        public string SoftDescriptor { get; set; }

        [JsonProperty("create_time")]
        public int CreateTime { get; set; }

        [JsonProperty("gross")]
        public decimal Gross { get; set; }

        [JsonProperty("reference_id")]
        public object ReferenceId { get; set; }

        [JsonProperty("callback_uri")]
        public object CallbackUri { get; set; }

        [JsonProperty("long_description")]
        public object LongDescription { get; set; }

        [JsonProperty("delivery_type")]
        public object DeliveryType { get; set; }

        [JsonProperty("fee")]
        public ResponseFee Fee { get; set; }

        [JsonProperty("chargeback")]
        public Chargeback Chargeback { get; set; }

        [JsonProperty("refund")]
        public Refund Refund { get; set; }

        [JsonProperty("hosted_checkout")]
        public ResponseHostedCheckout HostedCheckout { get; set; }

        [JsonProperty("payment_method")]
        public object PaymentMethod { get; set; }

        [JsonProperty("payer")]
        public Payer Payer { get; set; }

        [JsonProperty("npo_information")]
        public object NpoInformation { get; set; }

        [JsonProperty("payment_error")]
        public object PaymentError { get; set; }

        [JsonProperty("in_review")]
        public bool InReview { get; set; }

        [JsonProperty("auto_release")]
        public bool AutoRelease { get; set; }
    }

}
