using System;
using WePayFormsSample.ViewModels;
using Xamarin.Forms;

namespace WePayFormsSample.Views
{
    public partial class WePaySignInPage : ContentPage
    {
        public WePaySignInPage()
        {
            InitializeComponent();
            this.BindingContext = new WePaySignInPageViewModel();
        }

        void WebOnEndNavigating(object sender, WebNavigatedEventArgs e)
        {
            LoadingIndicator.IsVisible = false;
            Browser.IsVisible = true;

            if (e.Url.ToLower().Contains("code="))
            {
                var parameters = new Uri(e.Url).Query.Split('&');

                foreach (var param in parameters)
                {
                    if (param.ToLower().Contains("code="))
                    {
                        var key = param.Split('=');
                        if (key.Length > 1 && key[0].Contains("code"))
                        {
                            var vm = BindingContext as WePaySignInPageViewModel;
                            vm.DoneCommand.Execute(key[1]);
                        }
                        break;
                    }
                }
            }
        }
    }
}
