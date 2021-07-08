using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HansEgAPI.Dtos.RegionDtos
{
    public class RegionCreateDto
    {
        [Required]
        public string RegionName { get; set; }

        [Required]
        public int GovernorateId { get; set; }
    }
}
