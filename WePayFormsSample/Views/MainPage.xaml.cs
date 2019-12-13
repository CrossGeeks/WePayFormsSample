using System;
using System.Collections.Generic;
using WePayFormsSample.ViewModels;
using Xamarin.Forms;

namespace WePayFormsSample.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MainPageViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if(BindingContext is MainPageViewModel context)
            {
                context.GetWePayAccountCommand.Execute(null);
            }
        }
    }
}
