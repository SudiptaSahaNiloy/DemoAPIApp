using DemoAPIApp.Model.Request;
using Newtonsoft.Json;
using System.Text;
using System;

namespace DemoAPIApp.Services
{
    public class SearchService
    {
        public string Search(SearchModel model, string TokenId, string URL)
        {
            using(var client = new HttpClient())
            {
                var enpoint = new Uri(URL);
                var search = new SearchModel()
                {
                    IPAddress = model.IPAddress,
                    TokenId = TokenId,
                    JourneyType = model.JourneyType,
                    AdultCount = model.AdultCount,
                    ChildCount = model.ChildCount,
                    InfantCount = model.InfantCount,
                    FlightCabinClass = model.FlightCabinClass,
                    Segment = new List<Segment> {
                        new Segment()
                        {
                            Origin = model.Segment[0].Origin,
                            Destination = model.Segment[0].Destination,
                            PreferredDepartureTime = model.Segment[0].PreferredDepartureTime,
                            PreferredArrivalTime = model.Segment[0].PreferredArrivalTime,
                            PreferredAirlines = model.Segment[0].PreferredAirlines,
                        }
                    }
                };
                var newPostJSON = JsonConvert.SerializeObject(search);
                var payLoad = new StringContent(newPostJSON, Encoding.UTF8, "application/json");

                var result = client.PostAsync(enpoint, payLoad).Result;
                var json = result.Content.ReadAsStringAsync().Result;
                
                return json;
            }
        } 
    }
}
