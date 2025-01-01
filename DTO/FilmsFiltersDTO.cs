namespace ApiCursoEntityFrameworkCore.DTO
{
    public class FilmsFiltersDTO
    {
        public string TitleFilm { get; set; }
        public int GenreId { get; set; }
        public bool InMovies { get; set; }
        public bool NextPremieres { get; set; }
    }
}
