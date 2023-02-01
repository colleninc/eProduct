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
using Microsoft.AspNetCore.Http;
using UI.eProduct.Data;
using System.Linq;

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
        
        #region Account
        public async Task<AuthUser> Login(LoginVM loginVM)
        {

            using (var client = new HttpClient())
            {
                //Passing service base url

                Uri u = new Uri(@"" + _BaseURL + "api/Account/AuthenticateUser");
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var obj = JsonConvert.SerializeObject(loginVM);

                HttpContent c = new StringContent(obj, Encoding.UTF8, "application/json");
                //var token = new Token().GetToken();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage Res = client.PostAsync(u, c).Result;
               
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

        private async Task<string> BuildOrderItemsBody(List<ShoppingBasketItems> cartItems, string DisplayName)
        {
            StringBuilder sBody = new StringBuilder();
            const string NEWLINE = "<tr><td></td></tr>";
            sBody.Append("<table>");
            sBody.Append($"<tr><td>Good day {DisplayName}</td></tr>");
            sBody.Append(NEWLINE);
            sBody.Append("<tr><td><b>Your shopping basket summary</b></td></tr>");
            sBody.Append("<tr><td><table>");
            sBody.Append("<thead>");
            sBody.Append("<tr>");
            sBody.Append("<th>Quantity</th><th>Product</th><th>Price</th><th>Subtotal</th>");                   
            sBody.Append("</tr>");
            sBody.Append("</thead>");
            sBody.Append("<tbody>");
            foreach (var item in cartItems)
            {
                sBody.Append("<tr>");
                sBody.Append($"<td>{item.Quantity}</td>");
                sBody.Append($"<td>{item.Product.ProductName}</td>");
                sBody.Append($"<td>{item.Product.Price.ToString("c")}</td>");
                sBody.Append($"<td>{(item.Quantity * item.Product.Price).ToString("c")}</td>");
                sBody.Append("<tr>");
            } 
            sBody.Append("</tbody>");            
            sBody.Append("<tfoot><tr>");            
            sBody.Append("<td colspan='2'></td>");
            sBody.Append("<td><b>Total:</b></td>");            
            sBody.Append($"<td>{cartItems.Select(n => n.Product.Price * n.Quantity).Sum().ToString("c")}</td>");
            sBody.Append("</tr></tfoot>");
            sBody.Append("</td></tr></table>");
            sBody.Append("</table>");
            return sBody.ToString();
        }
        public async Task<string> SendOrderComfirmation(List<ShoppingBasketItems> cartItems, string email, string displayName)
        {
            try
            {
                MailRequest mailRequest = new MailRequest { 
                 Body = await BuildOrderItemsBody(cartItems, displayName),
                 ToEmail= email,
                 Subject = "eProduct - Order Confirmation"
                };

                using (var client = new HttpClient())
                {
                    //Passing service base url

                    Uri u = new Uri(@"" + _BaseURL + "api/Notification/Send");
                    client.DefaultRequestHeaders.Clear();
                    //Define request data format
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var obj = JsonConvert.SerializeObject(mailRequest);

                    HttpContent c = new StringContent(obj, Encoding.UTF8, "application/json");
                    HttpResponseMessage Res = client.PostAsync(u, c).Result;

                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api
                        var EmailResponse = Res.Content.ReadAsStringAsync().Result;
                        //Deserializing the response recieved from web api and storing into the Employee list
                        return EmailResponse;
                    }
                    else
                    {
                        var contents = Res.Content.ReadAsStringAsync();

                        string responseMessage = ApiResponseMessage(contents.Result);
                        return responseMessage;
                    }
                }
            }
            catch
            {
                return "Error sending email";
            }
        }

        public async Task<string> RegisterUser(RegisterVM regVM)
        {
            using (var client = new HttpClient())
            {
                //Passing service base url

                Uri u = new Uri(@"" + _BaseURL + "api/Account/Register");
                client.DefaultRequestHeaders.Clear();
                
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

               HttpContent c = new StringContent(JsonConvert.SerializeObject(regVM), Encoding.UTF8, "application/json");
                //var token = new Token().GetToken();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage Res = client.PostAsync(u, c).Result;
                
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var RegisterResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    return RegisterResponse; //JsonConvert.DeserializeObject<AuthUser>(RegisterResponse);
                }
                else
                {
                    var contents = Res.Content.ReadAsStringAsync();
                    string responseMessage = ApiResponseMessage(contents.Result);
                    throw new Exception("REGISTER ATTEMPT FAILED" + (responseMessage.Length > 1 ? ": " + responseMessage : "."));
                }
            }

        }
        #endregion

        #region Product

        public async Task<string> AddNewProductAsync(NewProductVM newproduct)
        {
            using (HttpClient client = new HttpClient())
            {
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                Uri u = new Uri(@"" + _BaseURL + "api/Product/AddProduct");
                
                HttpContent c = new StringContent(JsonConvert.SerializeObject(newproduct), Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(u, c).Result;
                if (response.IsSuccessStatusCode)
                {
                    var contents = response.Content.ReadAsStringAsync().Result;
                    return contents;
                }
                return response.ReasonPhrase;
            }
        }
        public async Task<IEnumerable<Product>> GetProductList()
        {
            List<Product> Products = new List<Product>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                Uri u = new Uri(@"" + _BaseURL + "api/Product/GetList");
                client.DefaultRequestHeaders.Clear();
                
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync(u);
                
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    Products = JsonConvert.DeserializeObject<List<Product>>(EmpResponse);
                }

            }
            return Products;
        }

        public async Task<Product> GetByIdAsync(Guid Id)
        {
            Product productDetails = new Product();
            using (var client = new HttpClient())
            {
                //Passing service base url
                Uri u = new Uri(@"" + _BaseURL + $"api/Product/Details/?id={Id}");
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync(u);

                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    productDetails = JsonConvert.DeserializeObject<Product>(EmpResponse);
                }

            }
            return productDetails;
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
        public async Task<List<ProductCategory>> GetCategoryList(bool PopulateDropDown = false)
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
                    if (PopulateDropDown)
                        Categories.Insert(0, new ProductCategory { Id = Guid.Empty, Description = "" });
                }

            }
            return Categories;
        }
        #endregion

        #region Order
        public async Task<string> AddItemToBasket(Product item, string CartId)
        {
            using (HttpClient client = new HttpClient())
            {
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                Uri u = new Uri(@"" + _BaseURL + $"api/Orders/AddItemToShoppingCart?id={item.Id}&CartId={CartId}");
               
                HttpContent c = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(u, c).Result;
                if (response.IsSuccessStatusCode)
                {
                    var contents = response.Content.ReadAsStringAsync().Result;
                    return contents;
                }
                return response.ReasonPhrase;
            }
        }

        public async Task<string> RemoveItemFromBasket(Product item, string CartId)
        {
            using (HttpClient client = new HttpClient())
            {
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                Uri u = new Uri(@"" + _BaseURL + $"api/Orders/RemoveItemFromShoppingCart?id={item.Id}&CartId={ CartId}");

                //HttpContent c = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.DeleteAsync(u).Result;
                if (response.IsSuccessStatusCode)
                {
                    var contents = response.Content.ReadAsStringAsync().Result;
                    return contents;
                }
                return response.ReasonPhrase;
            }
        }

        public async Task<string> CompleteOrder(OrderVM orderVM)
        {
            List<ShoppingBasketItems> items = new List<ShoppingBasketItems>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                Uri u = new Uri(@"" + _BaseURL + "api/Orders/CompleteOrder");
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var obj = JsonConvert.SerializeObject(orderVM);

                HttpContent c = new StringContent(obj, Encoding.UTF8, "application/json");
               
                //var token = new Token().GetToken();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage Res = client.PostAsync(u, c).Result;

                if (Res.IsSuccessStatusCode)
                {                    
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;                    
                    return EmpResponse;
                }
                else
                    return null;


            }
            
        }
        public async Task<List<ShoppingBasketItems>> GetShoppingCartItems(string cartid)
        {

            List<ShoppingBasketItems> items = new List<ShoppingBasketItems>();
            using (var client = new HttpClient()) 
            {
                //Passing service base url
                Uri u = new Uri(@"" + _BaseURL + $"api/Orders/GetShoppingCartItems?CartId={cartid}");
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //var token = new Token().GetToken();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage Res = await client.GetAsync(u);
                
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    items = JsonConvert.DeserializeObject<List<ShoppingBasketItems>>(EmpResponse);
                }

            }
            return items;
        }

        #endregion
    }
}
