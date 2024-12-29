using ApiCursoEntityFrameworkCore.Entities;

namespace ApiCursoEntityFrameworkCore.DTO
{
    public class FilmsActorDTO
    {
        public int Id { get; set; }
        public string Character { get; set; }
        public Actor Actor { get; set; }
    }
}
