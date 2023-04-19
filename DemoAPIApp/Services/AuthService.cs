using DemoAPIApp.Model.Request;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace DemoAPIApp.Services
{
    public class AuthService
    {
        public string Auth(AuthModel request, string URL)
        {
            using (var client = new HttpClient())
            {
                var enpoint = new Uri(URL);
                var newAuth = new AuthModel()
                {
                    UserName = request.UserName,
                    Password = request.Password,
                    BookingMode = request.BookingMode,
                    IPAddress = request.IPAddress,
                };
                var newPostJSON = JsonConvert.SerializeObject(newAuth);
                var payLoad = new StringContent(newPostJSON, Encoding.UTF8, "application/json");

                var result = client.PostAsync(enpoint, payLoad).Result;
                var json = result.Content.ReadAsStringAsync().Result;
                return json;
            }
        }
    }
}
