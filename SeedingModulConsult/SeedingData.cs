using ApiCursoEntityFrameworkCore.Entities;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;

namespace ApiCursoEntityFrameworkCore.SeedingModulConsult
{
    public static class SeedingData
    {
        /// <summary>
        /// Este metodo nos va a servir para insertar datos predefinidos para poder
        /// realizar el modulo de consultar datos.
        /// </summary>
        /// <param name="modelBuilder"></param>
        public static void Seed(ModelBuilder modelBuilder) 
        {
            #region Genre
            var action = new Genre() { Id = 1, Name = "Action" };
            var animation = new Genre() { Id = 2, Name = "Animation" };
            var comedy = new Genre() { Id = 3, Name = "Comedy" };
            var sciencefiction = new Genre() { Id = 4, Name = "Science fiction" };
            var drama = new Genre() { Id = 5, Name = "Drama" };

            modelBuilder.Entity<Genre>().HasData([action, animation, comedy, sciencefiction, drama]);
            #endregion

            #region Actors
            var tomHolland = new Actor() { Id= 1, Name = "Tom Holland", DateOfBirth = new DateTime(1996, 6, 1) };
            var samuelJackson = new Actor() { Id= 2, Name = "Samuel L. Jackson", DateOfBirth = new DateTime(1948, 12, 21) };
            var robertDowney = new Actor() { Id= 3, Name = "Robert Downey Jr.", DateOfBirth = new DateTime(1965, 4, 4) };
            var chrisEvans = new Actor() { Id= 4, Name = "Chris Evans", DateOfBirth = new DateTime(1981, 6, 13) };
            var theRock = new Actor() { Id= 5, Name = "Dwayne Johnson", DateOfBirth = new DateTime(1972, 5,2) };
            var auliCravalho = new Actor() { Id= 6, Name = "Auli'i Cravalho", DateOfBirth = new DateTime(2000, 11, 22) };
            var scarletJohansson = new Actor() { Id= 7, Name = "Scarlet Johansson", DateOfBirth = new DateTime(1984, 11, 22) };
            var keanuReeves = new Actor() { Id= 8, Name = "Keanu Reeves", DateOfBirth = new DateTime(1964, 9, 2) };

            modelBuilder.Entity<Actor>().HasData([tomHolland, samuelJackson, robertDowney, chrisEvans, theRock, auliCravalho, scarletJohansson, keanuReeves]);
            #endregion

            #region CinemaOrMovie
            var MovieOrCinemaAgora = new Movie() { Id = 1, Name = "Agora Mall", Location = new Point(-69.93974463520148, 18.482988400331013) };
            var MovieOrCinemaSambil = new Movie() { Id = 2, Name = "Sambil", Location = new Point(-69.91155405293314, 18.482296323201627) };
            var MovieOrCinemaMegaCentro = new Movie() { Id = 3, Name = "Megacentro", Location = new Point(-69.85647938735798, 18.50629494382821) };
            var MovieOrCinemaAcropolis = new Movie() { Id = 4, Name = "Acropolis", Location = new Point(-69.9389155139822, 18.469753004268405) };
            modelBuilder.Entity<Movie>().HasData([MovieOrCinemaAgora, MovieOrCinemaSambil, MovieOrCinemaMegaCentro, MovieOrCinemaAcropolis]);
            #endregion

            #region OfferMovie
            var AgoraMovieOffer = new OfferMovie() { Id = 1, MovieId = MovieOrCinemaAgora.Id, StartDate = DateTime.Today, EndDate = DateTime.Today.AddYears(1), PercentageDiscount = 10};
            var AcropolisMovieOffer = new OfferMovie() { Id = 2, MovieId = MovieOrCinemaAcropolis.Id, StartDate = DateTime.Today, EndDate = DateTime.Today.AddYears(1), PercentageDiscount = 15};
            modelBuilder.Entity<OfferMovie>().HasData([AgoraMovieOffer, AcropolisMovieOffer]);
            #endregion

            #region MovieTheater
            var MovieTheater2DAgora = new MovieTheater() { Id = 1, MovieId = MovieOrCinemaAgora.Id, Price= new decimal(2.20), TypeMovieTheater = Enumerations.TypeMovieTheater.dimensions2 };
            var MovieTheater3DAgora = new MovieTheater() { Id = 2, MovieId = MovieOrCinemaAgora.Id, Price= new decimal(3.20), TypeMovieTheater = Enumerations.TypeMovieTheater.dimensions3 };
            var MovieTheater2DSambil = new MovieTheater() { Id = 3, MovieId = MovieOrCinemaSambil.Id, Price= new decimal(2.00), TypeMovieTheater = Enumerations.TypeMovieTheater.dimensions2 };
            var MovieTheater3DSambil = new MovieTheater() { Id = 4, MovieId = MovieOrCinemaSambil.Id, Price= new decimal(3.00), TypeMovieTheater = Enumerations.TypeMovieTheater.dimensions3 };
            var MovieTheater2DMegacentro = new MovieTheater() { Id = 5, MovieId = MovieOrCinemaMegaCentro.Id, Price = new decimal(3.00), TypeMovieTheater = Enumerations.TypeMovieTheater.dimensions2 };
            var MovieTheater3DMegacentro = new MovieTheater() { Id = 6, MovieId = MovieOrCinemaMegaCentro.Id, Price = new decimal(3.50), TypeMovieTheater = Enumerations.TypeMovieTheater.dimensions3 };
            var MovieTheaterPremiumMegacentro = new MovieTheater() { Id = 7, MovieId = MovieOrCinemaMegaCentro.Id, Price = new decimal(4.50), TypeMovieTheater = Enumerations.TypeMovieTheater.premium };
            var MovieTheater2dAcropolis = new MovieTheater() { Id = 8, MovieId = MovieOrCinemaAcropolis.Id, Price = new decimal(2.50), TypeMovieTheater = Enumerations.TypeMovieTheater.dimensions2 };

            modelBuilder.Entity<MovieTheater>().HasData([MovieTheater2DAgora, MovieTheater3DAgora, MovieTheater2DSambil, MovieTheater3DSambil, MovieTheater2DMegacentro,MovieTheater3DMegacentro, MovieTheaterPremiumMegacentro, MovieTheater2dAcropolis]);
            #endregion

            #region Films

            #region Avengers
            var avenger = new Film()
            {
                Id = 1,
                Title = "Avengers",
                InMovie= false,
                PremiereDate = new DateTime(2012, 4, 11),
                Poster = "https://static.posters.cz/image/750/posters/avengers-one-sheet-i12720.jpg"
            };

            var avengerGenresAction = new FilmsGenres()
            {
                GenreId = action.Id,
                FilmId = avenger.Id,
            };
            var avengerGenresScienceFiction= new FilmsGenres()
            {
                GenreId = sciencefiction.Id,
                FilmId = avenger.Id,
            };
            modelBuilder.Entity<FilmsGenres>().HasData([avengerGenresAction, avengerGenresScienceFiction]);
            #endregion

            #region Coco
            var coco = new Film()
            {
                Id = 2,
                Title = "Coco",
                InMovie = false,
                PremiereDate= new DateTime(2017, 11, 22),
                Poster = "https://static.posters.cz/image/750/posters/coco-family-i56183.jpg"
            };

            var cocoGenresAnimation = new FilmsGenres()
            {
                GenreId = animation.Id,
                FilmId = coco.Id,
            };
            modelBuilder.Entity<FilmsGenres>().HasData(cocoGenresAnimation);
            #endregion

            #region NoWayHome
            var nowayhome = new Film()
            {
                Id = 3,
                Title = "Spider-Man: No way home",
                InMovie = false,
                PremiereDate= new DateTime(2021, 12, 17),
                Poster = "https://img.ecartelera.com/noticias/70100/70190-c.jpg"
            };

            var noWayHomeGenresAction = new FilmsGenres()
            {
                GenreId = action.Id,
                FilmId = nowayhome.Id,
            };            
            var noWayHomeGenresSciencefiction = new FilmsGenres()
            {
                GenreId = sciencefiction.Id,
                FilmId = nowayhome.Id,
            };            
            var noWayHomeGenresComedy = new FilmsGenres()
            {
                GenreId = comedy.Id,
                FilmId = nowayhome.Id,
            };
            modelBuilder.Entity<FilmsGenres>().HasData([noWayHomeGenresAction, noWayHomeGenresSciencefiction, noWayHomeGenresComedy]);
            #endregion

            #region FarFromHome
            var farFromHome = new Film()
            {
                Id = 4,
                Title = "Spider-Man: far from home",
                InMovie = false,
                PremiereDate= new DateTime(2019, 7, 2),
                Poster = "https://m.media-amazon.com/images/I/91B64g3nQfL.jpg"
            };

            var farFromHomeGenresAction = new FilmsGenres()
            {
                GenreId = action.Id,
                FilmId = farFromHome.Id,
            };
            var farFromHomeGenresSciencefiction = new FilmsGenres()
            {
                GenreId = sciencefiction.Id,
                FilmId = farFromHome.Id,
            };
            var farFromHomeGenresComedy = new FilmsGenres()
            {
                GenreId = comedy.Id,
                FilmId = farFromHome.Id,
            };
            modelBuilder.Entity<FilmsGenres>().HasData([farFromHomeGenresAction, farFromHomeGenresSciencefiction, farFromHomeGenresComedy]);
            #endregion

            #region theMatrixResurrections
            var theMatrixResurrections = new Film()
            {
                Id = 5,
                Title = "The Matrix Resurrections",
                InMovie = true,
                PremiereDate= new DateTime(2100, 1, 1),
                Poster = "https://www.dodmagazine.es/wp-content/uploads/2021/11/the-matrix-resurrection-poster-new.jpg"
            };

            var theMatrixResurrectionsGenresAction = new FilmsGenres()
            {
                GenreId = action.Id,
                FilmId = theMatrixResurrections.Id,
            };
            var theMatrixResurrectionsGenresSciencefiction = new FilmsGenres()
            {
                GenreId = sciencefiction.Id,
                FilmId = theMatrixResurrections.Id,
            };
            var theMatrixResurrectionsGenresDrama = new FilmsGenres()
            {
                GenreId = drama.Id,
                FilmId = theMatrixResurrections.Id,
            };
            modelBuilder.Entity<FilmsGenres>().HasData([theMatrixResurrectionsGenresAction, theMatrixResurrectionsGenresSciencefiction, theMatrixResurrectionsGenresDrama]);


            #endregion

            modelBuilder.Entity<Film>().HasData([avenger, coco, nowayhome, farFromHome, theMatrixResurrections]);
            #endregion

            #region FilmsMovieThreater
            var FilmsMovieThreaterSambil2D = new FilmsMovieTheaters()
            {
                MovieTheaterId = MovieTheater2DSambil.Id,
                FilmId = theMatrixResurrections.Id
            };

            var FilmsMovieThreaterSambil3D = new FilmsMovieTheaters()
            {
                MovieTheaterId = MovieTheater3DSambil.Id,
                FilmId = theMatrixResurrections.Id
            };

            var FilmsMovieThreaterAgora2D = new FilmsMovieTheaters()
            {
                MovieTheaterId = MovieTheater2DAgora.Id,
                FilmId = theMatrixResurrections.Id
            };

            var FilmsMovieThreaterAgora3D = new FilmsMovieTheaters()
            {
                MovieTheaterId = MovieTheater3DAgora.Id,
                FilmId = theMatrixResurrections.Id
            };

            var FilmsMovieThreaterMegacentro2D = new FilmsMovieTheaters()
            {
                MovieTheaterId = MovieTheater2DMegacentro.Id,
                FilmId = theMatrixResurrections.Id
            };

            var FilmsMovieThreaterMegacentro3D = new FilmsMovieTheaters()
            {
                MovieTheaterId = MovieTheater3DMegacentro.Id,
                FilmId = theMatrixResurrections.Id
            };

            var FilmsMovieThreaterMegacentroPremium = new FilmsMovieTheaters()
            {
                MovieTheaterId = MovieTheaterPremiumMegacentro.Id,
                FilmId = theMatrixResurrections.Id
            };

            modelBuilder.Entity<FilmsMovieTheaters>().HasData([FilmsMovieThreaterSambil2D, FilmsMovieThreaterSambil3D, FilmsMovieThreaterAgora2D, FilmsMovieThreaterAgora3D, FilmsMovieThreaterMegacentro2D, FilmsMovieThreaterMegacentro3D, FilmsMovieThreaterMegacentroPremium]);      
            #endregion

            #region ActorsFilms
            var keanuReevesMatrix = new FilmsActors() 
            {
                ActorId = keanuReeves.Id,
                FilmId = theMatrixResurrections.Id,
                Order = 1,
                Character = "Neo"
            };

            var avengersChrisEvans = new FilmsActors
            {
                ActorId = chrisEvans.Id,
                FilmId = avenger.Id,
                Order = 1,
                Character = "Capitán América"
            };

            var avengersRobertDowney = new FilmsActors
            {
                ActorId = robertDowney.Id,
                FilmId = avenger.Id,
                Order = 2,
                Character = "Iron Man"
            };

            var avengersScarlettJohansson = new FilmsActors
            {
                ActorId = scarletJohansson.Id,
                FilmId = avenger.Id,
                Order = 3,
                Character = "Black Widow"
            };

            var tomHollandFFH = new FilmsActors
            {
                ActorId = tomHolland.Id,
                FilmId = farFromHome.Id,
                Order = 1,
                Character = "Peter Parker"
            };

            var tomHollandNWH = new FilmsActors
            {
                ActorId = tomHolland.Id,
                FilmId = nowayhome.Id,
                Order = 1,
                Character = "Peter Parker"
            };

            var samuelJacksonFFH = new FilmsActors
            {
                ActorId = samuelJackson.Id,
                FilmId = farFromHome.Id,
                Order = 2,
                Character = "Samuel L. Jackson"
            };

            modelBuilder.Entity<FilmsActors>().HasData([samuelJacksonFFH, tomHollandFFH, tomHollandNWH, avengersScarlettJohansson, avengersRobertDowney, avengersChrisEvans, keanuReevesMatrix]);
            #endregion
        }
    }
}
