using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WePayFormsSample.Helpers;
using WePayFormsSample.Models;
using WePayFormsSample.Services;
using Xamarin.Forms;

namespace WePayFormsSample.ViewModels
{
    public class PaymentPageViewModel: INotifyPropertyChanged
    {
        public decimal Amount { get; set; } = 20;
        public bool IsBusy { get; set; }
        IWePayApiManager WePayApiManager { get; set; } = new WePayApiManager();
        public WePayCreditCard WePayCreditCard { get; set; }

        public PaymentPageViewModel()
        {
            WePayCreditCard = new WePayCreditCard()
            {
                ClientId = Config.WePayClientId,
                Address = new WePayAddress()
                {
                    Country = "US",
                    PostalCode = "12345"
                }
            };
        }
        public Command ProcessPaymentCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await CreateCreditCard();
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        async Task CreateCreditCard()
        {
            try
            {
                IsBusy = true;
                var createMessage = await WePayApiManager.CreateCreditCard(WePayCreditCard);

                var cMessage = await createMessage.Content.ReadAsStringAsync();
                if (createMessage.IsSuccessStatusCode)
                {
                    var creditCardResponse = JsonConvert.DeserializeObject<WePayCreditCardResponse>(cMessage);
                    await DoCheckOutAsync(creditCardResponse.CreditCardId);
                }
                else
                {
                    IsBusy = false;
                    var wepayResponse = JsonConvert.DeserializeObject<WePayErrorResponse>(cMessage);
                    await App.Current.MainPage.DisplayAlert("Error", $"{wepayResponse.ErrorDescription}", "Ok");
                }
            }
            catch (Exception ex)
            {
                IsBusy = false;
                await App.Current.MainPage.DisplayAlert("Error", "Error processing payment", "Ok");

            }
        }

        async Task DoCheckOutAsync(long creditCardId)
        {
            WePayCheckout WePayCheckout = new WePayCheckout()
            {
                Type = "goods",
                ShortDescription = $"Items purchased using My App.",
                Fee = new Fee()
                {
                    AppFee = 1,
                    FeePayer = "payer"
                }
            };

            WePayCheckout.DeliveryType = "point_of_sale";
            WePayCheckout.AccountId = Settings.AccountId;
            WePayCheckout.AutoRelease = true;
            WePayCheckout.Amount = Amount;
            WePayCheckout.Currency = "USD";
            WePayCheckout.HostedCheckout = null;
            WePayCheckout.PaymentMethod = new WePayPaymentMethod()
            {
                Type = "credit_card",
                CreditCardIdentifier = new CreditCardIdentifier()
                {
                    Id = creditCardId
                }
            };

            var response = await WePayApiManager.WePayCheckout($"Bearer {Settings.WePayAccessToken}", WePayCheckout);
            var message = await response.Content.ReadAsStringAsync();
            IsBusy = false;

            if (response.IsSuccessStatusCode)
            {
                var checkoutResponse = JsonConvert.DeserializeObject<WePayCheckoutResponse>(message);
                await App.Current.MainPage.DisplayAlert("Yayyy", $"Payment proceessed succesfully", "Ok");
                await App.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                var wepayResponse = JsonConvert.DeserializeObject<WePayErrorResponse>(message);
                await App.Current.MainPage.DisplayAlert("Error", $"{wepayResponse.ErrorDescription}", "Ok");
            }
        }
    }
}
