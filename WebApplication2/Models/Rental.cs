using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Rental
    {
        public int Id { get; set; }
        
        public Customer Customer { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        [Display(Name = "Movie Name")]
        public int MovieId { get; set; }
        
        public Movie Movie { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd MMMM yyyy}")]
        [Display(Name = "Date Rented")]
        public DateTime DateRented { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd MMMM yyyy}")]
        [Display(Name = "Date Returned")]
        public DateTime DateReturned { get; set; }
    }
}