using HansEgAPI.Dtos.GovernorateDtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HansEgAPI.Dtos.RegionDtos
{
    public class RegionUpdateDto
    {
        [Required]
        public string RegionName { get; set; }

        public int? GovernorateId { get; set; } 
    }
}
