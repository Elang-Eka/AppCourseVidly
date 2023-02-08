using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd MMMM yyyy}")]
        [Display(Name = "Birth Date")]
        [Min18YearsMember]
        public DateTime BirthDate { get; set; }

        public bool IsSubcribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Required]
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }


    }
}