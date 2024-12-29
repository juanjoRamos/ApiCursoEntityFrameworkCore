using ApiCursoEntityFrameworkCore.ApplicationDb;
using ApiCursoEntityFrameworkCore.DTO;
using ApiCursoEntityFrameworkCore.Entities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite;
using NetTopologySuite.Geometries;

namespace ApiCursoEntityFrameworkCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MoviesController(ApplicationDbContext dbContext, IMapper mapper)
        {
            this._context = dbContext;
            this._mapper = mapper;

        }

        [HttpGet("GetMovies")]
        public async Task<IEnumerable<Movie>> GetMovies() 
        {
            return await _context.MovieTable.ToListAsync();
        }

        /// <summary>
        /// En ocasiones como el de SQLServer cuando queremos usar
        /// datos espaciales como la localización puede tener problemas.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetMoviesDTO")]
        public async Task<IEnumerable<MoviesDTO>> GetMoviesDTO()
        {
            return await _context.MovieTable
                .ProjectTo<MoviesDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }


        /// <summary>
        /// Para poder hacer estas cosas tenemos que tener en cuenta que en bbdd
        /// la columna sea de srid:4326 y que sea geography
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns>Distancia en metros</returns>
        [HttpGet("GetMoviesCloseToMe")]
        public async Task<ActionResult> GetMoviesCloseToMe([FromQuery] double latitude, [FromQuery] double longitude)
        {
            var geometryfactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            var myLocation = geometryfactory.CreatePoint(new Coordinate(longitude, latitude));
            
            var MoviesCloseToMe = await _context.MovieTable
                .OrderBy(x =>  x.Location.Distance(myLocation))
                .Select(x => new
                {
                    Name = x.Name,
                    Distance = Math.Round(x.Location.Distance(myLocation))
                })
                .ToListAsync();

            return Ok(MoviesCloseToMe);
        }

        /// <summary>
        /// Para poder hacer estas cosas tenemos que tener en cuenta que en bbdd
        /// la columna sea de srid:4326 y que sea geography.
        /// Podemos acotar poniendo los kilometros (porque hacemos la conversion a metros),
        /// es decir, lugar >= kilometros
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="Kilometers"></param>
        /// <returns>Distancia en metros</returns>
        [HttpGet("GetMoviesWithinXKilometersOfMe")]
        public async Task<ActionResult> GetMoviesCloseToMe([FromQuery] double latitude, [FromQuery] double longitude, [FromQuery] int Kilometers)
        {
            var geometryfactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            var myLocation = geometryfactory.CreatePoint(new Coordinate(longitude, latitude));

            var MoviesCloseToMe = await _context.MovieTable
                .OrderBy(x => x.Location.Distance(myLocation))
                .Where(x => x.Location.IsWithinDistance(myLocation, Kilometers * 1000))
                .Select(x => new
                {
                    Name = x.Name,
                    Distance = Math.Round(x.Location.Distance(myLocation))
                })
                .ToListAsync();

            return Ok(MoviesCloseToMe);
        }

        [HttpPut("UpdateLocations")]
        public async Task<ActionResult> UpdateLocations(int indice)
        {
            var geometryfactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            var movie = await _context.MovieTable.FindAsync(indice);
            movie.Location =  geometryfactory.CreatePoint(new Coordinate(-69.939248, 18.469649));
            _context.MovieTable.Update(movie);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
