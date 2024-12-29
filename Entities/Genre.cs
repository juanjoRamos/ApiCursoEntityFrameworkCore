namespace ApiCursoEntityFrameworkCore.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Film> Films { get; set; }
        public ICollection<FilmsGenres> FilmsGenres { get; set; }
    }
}
