using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Education_Api_L1.Dtos.SchoolDto
{
    public class SchoolReadDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Level { get; set; }

        public string PhoneNumber { get; set; }

    }
}
