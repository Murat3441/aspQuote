using System;
using System.ComponentModel.DataAnnotations;

namespace aspQuote.Models
{
    public class Insuree
    {      
        LoginViewModel loginViewModel;
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public int CarYear { get; set; }

        [Required]
        [StringLength(50)]
        public string CarMake { get; set; }

        [Required]
        [StringLength(50)]
        public string CarModel { get; set; }

        [Required]
        public int SpeedingTickets { get; set; }

        [Required]
        public bool HasDUI { get; set; }

        [Required]
        public bool IsFullCoverage { get; set; }

        [DataType(DataType.Currency)]
        public decimal Quote { get; set; }
    }
}
