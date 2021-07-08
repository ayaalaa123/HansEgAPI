using HansEgAPI.Dtos.GovernorateDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HansEgAPI.Dtos.RegionDtos
{
    public class RegionReadDto
    {
        public int RegionId { get; set; }

        public string RegionName { get; set; }

        public GovernorateReadDto Governorate { get; set; }
    }
}
