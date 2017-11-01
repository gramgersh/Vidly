using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.Dtos;
using AutoMapper;
using System.Data.Entity;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }

        // GET /api/Movies
        [HttpGet]
        public IEnumerable<MovieDto> GetMovies()
        {
            return _context.Movies
                .Include(m => m.Genre)
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);
        }

        // GET /api/Movies/id
        [HttpGet]
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        // POST /api/Movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto mdto)
        {
            if ( !ModelState.IsValid)
            {
                return BadRequest();
            }

            var newMovie = Mapper.Map<MovieDto, Movie>(mdto);
            newMovie.DateAdded = DateTime.Now;
            _context.Movies.Add(newMovie);
            _context.SaveChanges();

            // Grab our new id
            mdto.Id = newMovie.Id;

            return Created(new Uri(Request.RequestUri + "/" + newMovie.Id), mdto);
        }

        // PUT /api/Movies/id
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto mdto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var curMovie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if ( curMovie == null )
            {
                return NotFound();
            }

            Mapper.Map(mdto, curMovie);
            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/movies/id

        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id, MovieDto mdto)
        {
            var curMovie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (curMovie == null)
            {
                return NotFound();
            }
            _context.Movies.Remove(curMovie);
            _context.SaveChanges();
            return Ok();
        }
    }
}
