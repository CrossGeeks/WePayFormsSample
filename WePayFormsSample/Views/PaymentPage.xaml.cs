using WePayFormsSample.ViewModels;
using Xamarin.Forms;

namespace WePayFormsSample.Views
{
    public partial class PaymentPage : ContentPage
    {
        public PaymentPage()
        {
            InitializeComponent();
            this.BindingContext = new PaymentPageViewModel();
        }
    }
}
