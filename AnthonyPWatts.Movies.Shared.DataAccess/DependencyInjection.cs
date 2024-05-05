using AnthonyPWatts.Movies.Shared.Contracts.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Movies.Shared.DataAccess.Interfaces;

namespace Movies.Shared.DataAccess;

public static class DependencyInjection
{
    public static IServiceCollection AddMovieDataAccess(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<MoviesDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IMoviesDbContext, MoviesDbContext>();
        services.AddScoped<IMovieRepository, MovieRepository>();
        services.AddScoped<IMovieActorRepository, MovieActorRepository>();
        services.AddScoped<IActorRepository, ActorRepository>();

        return services;
    }
}
