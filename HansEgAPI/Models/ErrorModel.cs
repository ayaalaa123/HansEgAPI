using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HansEgAPI.Models
{
    public class ErrorModel
    {
        public HttpStatusCode StatusCode { get; set; }

        public string ErrorMessage { get; set; }
    }
}
