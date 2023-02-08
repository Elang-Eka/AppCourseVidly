using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.viewModel;

namespace WebApplication2.Controllers
{
    public class RentalsController : Controller
    {
        private ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        // GET: Rentals
        public ActionResult Index()
        {
            //var customer = _context.Customers.Include(c => c.MembershipType).ToList();
            //return View(customer);
            //return View();
            if (User.IsInRole("CanManageMovie"))
                return View("List");

            return View("ReadOnlyRentals");
        }

        // GET: Rentals/Create
        public ActionResult Create()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            var movie = _context.Movies.Include(c => c.Genre).ToList();
            var viewModel = new ViewRental
            {
                Rentals = new Rental(),
                Customers = customers,
                Movies = movie,               
                NameTitleForm = 0
            };
            return View("RentalForm", viewModel);
        }

        // POST: Rentals/CreateRentals
        [HttpPost]
        public ActionResult Save(ViewRental rental)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ViewRental
                {
                    Rentals = rental.Rentals,
                    Customers = _context.Customers.ToList(),
                    Movies = _context.Movies.ToList()
                };
                return View("RentalForm", viewModel);
            }

            if (rental.Rentals.Id == 0)
            {
                _context.Rentals.Add(rental.Rentals);
            }
            else
            {
                var rentalInDb = _context.Rentals.Single(c => c.Id == rental.Rentals.Id);

                rentalInDb.MovieId = rental.Rentals.MovieId;
                rentalInDb.CustomerId = rental.Rentals.CustomerId;
                rentalInDb.DateRented = rental.Rentals.DateRented;
                rentalInDb.DateReturned = rental.Rentals.DateReturned;
            }

            _context.SaveChanges();

            return RedirectToAction("List", "Rentals");
        }

        // GET: Rentals/Details/{id}
        public ActionResult Details(int id)
        {
            var rental = _context.Rentals.Include(c => c.Customer).Include(c => c.Movie).SingleOrDefault(c => c.Id == id);

            if (rental == null)
                return HttpNotFound();

            return View(rental);
        }

        // GET: Rentals/Edit/{id}
        public ActionResult Edit(int id)
        {
            var rental = _context.Rentals.SingleOrDefault(c => c.Id == id);

            if (rental == null)
                return HttpNotFound();

            var viewModel = new ViewRental
            {
                Rentals = rental,
                Customers = _context.Customers.ToList(),
                Movies = _context.Movies.ToList(),
                NameTitleForm = 1,
            };

            return View("RentalForm", viewModel);
        }
    }
}