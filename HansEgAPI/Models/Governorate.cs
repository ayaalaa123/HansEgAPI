using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HansEgAPI.Models
{
    public class Governorate
    {
        public int GovernorateId { get; set; }

        public string GovernorateName { get; set; }
    }
}
