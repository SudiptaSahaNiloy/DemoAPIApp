using DemoAPIApp.Model.Request;
using DemoAPIApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;

namespace DemoAPIApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchRequestController : ControllerBase
    {
        public string TokenID = "";
        public string BaseURL = "http://xmloutapi.tboair.com/api/v1";

        // Get info details post
        [HttpPost("GetTokenID")]
        public string Auth([FromBody] AuthModel auth)
        {
            string AuthURL = BaseURL + "/Authenticate/ValidateAgency";
            
            var json = new AuthService().Auth(auth, AuthURL);

            var result = JsonConvert.DeserializeObject<AuthResponseModel>(json);

            TokenID = result.TokenId;

            return json;
        }

        [HttpPost("GetSearchResults")]
        public string Search([FromBody] SearchModel search)
        {
            string SearchURL = BaseURL + "/Search/Search";

            return new SearchService().Search(search, TokenID, SearchURL);
        }

        [HttpPost("TestData")]
        public string Test([FromBody] TestModel test)
        {
            string URL = "https://jsonplaceholder.typicode.com/posts";

            var json = new TestService().Test(test, URL);

            var result = JsonConvert.DeserializeObject<TestModel>(json);

            return result.title;
        }

        [HttpGet("GetAll")]
        public string GetAll() {
            string URL = "https://jsonplaceholder.typicode.com/posts";

            return new GetAllService().GetAll(URL);
        }
    }
}
