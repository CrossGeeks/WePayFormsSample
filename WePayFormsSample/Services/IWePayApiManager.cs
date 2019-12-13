using System;
using System.Net.Http;
using System.Threading.Tasks;
using WePayFormsSample.Models;

namespace WePayFormsSample.Services
{
    public interface IWePayApiManager
    {
        Task<HttpResponseMessage> RegisterWePayUser(WePayUserRequest request);
        Task<HttpResponseMessage> CreateWePayAccount(string accessToken, WePayAccountRequest request);
        Task<HttpResponseMessage> SendWePayConfirmationEmail(string accessToken, WePayEmailConfirmation request);
        Task<HttpResponseMessage> GetWePayAccessToken(WePayTokenRequest request);
        Task<HttpResponseMessage> GetWePayAccounts(string accessToken);
        Task<HttpResponseMessage> CreateCreditCard(WePayCreditCard request);
        Task<HttpResponseMessage> WePayCheckout(string accessToken, WePayCheckout request);
    }
}
