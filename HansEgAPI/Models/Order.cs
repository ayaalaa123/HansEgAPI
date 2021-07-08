using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HansEgAPI.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public string OrderNotes { get; set; }

        public string ResponsibleCompany { get; set; }

        // Foreign keys props

        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public Client Client { get; set; }

        [ForeignKey("Region")]
        public int RegionId { get; set; }
        public Region Region { get; set; }

        public string StatusType { get; set; }

        // props maybe foreign keys or not

        public string OrderType { get; set; }

        public string OrderItem { get; set; }
    }
}
