using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using UI.eProduct.ApiUtils;
using UI.eProduct.Data.VM;
using UI.eProduct.Models;

namespace UI.eProduct.APIHelpers
{
    
    public class APIHelper
    {
        string _BaseURL = default;
        public string ApiResponseMessage(string ResponseMsg)
        {
            string Result = string.Empty;

            if (ResponseMsg.Length > 0)
            {
                Result = ResponseMsg;
                Result = Result.TrimStart('\"');
                Result = Result.TrimEnd('\"');
                Result = Result.Replace("\\", "");
            }
            return Result;
        }
        public APIHelper()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            _BaseURL = configuration.GetSection("apiBaseURL").Value.ToString();
        }

        public async Task<string> CreateCategory(ProductCategory category)
        {
            using (HttpClient client = new HttpClient())
            {
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                Uri u = new Uri(@"" + _BaseURL + "/api/ProductCategory/CreateCategory");
                var newCategory = new ProductCategory
                {
                    Description = category.Description
                };
                HttpContent c = new StringContent(JsonConvert.SerializeObject(newCategory), Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(u, c).Result;
                if (response.IsSuccessStatusCode)
                {
                    var contents = response.Content.ReadAsStringAsync().Result;
                    return contents;
                }
                return response.ReasonPhrase;
            }
        }
        public async Task<List<ProductCategory>> GetCategoryList()
        {
            List<ProductCategory> Categories = new List<ProductCategory>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                Uri u = new Uri(@"" + _BaseURL + "api/ProductCategory/GetProductCategories");
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync(u);
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    Categories = JsonConvert.DeserializeObject<List<ProductCategory>>(EmpResponse);
                }           
                
            }
            return Categories;
        }

        public async Task<AuthUser> Login(LoginVM loginVM)
        {
            
            using (var client = new HttpClient())
            {
                //Passing service base url
                
                Uri u = new Uri(@"" + _BaseURL + "api/Account/AuthenticateUser");
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpContent c = new StringContent(JsonConvert.SerializeObject(loginVM), Encoding.UTF8, "application/json");
                var token = new Token().GetToken();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage Res =  client.PostAsync(u, c).Result;
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var LoginResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    return JsonConvert.DeserializeObject<AuthUser>(LoginResponse);
                }
                else
                {
                    var contents = Res.Content.ReadAsStringAsync();

                    string responseMessage = ApiResponseMessage(contents.Result);
                    throw new Exception("LOGIN ATTEMPT FAILED" + (responseMessage.Length > 1 ? ": " + responseMessage : "."));
                }
            }
            
            
        } 
    }
}
