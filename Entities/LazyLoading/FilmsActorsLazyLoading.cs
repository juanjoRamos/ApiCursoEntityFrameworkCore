namespace ApiCursoEntityFrameworkCore.Entities.LazyLoading
{
    public class FilmsActorsLazyLoading
    {
        public int FilmId { get; set; }
        public int ActorId { get; set; }
        public string Character { get; set; }
        public int Order { get; set; }

        //propiedades de navegacion
        public virtual Film Film { get; set; }
        public virtual Actor Actor { get; set; }
    }
}
