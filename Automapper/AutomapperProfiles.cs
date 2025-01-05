using ApiCursoEntityFrameworkCore.DTO;
using ApiCursoEntityFrameworkCore.Entities;
using AutoMapper;

namespace ApiCursoEntityFrameworkCore.Automapper
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<Actor, ActorDTO>();
            //Esto lo podemos hacer si sacamos la informacion de bbdd que no funciona 
            //separando la X y la Y de la localizacion
            CreateMap<Movie, MoviesDTO>()
                .ForMember(dto => dto.Latitud, ent => ent.MapFrom(prop => prop.Location.Y))
                .ForMember(dto => dto.Longitud, ent => ent.MapFrom(prop => prop.Location.X));

            CreateMap<Movie, MoviesAutomapperDTO>();

            CreateMap<Genre, GenreDTO>();

            CreateMap<FilmsActors, FilmsActorDTO>()
                .ForMember(dto => dto.Actor, ent => ent.MapFrom(prop => prop.Actor));

            CreateMap<FilmsGenres, FilmsGenresDTO>()
                .ForMember(dto => dto.Genre, ent => ent.MapFrom(prop => prop.Genre));

            CreateMap<FilmsMovieTheaters, FilmsMovieTheatersDTO>()
                .ForMember(dto => dto.MovieTheater, ent => ent.MapFrom(prop => prop.MovieTheater));

            //CreateMap<Film, FilmDTO>()
            //    .ForMember(dto => dto.Genres, ent => ent.MapFrom(prop => prop.FilmsGenres.Select(mc => mc.Genre)))
            //    .ForMember(dto => dto.CinemasOrMovies, ent => ent.MapFrom(prop => prop.FilmsMovieTheaters.Select(mc => mc.MovieTheater)))
            //    .ForMember(dto => dto.Actors, ent => ent.MapFrom(prop => prop.FilmsActors.Select(mc => mc.Actor)));

            CreateMap<Film, FilmAutoMapperDTO>()
                .ForMember(dto => dto.Genres, ent => ent.MapFrom(prop => prop.FilmsGenres.Select(x => x.Genre)))
                .ForMember(dto => dto.CinemasOrMovies, ent => ent.MapFrom(prop => prop.FilmsMovieTheaters.Select(x => x.MovieTheater.Movie)))
                .ForMember(dto => dto.Actors, ent => ent.MapFrom(prop => prop.FilmsActors.Select(x => x.Actor)));

        }
    }
}
