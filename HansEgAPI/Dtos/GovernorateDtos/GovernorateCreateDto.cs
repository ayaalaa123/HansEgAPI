using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HansEgAPI.Dtos.GovernorateDtos
{
    public class GovernorateCreateDto
    {
        [Required]
        public string GovernorateName { get; set; }
    }
}
