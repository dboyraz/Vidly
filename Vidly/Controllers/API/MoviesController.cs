using AutoMapper;
using System;
using System.Linq;
using System.Web.Http;
using Vidly.DTOs;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers.API
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }


        //GET /api/movies
        public IHttpActionResult GetMovies()
        {
            var movieDTO = _context.Movies
                .Include(g => g.Genre)
                .ToList()
                .Select(Mapper.Map<Movie, MovieDTO>);

            return Ok(movieDTO);
        }

        //GET /api/movies/id
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            else
            {
                return Ok(Mapper.Map<Movie, MovieDTO>(movie));
            }
        }

        //POST /api/movies/
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            else
            {
                var movie = Mapper.Map<MovieDTO, Movie>(movieDTO);
                _context.Movies.Add(movie);
                _context.SaveChanges();

                movieDTO.Id = movie.Id;

                return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDTO);
            }
        }

        //PUT api/movies/id
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
            {
                return NotFound();

            }

            else
            {
                Mapper.Map(movieDTO, movieInDb);

                _context.SaveChanges();

                return Ok();
            }
        }

        //DELETE /api/movies/id
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                return NotFound();

            else
            {
                _context.Movies.Remove(movieInDb);
                _context.SaveChanges();

                return Ok();
            }
            
        }
    }
}
