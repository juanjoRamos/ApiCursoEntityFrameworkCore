using NetTopologySuite.Geometries;

namespace ApiCursoEntityFrameworkCore.Entities.LazyLoading
{
    public class MovieLazyLoading
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Point Location { get; set; }

        //Propiedades de navegacion

        //hacer la relacion (1 a 1)
        public virtual OfferMovie OfferMovie { get; set; }
         
        //hacer la relacion (1 a *)
        public virtual ICollection<MovieTheater> MovieTheaters { get; set; }
    }
}
