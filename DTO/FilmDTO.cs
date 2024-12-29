namespace ApiCursoEntityFrameworkCore.DTO
{
    public class FilmDTO
    {
        public int Id  { get; set; }
        public string Title { get; set; }
        public ICollection<GenreDTO> Genres { get; set; }
        public ICollection<MoviesDTO> CinemasOrMovies { get; set; }
        public ICollection<ActorDTO> Actors { get; set; }

    }
}
