using System.ComponentModel.DataAnnotations;

namespace MyTestApi.Models
{
    public class User
    {
        public long id { get; set; }
        [Required]
        public string name { get; set; } = "";

        [Required]
        public string username { get; set; } = "";

        [Required]
        [EmailAddress]
        public string email { get; set; } = "";

        public string? phone { get; set; }
        public string? website { get; set; }
        //public Address? address { get; set; }
        //public Company? Company { get; set; }
    }

    public class Address
    {
        public string? street { get; set; }

        public string? suite { get; set; }

        public string? city { get; set; }

        public string? zipcode { get; set; }

        public Geo? geo { get; set; }
    }

    public class Geo
    {
        public string? lat { get; set; }

        public string? lng { get; set; }
    }

    public class Company
    {
        public string? name { get; set; }

        public string? catchPhrase { get; set; }

        public string? bs { get; set; }
    }
}
