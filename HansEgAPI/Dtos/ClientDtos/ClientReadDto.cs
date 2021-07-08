using HansEgAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HansEgAPI.Dtos.ClientDtos
{
    public class ClientReadDto
    {
        public int ClientId { get; set; }

        public string ClientName { get; set; }

        public string PhoneNumber { get; set; }

        public string SecondPhoneNumber { get; set; }

        public string AddressInDetails { get; set; }

        public static ErrorModel GetNotFoundErrorModel = new ErrorModel
        {
            StatusCode = HttpStatusCode.NotFound,
            ErrorMessage = "Client Not Found!"
        };
    }
}
