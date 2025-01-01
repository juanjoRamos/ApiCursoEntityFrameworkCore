namespace ApiCursoEntityFrameworkCore.Entities.LazyLoading
{
    public class GenreLazyLoading
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Film> Films { get; set; }
        public virtual ICollection<FilmsGenres> FilmsGenres { get; set; }
    }
}
