using System.ComponentModel;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WePayFormsSample.Helpers;
using WePayFormsSample.Models;
using WePayFormsSample.Services;
using Xamarin.Forms;

namespace WePayFormsSample.ViewModels
{
    public class WePaySignInPageViewModel: INotifyPropertyChanged
    {
        public string AuthorizationUrl { get; set; } = $"{Config.WePayAuthorizationUrl}?client_id={Config.WePayClientId}&user_email={Settings.UserEmail}&redirect_uri={Config.WePayRedirectUri}&scope={Config.WePayScope}";
        IWePayApiManager WePayApiManager { get; set; } = new WePayApiManager();

        public Command<string> DoneCommand
        {
            get
            {
                return new Command<string>(async (code) =>
                {
                    await Done(code);
                });
            }
        }

        async Task Done(string code)
        {
            if (!string.IsNullOrEmpty(code))
            {
                var responseMessage = await WePayApiManager.GetWePayAccessToken(new WePayTokenRequest()
                {
                    ClientId = Config.WePayClientId,
                    ClientSecret = Config.WePayClientSecret,
                    RedirectUri = Config.WePayRedirectUri,
                    Code = code
                });

                if (responseMessage != null && responseMessage.IsSuccessStatusCode)
                {
                    var message = await responseMessage.Content.ReadAsStringAsync();
                    WePayUserResponse userResponse = JsonConvert.DeserializeObject<WePayUserResponse>(message);
                    Settings.WePayAccessToken = userResponse.AccessToken;
                    Settings.WePayUserId = userResponse.UserId;

                    //TODO: Handle navigation 
                    await App.Current.MainPage.Navigation.PopAsync();
                }
            }

        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
