namespace DemoAPIApp.Model.Request
{
    public class SearchModel
    {
        public string IPAddress { get; set; }
        public string TokenId { get; set; }
        public int JourneyType { get; set; }
        public int AdultCount { get; set; }
        public int ChildCount { get; set; }
        public int InfantCount { get; set; }
        public int FlightCabinClass { get; set; }
        public List<Segment> Segment { get; set; }
    }
}
