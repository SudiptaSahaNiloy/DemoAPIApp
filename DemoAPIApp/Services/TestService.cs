using DemoAPIApp.Model.Request;
using Newtonsoft.Json;
using System.Text;
using System;

namespace DemoAPIApp.Services
{
    public class TestService
    {
        public string Test(TestModel test, string URL)
        {
            using(var client = new HttpClient())
            {
                var endpoint = new Uri(URL);
                var Test = new TestModel()
                {
                    id = test.id,
                    title = test.title,
                    body = test.body,
                    userId = test.userId,
                };
                var newPostJSON = JsonConvert.SerializeObject(Test);
                var payLoad = new StringContent(newPostJSON, Encoding.UTF8, "application/json");

                var result = client.PostAsync(endpoint, payLoad).Result;
                var json = result.Content.ReadAsStringAsync().Result;
                return json;
            }
        }
    }
}
