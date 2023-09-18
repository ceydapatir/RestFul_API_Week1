using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Cohorts_Week1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmController : ControllerBase
    {
        private static List<Film> FilmList = new List<Film>();
        [HttpGet]
        public List<Film> GetFilms()
        {
            var filmList = FilmList.OrderBy(i => i.Id).ToList<Film>();
            return filmList;
        }

        [HttpGet("{id}")]
        public IActionResult GetFilmById(int id)
        {
            var film = FilmList.Where(i => i.Id == id).SingleOrDefault();
            if(film is not null){
                return Ok(film);
            }
            return BadRequest("No movie matching the searched id was found.");
        }

        [HttpPost]
        public IActionResult AddFilm([FromBody] Film Film)
        {
            var film = FilmList.Where(i => i.Id == Film.Id).SingleOrDefault();
            if(film is not null){
                return BadRequest("This movie is already registered.");
            }
            FilmList.Add(Film);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFilmById(int id, [FromBody] Film Film)
        {
            var film = FilmList.Where(i => i.Id == id).SingleOrDefault();
            if(film is null){
                return BadRequest("No movie found with this id.");
            }
            film.Name = Film.Name != default ? Film.Name : film.Name;
            film.Director = Film.Director != default ? Film.Director : film.Director;
            film.IMDB = Film.IMDB != default ? Film.IMDB : film.IMDB;
            film.GenreId = Film.GenreId != default ? Film.GenreId : film.GenreId;
            film.PublishDate = Film.PublishDate != default ? Film.PublishDate : film.PublishDate;
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFilm(int id)
        {
            var film = FilmList.Where(i => i.Id == id).SingleOrDefault();
            if(film is null){
                return BadRequest("No movie found with this id.");
            }
            FilmList.Remove(film);
            return Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateFilmGenreById(int id, [FromBody] int genreid)
        {
            var film = FilmList.Where(i => i.Id == id).SingleOrDefault();
            if(film is null){
                return BadRequest("No movie found with this id.");
            }
            
            film.GenreId = genreid != default ? genreid : film.GenreId;
            return Ok();
        }
    }
}