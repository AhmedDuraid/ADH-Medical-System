using System;

namespace ADHDataManager.Library.Models
{
    public class UserModel
    {
        public int user_id { get; set; }
        public string user_name { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public DateTime birth_date { get; set; }
        public int role_id { get; set; }
        public string gender { get; set; }
        public string nationality { get; set; }
        public DateTime create_date { get; set; }
        public string address { get; set; }


    }
}
