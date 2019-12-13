using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Refit;
using WePayFormsSample.Models;

namespace WePayFormsSample.Services
{
    [Headers("User-Agent: MyXamarinFormsApp")]
    public interface IWePayApi
    {
        //Signup
        [Post("/user/register")]
        Task<HttpResponseMessage> RegisterUser([Body] WePayUserRequest wePayUser);

        [Post("/account/create")]
        Task<HttpResponseMessage> CreateAccount([Header("Authorization")] string accessToken, [Body] WePayAccountRequest wePayAccount);

        [Post("/user/send_confirmation")]
        Task<HttpResponseMessage> SendConfirmation([Header("Authorization")] string accessToken, [Body] WePayEmailConfirmation emailConfirmation);

        //Login
        [Post("/oauth2/token")]
        Task<HttpResponseMessage> GetAccessToken([Body] WePayTokenRequest wePayToken);

        //Get account info
        [Post("/account/find")]
        Task<HttpResponseMessage> GetAccounts([Header("Authorization")] string accessToken, [Body] IDictionary<string, object> findAccount);

        //Payment
        [Post("/credit_card/create")]
        Task<HttpResponseMessage> CreateCreditCard([Body]WePayCreditCard request);

        [Post("/checkout/create")]
        Task<HttpResponseMessage> Checkout([Header("Authorization")] string accessToken, [Body] WePayCheckout emailConfirmation);

       

    }
}
