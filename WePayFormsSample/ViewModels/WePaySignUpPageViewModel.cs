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
    public class WePaySignUpPageViewModel : INotifyPropertyChanged
    {
        public WePayUserRequest AccountData { get; set; }
        IWePayApiManager WePayApiManager { get; set; } = new WePayApiManager();
        public bool IsBusy { get; set; }

        public WePaySignUpPageViewModel()
        {
            AccountData = new WePayUserRequest()
            {
                OriginalIp = "192.168.2.1", 
                OriginalDevice = $"{Xamarin.Essentials.DeviceInfo.Platform} {Xamarin.Essentials.DeviceInfo.VersionString}",
            };
        }

        public Command DoSignUpCommand
        {
            get
            {
                return new Command(async () =>
                {
                    if (!string.IsNullOrEmpty(AccountData.FirstName) &&
                        !string.IsNullOrEmpty(AccountData.LastName) &&
                        !string.IsNullOrEmpty(AccountData.Email))
                    {
                        await RegisterUser();
                    }
                });
            }
        }

        async Task RegisterUser()
        {
            try
            {
                IsBusy = true;
                var createMessage = await WePayApiManager.RegisterWePayUser(AccountData);
                if (createMessage.IsSuccessStatusCode)
                {
                    var cMessage = await createMessage.Content.ReadAsStringAsync();
                    var accountResponse = JsonConvert.DeserializeObject<WePayUserResponse>(cMessage);
                    var result = await OnCreateDefaultWePayAccountAsync(accountResponse);
                    if (result)
                    {
                        Settings.WePayAccessToken = accountResponse.AccessToken;
                        Settings.WePayUserId = accountResponse.UserId;
                        Settings.UserEmail = AccountData.Email;

                        //Handle navigation
                        await App.Current.MainPage.Navigation.PopAsync();

                        await SendEmailAsync(accountResponse);
                    }
                }
                else
                {
                    IsBusy = false;
                    await App.Current.MainPage.DisplayAlert("Error", "Unable to create account", "Ok");

                }
            }
            catch (Exception)
            {
                IsBusy = false;
                await App.Current.MainPage.DisplayAlert("Error", "Unable to create account", "Ok");
            }
        }

    
        async Task<bool> OnCreateDefaultWePayAccountAsync(WePayUserResponse data)
        {
            var wePayRequestModel = new WePayAccountRequest
            {
                ReferenceId = $"Test Account: {AccountData.Email}",
                Name = "My App",
                Description = "This is a test App description"
            };
            var createMessage = await WePayApiManager.CreateWePayAccount($"Bearer {data.AccessToken}", wePayRequestModel);

            return (createMessage != null && createMessage.IsSuccessStatusCode);
        }

        async Task<bool> SendEmailAsync(WePayUserResponse data)
        {
            var sendMessage = await WePayApiManager.SendWePayConfirmationEmail($"Bearer {data.AccessToken}", new WePayEmailConfirmation()
            {
                Message = "Welcome to my App Payments"
            });
            return (sendMessage.IsSuccessStatusCode);
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
