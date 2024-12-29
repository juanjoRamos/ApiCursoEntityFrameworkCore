namespace ApiCursoEntityFrameworkCore.Entities
{
    public class FilmsMovieTheaters
    {
        public int FilmId { get; set; }
        public int MovieTheaterId { get; set; }

        //Propiedades de navegacion
        public Film Film { get; set; }
        public MovieTheater MovieTheater { get; set; }
    }
}
