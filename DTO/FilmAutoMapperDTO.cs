namespace ApiCursoEntityFrameworkCore.DTO
{
    public class FilmAutoMapperDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<GenreDTO> Genres { get; set; }
        public ICollection<MoviesAutomapperDTO> CinemasOrMovies { get; set; }
        public ICollection<ActorDTO> Actors { get; set; }
    }
}
