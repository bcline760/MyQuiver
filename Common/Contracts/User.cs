using System;
namespace MyQuiver.Contracts
{
    public class User : QuiverEntity<User>
    {
        public User()
        {
        }

        public UserType Type { get; set; }

        public UserStatus Status { get; set; }

        public string Provider { get; set; }

        public string ProviderToken { get; set; }


        public string FirstName { get; set; }


        public string LastName { get; set; }


        public string PrimaryEmail { get; set; }


        public string State { get; set; }


        public string PostalCode { get; set; }


        public int? Age { get; set; }

        public string PreferredStyle { get; set; }
    }
}
