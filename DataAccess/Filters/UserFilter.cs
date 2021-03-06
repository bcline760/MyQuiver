﻿using System;
namespace MyQuiver.Model.Filters
{
    internal class UserFilter:BaseFilter
    {
        public UserType Type { get; set; }

        public UserStatus Status { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PrimaryEmail { get; set; }

        public int? Age { get; set; }
        public string PreferredStyle { get; set; }
    }
}
