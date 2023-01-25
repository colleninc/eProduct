using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using UI.eProduct.Data.VM;

namespace UI.eProduct.ApiUtils
{
    public class Token
    {
        private string _BaseURL;
        private string _apiUserName;
        private string _apiPassword;
        public Token()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            _BaseURL = configuration.GetSection("apiBaseURL").Value;
            _apiUserName = configuration.GetSection("apiUserName").Value;
            _apiPassword = configuration.GetSection("apiPassword").Value;
        }
        public string GetToken()
        {
            try
            {
                string result = string.Empty;
                using (HttpClient client = new HttpClient())
                {
                    var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                    Uri u = new Uri(@"" + _BaseURL + "/api/auth/GetToken");
                    var payload = new LoginVM
                    {
                        EmailAddress = _apiUserName,
                        Password = _apiPassword
                    };
                    HttpContent c = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PostAsync(u, c).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var contents = response.Content.ReadAsStringAsync().Result;
                        return contents;
                    }
                    return response.ReasonPhrase;
                }
            }
            catch (Exception ex)
            {
                throw new Exception
                (
                    "an error occured while trying to get api Token: " + ex.InnerException != null ? ex.InnerException.Message : ex.Message
                );
            }
        }
    }
}
