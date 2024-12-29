using ApiCursoEntityFrameworkCore.ApplicationDb;
using ApiCursoEntityFrameworkCore.DTO;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCursoEntityFrameworkCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActoresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ActoresController(ApplicationDbContext applicationDb, IMapper mapper)
        {
            this._context = applicationDb;
            this._mapper = mapper;
        }

        [HttpGet("GetActores")]
        public async Task<ActionResult> GetActores() 
        {
            var actores = await _context.ActorTable
                .Select(a => new
                {
                    Id = a.Id,
                    Name = a.Name,
                })
                .ToListAsync();

            return Ok(actores);
        }

        [HttpGet("GetActoresDTO")]
        public async Task<IEnumerable<ActorDTO>> GetActoresDTO()
        {
            return await _context.ActorTable
                .Select(a => new ActorDTO
                {
                    Id = a.Id,
                    Name = a.Name,
                })
                .ToListAsync();
        }

        [HttpGet("GetActoresAutomapper")]
        public async Task<IEnumerable<ActorDTO>> GetActoresAutoMapper()
        {
            return await _context.ActorTable
                .ProjectTo<ActorDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

    }
}
