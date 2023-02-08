using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Dtos
{
    public class MovieDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public GenreDto Genre { get; set; }
        [Display(Name = "Genre Movie")]
        [Required]
        public int GenreId { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd MMMM yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd MMMM yyyy}")]
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Number in Stock")]
        public byte NumberInStock { get; set; }
    }
}