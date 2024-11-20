using System.ComponentModel.DataAnnotations;
namespace AdvisorSystem.Models
{
    public class Advisor
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(255)]
        public string FullName { get; set; }

        [Required]
        [StringLength(9, MinimumLength = 9)]
        public string SIN { get; set; }

        [MaxLength(255)]
        public string Address { get; set; }

        [StringLength(10)]
        public string PhoneNumber { get; set; }

        public string HealthStatus { get; set; }  // Health Status: Green, Yellow, Red
    }
}
