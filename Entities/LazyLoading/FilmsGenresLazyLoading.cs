namespace ApiCursoEntityFrameworkCore.Entities.LazyLoading
{
    public class FilmsGenresLazyLoading
    {
        public int FilmId { get; set; }
        public int GenreId { get; set; }

        //Propiedades de navegacion
        public virtual Film Film { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
