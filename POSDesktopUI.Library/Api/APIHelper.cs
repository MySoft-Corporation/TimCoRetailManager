using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TRMDesktopUI.Models;

namespace POSDesktopUI.Library.Api
{
    public class APIHelper : IAPIHelper
    {
        private HttpClient apiClient;
        private ILoggedInUserModel _loggedInUserModel;
        public APIHelper(ILoggedInUserModel loggedInUser)
        {
            InitializeClient();
            _loggedInUserModel = loggedInUser;
        }
        private void InitializeClient()
        {
            apiClient = new HttpClient();
            apiClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["api"]);
            apiClient.DefaultRequestHeaders.Accept.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
        public async Task<AuthenticatedUser> Authenticate(string userName, string password)
        {
            FormUrlEncodedContent data = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string,string>("grant_type","password"),
                new KeyValuePair<string,string>("username",userName),
                new KeyValuePair<string,string>("password",password)
            });
            using (HttpResponseMessage httpResponseMessage = await apiClient.PostAsync("/Token", data))
            {
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var result = await httpResponseMessage.Content.ReadAsAsync<AuthenticatedUser>();
                    return result;
                }
                else
                {
                    throw new Exception(httpResponseMessage.ReasonPhrase);
                }
            }
        }

        public async Task GetLoggedInUserInfo(string token)
        {
            apiClient.DefaultRequestHeaders.Clear();
            apiClient.DefaultRequestHeaders.Accept.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            apiClient.DefaultRequestHeaders.Add("Authorization", $"bearer {token}");
            using (HttpResponseMessage httpResponseMessage = await apiClient.GetAsync("/api/User"))
            {
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    LoggedInUserModel result = await httpResponseMessage.Content.ReadAsAsync<LoggedInUserModel>();
                    _loggedInUserModel.CreatedDate = result.CreatedDate;
                    _loggedInUserModel.EmailAddress = result.EmailAddress;
                    _loggedInUserModel.Id = result.Id;
                    _loggedInUserModel.FirstName = result.FirstName;
                    _loggedInUserModel.LastName = result.LastName;
                    _loggedInUserModel.Token = result.Token;
                }
                else
                {
                    throw new Exception(httpResponseMessage.ReasonPhrase);
                }
            }
        }

    }
}
