using ApiCursoEntityFrameworkCore.ApplicationDb;
using ApiCursoEntityFrameworkCore.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCursoEntityFrameworkCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GenresController(ApplicationDbContext context)
        {
            this._context = context;
        }

        [HttpGet("GetGenres")]
        public async Task<IEnumerable<Genre>> GetGenresAsync() 
        {
            //AsNoTracking se usa cuando los datos van a ser de sólo lectura
            //Con OrderBy se ordena de forma ascendente A - Z
            //Con OrderByDescending de forma descendente Z - A
            return await _context.GenreTable
                 // .AsNoTracking()
                .OrderBy(g => g.Name)
                .ToListAsync();
        }

        [HttpGet("GetFirst")]
        public async Task<Genre> First([FromQuery] string Genre)
        {
            return await _context.GenreTable.FirstAsync(g => g.Name.Contains(Genre));
        }

        [HttpGet("GetFirstOrDefault")]
        public async Task<ActionResult<Genre>> FirstOrDefault([FromQuery] string Genre)
        {
            var genreFound = await _context.GenreTable.FirstOrDefaultAsync(g => g.Name.Contains(Genre));
            if (genreFound is null) 
            {
                return NotFound();
            }
            return genreFound;
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<Genre>> FirstOrDefault([FromQuery] int Id)
        {
            var genreFound = await _context.GenreTable.FirstOrDefaultAsync(g => g.Id == Id);
            if (genreFound is null)
            {
                return NotFound();
            }
            return genreFound;
        }

        [HttpGet("GetByStartWithOrFinishWith")]
        public async Task<IEnumerable<Genre>> Filter([FromQuery] string Letter)
        {
            return await _context.GenreTable
                .Where(g => g.Name.StartsWith(Letter) || g.Name.EndsWith(Letter))
                .ToListAsync();
        }

        [HttpGet("GetContainsByName")]
        public async Task<IEnumerable<Genre>> ContainsByName([FromQuery] string Letters)
        {
            return await _context.GenreTable
                .Where(g => g.Name.Contains(Letters))
                .ToListAsync();
        }

        [HttpGet("GetPagination")]
        public async Task<IEnumerable<Genre>> Pagination([FromQuery] int ElementsToLook = 5, [FromQuery] int ElementsLookedBefore = 0)
        {

            return await _context.GenreTable
                .Skip(ElementsLookedBefore)
                .Take(ElementsToLook)
                .ToListAsync();
        }
    }
}
