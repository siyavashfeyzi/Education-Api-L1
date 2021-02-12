using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Education_Api_L1.Dtos.SchoolDto
{
    public class SchoolUpdateDto
    {
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [Required]
        [MaxLength(250)]
        public string Level { get; set; }

        [Required]
        [MaxLength(11)]
        [MinLength(11)]
        public string PhoneNumber { get; set; }
    }
}
