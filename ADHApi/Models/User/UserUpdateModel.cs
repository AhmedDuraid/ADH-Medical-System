using System;

namespace ADHApi.Models.User
{
    public class UserUpdateModel
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public char Gender { get; set; }
        public string Nationality { get; set; }
        public string Address { get; set; }
    }
}
