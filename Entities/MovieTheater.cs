using ApiCursoEntityFrameworkCore.Enumerations;

namespace ApiCursoEntityFrameworkCore.Entities
{
    public class MovieTheater
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public TypeMovieTheater TypeMovieTheater { get; set; }
        public int MovieId { get; set; }
        public Movie Movie  { get; set; }

        public ICollection<FilmsMovieTheaters> FilmsMovieTheaters { get; set; }
    }
}
