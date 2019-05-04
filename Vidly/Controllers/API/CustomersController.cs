using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Vidly.Models;
using System.Net;
using Vidly.DTOs;
using AutoMapper;
using System;

namespace Vidly.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }


        // GET /api/customers
        public IHttpActionResult GetCustomers()
        {
            var customerDTO = _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDTO>);

            return Ok(customerDTO);
        }

        // GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            else
            {
                return Ok(Mapper.Map<Customer, CustomerDTO>(customer));
            }
        }

        // POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            else
            {
                var customer = Mapper.Map<CustomerDTO, Customer>(customerDto);
                _context.Customers.Add(customer);
                _context.SaveChanges();

                customerDto.Id = customer.Id;

                return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
            }
        }

        // PUT /api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id,CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
            {
                return NotFound();
            }

            else
            {
                Mapper.Map(customerDto, customerInDb);

                _context.SaveChanges();

                return Ok();
            }
            
            
        }   
        

        // DELETE /api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
