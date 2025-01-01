namespace ApiCursoEntityFrameworkCore.Entities.LazyLoading
{
    public class FilmsMovieTheatersLazyLoading
    {
        public int FilmId { get; set; }
        public int MovieTheaterId { get; set; }

        //Propiedades de navegacion
        public virtual Film Film { get; set; }
        public virtual MovieTheater MovieTheater { get; set; }
    }
}
