using ApiCursoEntityFrameworkCore.ApplicationDb;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCursoEntityFrameworkCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FilmsController(ApplicationDbContext dbContext, IMapper mapper)
        {
            this._context = dbContext;
            this._mapper = mapper;
        }

        /// <summary>
        /// Metodo para obterner todas las peliculas.
        /// La cosa es que algunos campos no se estan mostrando. Por ejemplo, el campo de genres
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("GetFilmXId")]
        public async Task<ActionResult> Get([FromQuery] int Id)
        {
            //Para hacer consultas complejas uniendo tablas, a veces es mejor usar luego un select
            //para seleccionar los campos que se quieren mostrar
            var film = await _context.FilmTable
                .Include(g => g.FilmsGenres)
                .ThenInclude(g=> g.Genre)
                .Select(f => new 
                {
                    f.Id,
                    f.Title,
                    f.PremiereDate,
                    f.InMovie,
                    Genres = f.FilmsGenres.Select(fg => fg.Genre.Name).ToList()
                })
                .FirstOrDefaultAsync(f => f.Id == Id);

            if (film is null)
                return NotFound();

            return Ok(film);
        }

        [HttpGet("GetFilmInfoCompleteXId")]
        public async Task<ActionResult> GetFilmInfoCompleteXId([FromQuery] int Id)
        {
            //Para hacer consultas complejas uniendo tablas, a veces es mejor usar luego un select
            //para seleccionar los campos que se quieren mostrar
            var film = await _context.FilmTable
                .Include(g => g.FilmsGenres)
                    .ThenInclude(g => g.Genre)
                .Include(mt => mt.FilmsMovieTheaters)
                    .ThenInclude(mt => mt.MovieTheater)
                .Include(ma => ma.FilmsActors)
                    .ThenInclude(ma => ma.Actor)
                .Select(f => new
                {
                    f.Id,
                    f.Title,
                    f.PremiereDate,
                    f.InMovie,
                    Genres = f.FilmsGenres
                        .Select(fg => fg.Genre.Name),
                    MovieOrCinema = f.FilmsMovieTheaters
                        .Select(mt => mt.MovieTheater.Movie.Name)
                        .Distinct(),
                    Actors = f.FilmsActors
                        .Select(pa => pa.Actor.Name)
                })
                .FirstOrDefaultAsync(f => f.Id == Id);

            if (film is null)
                return NotFound();

            film.MovieOrCinema.ToList().DistinctBy(x => x);

            return Ok(film);
        }

        [HttpGet("GetFilmInfoWithActorDateOfBithAfter1980XId")]
        public async Task<ActionResult> GetFilmInfoWithActorDateOfBithAfter1980XId([FromQuery] int Id)
        {
            //Para hacer consultas complejas uniendo tablas, a veces es mejor usar luego un select
            //para seleccionar los campos que se quieren mostrar
            var film = await _context.FilmTable
                .Include(g => g.FilmsGenres)
                    .ThenInclude(g => g.Genre)
                .Include(mt => mt.FilmsMovieTheaters)
                    .ThenInclude(mt => mt.MovieTheater)
                .Include(ma => ma.FilmsActors)
                    .ThenInclude(ma => ma.Actor)
                .Select(f => new
                {
                    f.Id,
                    f.Title,
                    f.PremiereDate,
                    f.InMovie,
                    Genres = f.FilmsGenres
                        .Select(fg => fg.Genre.Name),
                    MovieOrCinema = f.FilmsMovieTheaters
                        .Select(mt => mt.MovieTheater.Movie.Name)
                        .Distinct(),
                    Actors = f.FilmsActors
                        .Where(pa => pa.Actor.DateOfBirth.Value.Year >= 1980)
                        .Select(pa => pa.Actor.Name)
                })
                .FirstOrDefaultAsync(f => f.Id == Id);

            if (film is null)
                return NotFound();

            return Ok(film);
        }

        [HttpGet("GetAutoMapperFilmInfoCompleteXId")]
        public async Task<ActionResult> GetAutoMapperFilmInfoCompleteXId([FromQuery] int Id)
        {
            var film = await _context.FilmTable
                .Include(g => g.FilmsGenres)
                    .ThenInclude(g => g.Genre)
                .Include(mt => mt.FilmsMovieTheaters)
                    .ThenInclude(mt => mt.MovieTheater)
                .Include(ma => ma.FilmsActors)
                    .ThenInclude(fa => fa.Actor)
                .FirstOrDefaultAsync(f => f.Id == Id);

            if (film is null)
                return NotFound();

            var filmInfo = film;

            return Ok(filmInfo);


        }
    }
}
