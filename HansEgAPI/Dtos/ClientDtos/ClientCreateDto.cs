using HansEgAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace HansEgAPI.Dtos.ClientDtos
{
    public class ClientCreateDto
    {
        [Required]
        public string ClientName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string SecondPhoneNumber { get; set; }

        [Required]
        public string AddressInDetails { get; set; }

        public static ErrorModel GetCanNotBeNullErrorModel = new ErrorModel
        {
            StatusCode = HttpStatusCode.BadRequest,
            ErrorMessage = "Client Cann't be Null!"

        };
    }
}
