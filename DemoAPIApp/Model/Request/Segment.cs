namespace DemoAPIApp.Model.Request
{
    public class Segment
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime PreferredDepartureTime { get; set; }
        public DateTime PreferredArrivalTime { get; set; }
        public List<string> PreferredAirlines { get; set; }
    }
}
