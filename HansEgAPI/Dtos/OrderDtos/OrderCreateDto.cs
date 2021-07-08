using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HansEgAPI.Dtos.OrderDtos
{
    public class OrderCreateDto
    {
        [Required]
        public DateTime OrderDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public string OrderNotes { get; set; }

        [Required]
        public string ResponsibleCompany { get; set; }

        // Foreign keys props
        [Required]
        public int ClientId { get; set; }
        
        [Required]
        public int RegionId { get; set; }
        
        [Required]
        public string StatusType { get; set; }

        // props maybe foreign keys or not
        [Required]
        public string OrderType { get; set; }
        
        [Required]
        public string OrderItem { get; set; }
    }
}
