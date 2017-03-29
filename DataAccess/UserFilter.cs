using MyQuiver.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyQuiver.DataAccess
{
    public class UserFilter : Filter
    {
        public UserType? Type { get; set; }

        public UserStatus? Status { get; set; }

        [StringLength(48, ErrorMessage = "Please enter a shorter first name")]
        public string FirstName { get; set; }

        [StringLength(48, ErrorMessage = "Please enter a shorter last name")]
        public string LastName { get; set; }
    }
}
