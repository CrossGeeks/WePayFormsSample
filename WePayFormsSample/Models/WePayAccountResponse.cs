using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace WePayFormsSample.Models
{
    public class WPBalance
    {
        [JsonProperty("balance")]
        public decimal Balance { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("disputed_amount")]
        public double DisputedAmount { get; set; }

        [JsonProperty("incoming_pending_amount")]
        public double IncomingPendingAmount { get; set; }

        [JsonProperty("outgoing_pending_amount")]
        public double OutgoingPendingAmount { get; set; }

        [JsonProperty("reserved_amount")]
        public double ReservedAmount { get; set; }

        [JsonProperty("withdrawal_bank_name")]
        public string WithdrawalBankName { get; set; }

        [JsonProperty("withdrawal_next_time")]
        public long? WithdrawalNextTime { get; set; }

        [JsonProperty("withdrawal_period")]
        public string WithdrawalPeriod { get; set; }

        [JsonProperty("withdrawal_type")]
        public string WithdrawalType { get; set; }
    }

    public class Status
    {

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("incoming_payments_status")]
        public string IncomingPaymentsStatus { get; set; }

        [JsonProperty("outgoing_payments_status")]
        public string OutgoingPaymentsStatus { get; set; }

        [JsonProperty("account_review_status")]
        public string AccountReviewStatus { get; set; }
    }

    public class WePayAccountResponse
    {
        [JsonProperty("account_id")]
        public int AccountId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("owner_user_id")]
        public long OwnerUserId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("create_time")]
        public int CreateTime { get; set; }

        [JsonProperty("disablement_time")]
        public object DisablementTime { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("currencies")]
        public IList<string> Currencies { get; set; }

        [JsonProperty("action_reasons")]
        public IList<string> ActionReasons { get; set; }

        [JsonProperty("disabled_reasons")]
        public IList<object> DisabledReasons { get; set; }

        [JsonProperty("image_uri")]
        public object ImageUri { get; set; }

        [JsonProperty("supported_card_types")]
        public IList<string> SupportedCardTypes { get; set; }

        [JsonProperty("gaq_domains")]
        public IList<string> GaqDomains { get; set; }

        [JsonProperty("balances")]
        public IList<WPBalance> Balances { get; set; }

        [JsonProperty("statuses")]
        public IList<Status> Statuses { get; set; }

        [JsonProperty("support_phone_number")]
        public string SupportPhoneNumber { get; set; }

        [JsonIgnore]
        public string DefaultBankName { get { return Balances?.FirstOrDefault()?.WithdrawalBankName; } }
    }
}
