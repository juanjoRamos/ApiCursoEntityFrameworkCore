namespace ApiCursoEntityFrameworkCore.Entities
{
    public class FilmsGenres
    {
        public int FilmId { get; set; }
        public int GenreId { get; set; }

        //Propiedades de navegacion
        public Film Film { get; set; }
        public Genre Genre { get; set; }
    }
}
