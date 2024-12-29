namespace ApiCursoEntityFrameworkCore.Entities
{
    public class Film
    {
        public int Id{ get; set; }
        public string Title { get; set; }
        public bool InMovie { get; set; }
        public DateTime PremiereDate { get; set; }
        public string Poster { get; set; }

        //propiedades de navegacion
        public ICollection<FilmsActors> FilmsActors { get; set; }
        public ICollection<FilmsGenres> FilmsGenres { get; set; }
        public ICollection<FilmsMovieTheaters> FilmsMovieTheaters { get; set; }
    }
}
