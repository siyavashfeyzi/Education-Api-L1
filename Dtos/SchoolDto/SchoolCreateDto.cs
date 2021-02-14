using System.ComponentModel.DataAnnotations;

namespace Education_Api_L1.Dtos.SchoolDto
{
    public class SchoolCreateDto
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
