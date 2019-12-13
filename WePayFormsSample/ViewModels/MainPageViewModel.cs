using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WePayFormsSample.Helpers;
using WePayFormsSample.Models;
using WePayFormsSample.Services;
using WePayFormsSample.Views;
using Xamarin.Forms;

namespace WePayFormsSample.ViewModels
{
    public class MainPageViewModel: INotifyPropertyChanged
    {
        IWePayApiManager WePayApiManager { get; set; } = new WePayApiManager();
        public WePayAccountResponse WePayAccount { get; set; }
        public bool IsPaymentConnected { get { return WePayAccount != null; } }
        public bool IsBusy { get; set; }

        public Command GoToPaymentViewCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await App.Current.MainPage.Navigation.PushAsync(new PaymentPage());
                });
            }
        }

        public Command GetWePayAccountCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await GetWePayAccountInfoAsync();
                });
            }
        }


        async Task GetWePayAccountInfoAsync()
        {
            try
            {
                if (!string.IsNullOrEmpty(Settings.WePayAccessToken))
                {
                    IsBusy = true;
                    var accountResponse = await WePayApiManager.GetWePayAccounts($"Bearer {Settings.WePayAccessToken}");
                    if (accountResponse.IsSuccessStatusCode)
                    {
                        var accountResponseString = await accountResponse.Content.ReadAsStringAsync();

                        var accountList = JsonConvert.DeserializeObject<IList<WePayAccountResponse>>(accountResponseString);

                        if (accountList.Count > 0)
                        {
                            WePayAccount = accountList.FirstOrDefault();
                            Settings.AccountId = WePayAccount.AccountId;
                        }
                    }
                }
            }
            catch (Exception) { }
            finally
            {
                IsBusy = false;
            }
        }

        public Command SignInCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await App.Current.MainPage.Navigation.PushAsync(new WePaySignInPage());
                });
            }
        }

        public Command SignupCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await App.Current.MainPage.Navigation.PushAsync(new WePaySignUpPage());

                });
            }
        }

        public Command DisconnectCommand
        {
            get
            {
                return new Command(async () =>
                {
                    Settings.ClearSettings();
                    WePayAccount = null;
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
