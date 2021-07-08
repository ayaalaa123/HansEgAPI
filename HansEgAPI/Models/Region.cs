using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HansEgAPI.Models
{
    public class Region
    {
        public int RegionId { get; set; }

        public string RegionName { get; set; }

        [ForeignKey("Governorate")]
        public int GovernorateId { get; set; }
        public Governorate Governorate { get; set; }
    }
}
