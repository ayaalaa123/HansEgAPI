using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HansEgAPI.Dtos.OrderDtos
{
    public class OrderUpdateDto
    {
        public DateTime? OrderDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public string OrderNotes { get; set; }

        public string ResponsibleCompany { get; set; }

        // Foreign keys props
        public int ClientId { get; set; }

        public int RegionId { get; set; }

        public string StatusType { get; set; }

        // props maybe foreign keys or not
        public string OrderType { get; set; }

        public string OrderItem { get; set; }
    }

    public enum OrderStatus
    {
        Cancel = 1,
        Done = 2,
        CarryOver = 3,
        Urgent = 4
    }
}
