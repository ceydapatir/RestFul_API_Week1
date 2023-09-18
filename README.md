
# RESTFULL API - WEEK 1 

A Restful API containing HTTP GET, POST, PUT, DELETE and PATCH action methods for a Film class object.

## ROUTES
* GET   /api/Films
```c# 
public List<Film> GetFilms() 
```
* POST  /api/Films
```c# 
public IActionResult AddFilm([FromBody] Film Film)
```
* GET   /api/Films/{id}
```c# 
public IActionResult GetFilmById(int id) 
```
* PUT   /api/Films/{id}
```c# 
public IActionResult UpdateFilmById(int id, [FromBody] Film Film)
```
* DELETE   /api/Films/{id}
```c# 
public IActionResult DeleteFilm(int id)
```
* PATCH  /api/Films/{id}
```c# 
public IActionResult UpdateFilmGenreById(int id, [FromBody] int genreid)
```

## SCHEMAS
```c#
Film{
    id              integer($int32)
    name	    string
    imdb    	    number($double)
    genreId	    integer($int32)
    director        string
    publishDate	    string($date-time)
}
```
