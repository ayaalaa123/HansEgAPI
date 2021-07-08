using HansEgAPI.Dtos.ClientDtos;
using HansEgAPI.Dtos.GovernorateDtos;
using HansEgAPI.Dtos.RegionDtos;
using HansEgAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HansEgAPI.Dtos.OrderDtos
{
    public class OrderReadDto
    {
        public int OrderId { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public string OrderNotes { get; set; }

        public string ResponsibleCompany { get; set; }

        // Foreign keys props
        public ClientReadDto Client { get; set; }

        //public GovernorateReadDto Governorate { get; set; } 

        public RegionReadDto Region { get; set; }

        public string StatusType { get; set; }

        // props maybe foreign keys or not

        public string OrderType { get; set; }

        public string OrderItem { get; set; }

        public static ErrorModel GetNotFoundErrorModel = new ErrorModel
        {
            StatusCode = HttpStatusCode.NotFound,
            ErrorMessage = "Order Not Found"
        };
    }
}
