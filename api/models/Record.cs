namespace api.models
{
    public class Record
    {
        public string recordID { get; set; }
        public string classrank { get; set; }
        public int timemin { get; set; }
        public int timesec { get; set; }
        public int timems { get; set; }
        public string cpudiff { get; set; }
        public string buildID { get; set; }
        public string userID { get; set; }
        public int deleted { get; set; }
    }
}