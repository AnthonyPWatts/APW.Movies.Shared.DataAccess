using Microsoft.EntityFrameworkCore;
using Movies.Shared.DataAccess.Models;

namespace Movies.Shared.DataAccess.Interfaces;

public interface IMoviesDbContext
{
    internal DbSet<Movie> Movies { get; set; }

    internal DbSet<Actor> Actors { get; set; }

    internal DbSet<MovieActor> MoviesActors { get; set; }

    internal Task<int> SaveChangesAsync();
}
