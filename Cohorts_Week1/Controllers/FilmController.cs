using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Cohorts_Week1.Controllers
{
    [ApiController]
    [Route("api/films")]
    public class FilmController : ControllerBase
    {
        private static List<Film> FilmList = new List<Film>();
        
        // api/films
        //Gets and returns all films
        [HttpGet] 
        public List<Film> GetFilms()
        {
            var filmList = FilmList.OrderBy(i => i.Id).ToList<Film>();
            return filmList;
        }

        // api/films/{id}
        // Searchs and returns the film with the specified ID
        [HttpGet("{id}")]
        public IActionResult GetFilmById(int id)
        {
            var film = FilmList.Where(i => i.Id == id).SingleOrDefault();
            if(film is not null){
                return Ok(film);
            }
            return BadRequest("No movie matching the searched id was found.");
        }
        
        // api/films
        // Adds movie taken as parameter via FromBody
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
        
        // api/films/{id}
        // Searchs for the film with the specified ID and updates the film with the parameter taken via FromBody
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

        // api/films/{id}
        //Searchs and deletes the film with the specified ID
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

        // api/films/{id}
        //Searchs for the film with the specified ID and updates the film's genreId property with the parameter taken via FromBody
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
