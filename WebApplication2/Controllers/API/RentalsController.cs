using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Models;
using WebApplication2.viewModel;
using WebApplication2.Dtos;
using AutoMapper;
using WebApplication2.App_Start;

namespace WebApplication2.Controllers.API
{
    public class RentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: /api/rentals
        public IHttpActionResult GetRentals()
        {
            var rentalDto = _context.Rentals
                .Include(c => c.Customer.MembershipType).Include(c => c.Movie.Genre)
                .ToList()
                .Select(Mapper.Map<Rental, RentalDto>);
            
            return Ok(rentalDto);
        }

        // GET: /api/rentals/id
        public IHttpActionResult GetRentals(int id)
        {
            var rental = _context.Rentals.SingleOrDefault(c => c.Id == id);

            if (rental == null)
                return NotFound();

            return Ok(Mapper.Map<Rental, RentalDto>(rental));
        }

        // POST: /api/customers
        [HttpPost]
        public IHttpActionResult CreateRental(RentalDto rentalDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var rental = Mapper.Map<RentalDto, Rental>(rentalDto);
            _context.Rentals.Add(rental);
            _context.SaveChanges();

            rentalDto.Id = rental.Id;
            return Created(new Uri(Request.RequestUri + "/" + rental.Id), rentalDto);
        }

        // PUT: /api/rentals/id
        [HttpPut]
        public void UpdateRental(int id, RentalDto rentalDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var rentalInDb = _context.Rentals.SingleOrDefault(c => c.Id == id);

            if (rentalInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(rentalDto, rentalInDb);

            _context.SaveChanges();
        }

        // DELETE: /api/rentals/id
        [HttpDelete]
        public void DeleteRental(int id)
        {
            var rentalInDb = _context.Rentals.SingleOrDefault(c => c.Id == id);

            if (rentalInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Rentals.Remove(rentalInDb);
            _context.SaveChanges();
        }
    }
}