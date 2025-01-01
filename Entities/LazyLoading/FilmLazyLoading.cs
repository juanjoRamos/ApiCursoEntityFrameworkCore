namespace ApiCursoEntityFrameworkCore.Entities.LazyLoading
{
    public class FilmLazyLoading
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool InMovie { get; set; }
        public DateTime PremiereDate { get; set; }
        public string Poster { get; set; }

        //propiedades de navegacion
        public virtual ICollection<FilmsActors> FilmsActors { get; set; }
        public virtual ICollection<FilmsGenres> FilmsGenres { get; set; }
        public virtual ICollection<FilmsMovieTheaters> FilmsMovieTheaters { get; set; }
    }
}
