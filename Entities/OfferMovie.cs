namespace ApiCursoEntityFrameworkCore.Entities
{
    public class OfferMovie
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal PercentageDiscount  { get; set; }

        //propiedad para ver a qué cine le pertenece esta oferta (1 a 1)
        public int MovieId { get; set; }
    }
}
