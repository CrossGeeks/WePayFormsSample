using System;
using System.Collections.Generic;
using WePayFormsSample.ViewModels;
using Xamarin.Forms;

namespace WePayFormsSample.Views
{
    public partial class WePaySignUpPage : ContentPage
    {
        public WePaySignUpPage()
        {
            InitializeComponent();
            this.BindingContext = new WePaySignUpPageViewModel();
        }
    }
}
