namespace ApiCursoEntityFrameworkCore.Entities
{
    /// <summary>
    /// Esta clase va a representar una tabla intermedia entre pelicula y actor
    /// </summary>
    public class FilmsActors
    {
        public int FilmId { get; set; }
        public int ActorId { get; set; }
        public string Character { get; set; }
        public int Order { get; set; }

        //propiedades de navegacion
        public Film Film { get; set; }
        public Actor Actor { get; set; }
    }
}
