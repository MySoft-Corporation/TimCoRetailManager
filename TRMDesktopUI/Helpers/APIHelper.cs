using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TRMDesktopUI.Models;

namespace TRMDesktopUI.Helpers
{
    public class APIHelper : IAPIHelper
    {
        private HttpClient APIClient; 
        public APIHelper()
        {
            InitializeClient();
        }
        private void InitializeClient()
        {
            APIClient = new HttpClient();
            APIClient.DefaultRequestHeaders.Accept.Clear();
            APIClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["api"]);
            APIClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
        public async Task<AuthenticatedUser> AuthenticateAsync(string userName, string password)
        {
            FormUrlEncodedContent data = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string,string>("grant_type","password"),
                new KeyValuePair<string,string>("username",userName),
                new KeyValuePair<string,string>("password",password)
            });
            HttpResponseMessage httpResponseMessage = await APIClient.PostAsync("/Token", data);
            return httpResponseMessage.IsSuccessStatusCode
                ? await httpResponseMessage.Content.ReadAsAsync<AuthenticatedUser>()
                : throw new Exception(httpResponseMessage.ReasonPhrase);
        }
    }
}
