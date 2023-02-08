using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.viewModel
{
    public class ViewRental
    {
        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
        public Rental Rentals { get; set; }
        public int NameTitleForm { get; set; }
    }
}