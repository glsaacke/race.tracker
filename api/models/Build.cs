namespace api.models
{
    public class Build
    {
        public int buildID { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public int rank { get; set; }
        public double speedST { get; set; }
        public double handlingST { get; set; }
        public double accelerationST { get; set; }
        public double launchST  { get; set; }
        public double brakingST { get; set; }
        public double offroadST { get; set; }
        public int userID { get; set; }
        public int deleted { get; set; }
    }
}