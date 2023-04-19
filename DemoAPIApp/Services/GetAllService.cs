namespace DemoAPIApp.Services
{
    public class GetAllService
    {
        public string GetAll(string URL) {
            using (var client = new HttpClient())
            {
                var endpoint = new Uri(URL);
                var result = client.GetAsync(endpoint).Result;
                var json = result.Content.ReadAsStringAsync().Result;

                return json;
            }
        }
    }
}
