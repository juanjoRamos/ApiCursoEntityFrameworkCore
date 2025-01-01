using ApiCursoEntityFrameworkCore.ApplicationDb;
using ApiCursoEntityFrameworkCore.DTO;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace ApiCursoEntityFrameworkCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Description("Este controlador se usará para obtener peliculas o una película. Para tener en cuenta las búsquedas buscamos que sean eficientes y rápidas." +
        " He dejado varias formas de poder hacer búsquedas. La más recomendada es Selective Loading y Eager Loading. Incluso para hacer busquedas en las propiedades de navegación.")]
    public class FilmsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FilmsController(ApplicationDbContext dbContext, IMapper mapper)
        {
            this._context = dbContext;
            this._mapper = mapper;
        }

        [HttpGet("GetFilmXId")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [EndpointSummary("GetFilmXId")]
        [EndpointDescription("Realizar consultas complejas uniendo tablas")]
        
        public async Task<ActionResult> Get([FromQuery] int Id)
        {
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
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [EndpointSummary("GetFilmInfoCompleteXId")]
        [EndpointDescription("Añadir la informacion de toda la pelicula. En este caso devolvemos" +
            "un tipo anonimo")]
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

        [HttpGet("GetInformationOrderOrFilterBySelect")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [EndpointSummary("GetInformationOrderOrFilterBySelect")]
        [EndpointDescription("Ordenamos y/o filtramos informacion dentro del método Select")]
        public async Task<ActionResult> GetInformationOrderOrFilterBySelect([FromQuery] int Id)
        {
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

        [HttpGet("GetInformationOrderOrFilterByInclude")]
        [ProducesResponseType(200), ProducesResponseType(404)]
        [EndpointSummary("GetInformationOrderOrFilterByInclude")]
        [EndpointDescription($"Ordenamos o filtramos la consulta dentro del método Include.")]
        public async Task<ActionResult> GetInformationOrderOrFilterByInclude([FromQuery] int Id)
        {
            var film = await _context.FilmTable
                .Include(g => g.FilmsGenres.OrderByDescending(x => x.Genre))
                    .ThenInclude(g => g.Genre)
                .Include(mt => mt.FilmsMovieTheaters)
                    .ThenInclude(mt => mt.MovieTheater)
                .Include(ma => ma.FilmsActors)
                    .ThenInclude(fa => fa.Actor)
                .FirstOrDefaultAsync(f => f.Id == Id);

            if (film is null)
                return NotFound();

            return Ok(film);
        }

        [HttpGet("GetInformationWithAutomapper")]
        [ProducesResponseType(200), ProducesResponseType(404)]
        [EndpointSummary("GetInformationWithAutomapper")]
        [EndpointDescription($"Obtener la informacion usando AutoMapper.")]
        public async Task<ActionResult> GetInformationWithAutomapper([FromQuery] int Id)
        {
            //Para poder filtrar la lista de generos podemos hacerlo directamente desde el archivo de mapeo AutomapperProfile
            var film = await _context.FilmTable
                .ProjectTo<FilmDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
            
            if (film is null)
                return NotFound();

            return Ok(film);
        }

        [HttpGet("GetSelectiveLoading")]
        [ProducesResponseType(200), ProducesResponseType(404)]
        [EndpointSummary("GetSelectiveLoading")]
        [EndpointDescription($"Obtener la informacion usando el metodo Select, mucho más eficiente" +
            $" que el método Include. Además de poder hacer subconsultas.")]
        public async Task<ActionResult> GetSelectiveLoading([FromQuery] int Id)
        {
            var film = await _context.FilmTable
                .Select(f => new 
                {
                    Id = f.Id,
                    Title = f.Title,
                    Genres = f.FilmsGenres
                        .OrderByDescending(x => x.Genre.Name)
                        .Select(fg => fg.Genre.Name),
                    TotalActors = f.FilmsActors.Count,
                    TotalCinemasOrMovies = f.FilmsMovieTheaters
                        .Select(mt => mt.MovieTheater.Movie.Name)
                        .Distinct()
                        .Count()
                })
                .FirstOrDefaultAsync(f => f.Id == Id);

            if (film is null)
                return NotFound();

            return Ok(film);
        }

        [HttpGet("GetExplicitSelect")]
        [ProducesResponseType(200), ProducesResponseType(404)]
        [EndpointSummary("GetExplicitSelect")]
        [EndpointDescription($"Obtener la informacion usando los metodos Entry(objeto).Collection(LaColeccionRelacionada).LoadAsync()." +
            $" Tambien se pueden hacer querys usando el metodo Query() despues de Collection() para hacer consultas.")]
        public async Task<ActionResult> GetExplicitSelect([FromQuery] int Id)
        {
            var film = await _context.FilmTable
                .AsTracking()
                .FirstOrDefaultAsync(f => f.Id == Id);

            //Tras coger la pelicula cargaremos los generos

            await _context.Entry(film)
                .Collection(g => g.FilmsGenres)
                .LoadAsync();

            await _context.Entry(film)
                .Collection(fa => fa.FilmsActors)
                .LoadAsync();

            //Incluso podemos hacer querys sobre esos datos que queremos extraer.
            var CountGenres = await _context.Entry(film)
                .Collection(g => g.FilmsGenres)
                .Query()
                .CountAsync();

            if (film is null)
                return NotFound();

            return Ok(film);
        }

        [HttpGet("GetLazyLoading")]
        [ProducesResponseType(200), ProducesResponseType(404)]
        [EndpointSummary("GetLazyLoading")]
        [EndpointDescription($"Obtener la informacion simplemente haciendo Includes o usando AutoMapper, añadiendo las propiedades de navegación.")]
        public async Task<ActionResult> GetLazyLoading([FromQuery] int Id)
        {
            var film = await _context.FilmTable
                .AsTracking()
                .FirstOrDefaultAsync(f => f.Id == Id);

            if (film is null)
                return NotFound();

            //Con automapper si tenemos en las propiedades que queremos una data relacionada
            //automáticamente se cargará.
            //Ej: Genres, Actors, MovieTheaters...

            return Ok(film);
        }

        [HttpGet("GetGroupByInMovies")]
        [ProducesResponseType(200), ProducesResponseType(404)]
        [EndpointSummary("GetGroupByInMovies")]
        [EndpointDescription($"Obtener la infomación haciendo agrupaciones, en este caso es agrupando por la propia" +
            $" propiedad (key) ")]
        public async Task<ActionResult> GetGroupByDatePremiere()
        {
            var filmsGrouped = await _context.FilmTable
                .GroupBy(f => f.InMovie)
                .Select(f => new
                {
                    InMovie = f.Key,
                    Total = f.Count(),
                    Films = f.Select(f => f.Title)
                }).ToListAsync();

            return Ok(filmsGrouped);
        }

        [HttpGet("GetGroupByGenres")]
        [ProducesResponseType(200), ProducesResponseType(404)]
        [EndpointSummary("GetGroupByGenres")]
        [EndpointDescription($"Obtener la infomación haciendo agrupaciones, en este caso es agrupando por la propia" +
    $" propiedad (key) ")]
        public async Task<ActionResult> GetGroupByGenres()
        {

            //TODO: revisar esto con la base de datos que hay en el otro pc.
            var filmsGrouped = await _context.FilmTable
                .Include(f => f.FilmsGenres.GroupBy(x => x.Genre))
                .Select(f => new
                {
                    CountGenre = f.FilmsGenres.Count(),
                    Titles = f.Title,
                    Genres = f.FilmsGenres
                        .Select(fg => fg.Genre.Name)
                }).ToListAsync();

            return Ok(filmsGrouped);
        }

        [HttpGet("GetDynamicsFilters")]
        [ProducesResponseType(200), ProducesResponseType(404)]
        [EndpointSummary("GetDynamicsFilters")]
        [EndpointDescription($"Obtener la infomación por distintas características, dependiendo de los valores que le pasamos.")]
        public async Task<ActionResult> GetDynamicsFilters([FromQuery] FilmsFiltersDTO filmsFilters)
        {

            var filmsQueryable = _context.FilmTable.AsQueryable();

            if (string.IsNullOrEmpty(filmsFilters.TitleFilm) == false  && string.IsNullOrWhiteSpace(filmsFilters.TitleFilm) == false)
            {
                filmsQueryable = filmsQueryable.Where(f => f.Title.Contains(filmsFilters.TitleFilm));
            }

            if (filmsFilters.GenreId > 0)
            {
                filmsQueryable = filmsQueryable
                    .Include(g => g.FilmsGenres.Where(fg => fg.GenreId == fg.GenreId));
                   // .Select(x => x);
            }

            if (filmsFilters.InMovies)
            {
                filmsQueryable = filmsQueryable.Where(f => f.InMovie == true);
            }

            if(filmsFilters.NextPremieres)
            {
                DateTime dateToday = DateTime.Now;
                filmsQueryable = filmsQueryable.Where(f => f.PremiereDate > dateToday);
            }

            return Ok(filmsQueryable);
        }
    }
}
