﻿using System;
using System.Collections.Generic;

namespace ADHDataManager.Library.Models
{
    public class PatientModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string Address { get; set; }
        public string RoleName { get; set; }

    }
}
