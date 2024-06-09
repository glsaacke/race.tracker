namespace api.models
{
    public class User
    {
        public int userID { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public int phone { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int deleted { get; set; }
    }
}