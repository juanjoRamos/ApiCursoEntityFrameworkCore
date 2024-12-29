namespace ApiCursoEntityFrameworkCore.Entities
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Biografy { get; set; }
        public DateTime? DateOfBirth { get; set; }

        //
        public ICollection<FilmsActors>  FilmsActors { get; set; }
    }
}
