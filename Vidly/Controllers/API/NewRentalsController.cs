using System;
using System.Web.Http;
using Vidly.DTOs;

namespace Vidly.Controllers.API
{
    public class NewRentalsController : ApiController
    {
        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDTO newRental)
        {
            throw new NotImplementedException();
        }
    }
}
