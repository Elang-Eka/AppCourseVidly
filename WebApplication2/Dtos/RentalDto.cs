using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Dtos
{
    public class RentalDto
    {
        public int Id { get; set; }

        public CustomerDto Customer { get; set; }

        [Required]
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }

        public MovieDto Movie { get; set; }

        [Required]
        [Display(Name = "Movie")]
        public int MovieId { get; set; }

        //[Required]
        //[DisplayFormat(DataFormatString = "{0:dd MMMM yyyy}")]
        //[DataType(DataType.Date)]
        //public DateTime DateRented { get; set; }

        //[Required]
        //[DisplayFormat(DataFormatString = "{0:dd MMMM yyyy}")]
        //[DataType(DataType.Date)]
        //public DateTime DateReturned { get; set; }
    }
}