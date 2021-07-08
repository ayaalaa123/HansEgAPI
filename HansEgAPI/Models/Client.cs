using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HansEgAPI.Models
{
    public class Client
    {
        public int ClientId { get; set; }

        [Required(ErrorMessage = "Client Name Is Required!")]
        public string ClientName { get; set; }

        [Required(ErrorMessage = "Phone Number Is Required!")]
        public string PhoneNumber { get; set; }

        public string SecondPhoneNumber { get; set; }

        [Required]
        public string AddressInDetails { get; set; }
    }
}
