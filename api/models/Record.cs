namespace api.models
{
    public class Record
    {
        public int recordID { get; set; }
        public string classrank { get; set; }
        public int timemin { get; set; }
        public int timesec { get; set; }
        public int timems { get; set; }
        public string cpudiff { get; set; }
        public int buildID { get; set; }
        public int userID { get; set; }
    }
}