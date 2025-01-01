namespace ApiCursoEntityFrameworkCore.Entities.LazyLoading
{
    public class ActorLazyLoading
    {
        //No es obligatorio hacerlo en otra clase, sino que en cada prop de navegación
        //pondremos la palabra reservada "virtual"
        public int Id { get; set; }
        public string Name { get; set; }
        public string Biografy { get; set; }
        public DateTime? DateOfBirth { get; set; }

        //propiedad de navegación
        public virtual ICollection<FilmsActors> FilmsActors { get; set; }
    }
}
