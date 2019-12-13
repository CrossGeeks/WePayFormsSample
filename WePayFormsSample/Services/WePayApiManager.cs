using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Refit;
using WePayFormsSample.Models;

namespace WePayFormsSample.Services
{
    public class WePayApiManager: IWePayApiManager
    {
        public async Task<HttpResponseMessage> RegisterWePayUser(WePayUserRequest request)
        {
            var wePayaPI = RestService.For<IWePayApi>(Config.WePayApiUrl);
            return await wePayaPI.RegisterUser(request);
        }

        public async Task<HttpResponseMessage> CreateWePayAccount(string accessToken, WePayAccountRequest request)
        {
            var wePayaPI = RestService.For<IWePayApi>(Config.WePayApiUrl);
            return await wePayaPI.CreateAccount(accessToken, request);
        }

        public async Task<HttpResponseMessage> SendWePayConfirmationEmail(string accessToken, WePayEmailConfirmation request){
            var wePayaPI = RestService.For<IWePayApi>(Config.WePayApiUrl);
            return await wePayaPI.SendConfirmation(accessToken, request);
        }

        public async Task<HttpResponseMessage> GetWePayAccessToken(WePayTokenRequest request)
        {
            var wePayaPI = RestService.For<IWePayApi>(Config.WePayApiUrl);
            return await wePayaPI.GetAccessToken(request);
        }

        public async Task<HttpResponseMessage> GetWePayAccounts(string accessToken)
        {
            var wePayaPI = RestService.For<IWePayApi>(Config.WePayApiUrl);
            return await wePayaPI.GetAccounts(accessToken, new Dictionary<string, object>() { { "sort_order", "desc" } });
        }

        public async Task<HttpResponseMessage> CreateCreditCard(WePayCreditCard request)
        {
            var wePayaPI = RestService.For<IWePayApi>(Config.WePayApiUrl);
            return await wePayaPI.CreateCreditCard(request);
        }

        public async Task<HttpResponseMessage> WePayCheckout(string accessToken, WePayCheckout request)
        {
            var wePayaPI = RestService.For<IWePayApi>(Config.WePayApiUrl);
            return await wePayaPI.Checkout(accessToken, request);
        }
    }
}
