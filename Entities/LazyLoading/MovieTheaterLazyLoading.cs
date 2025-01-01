using ApiCursoEntityFrameworkCore.Enumerations;

namespace ApiCursoEntityFrameworkCore.Entities.LazyLoading
{
    public class MovieTheaterLazyLoading
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public TypeMovieTheater TypeMovieTheater { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public virtual ICollection<FilmsMovieTheaters> FilmsMovieTheaters { get; set; }
    }
}
