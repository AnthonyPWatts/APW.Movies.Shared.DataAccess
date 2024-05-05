using AnthonyPWatts.Movies.Shared.Contracts.DTOs;
using AnthonyPWatts.Movies.Shared.Contracts.Interfaces;
using Microsoft.EntityFrameworkCore;
using Movies.Shared.DataAccess.Interfaces;
using Movies.Shared.DataAccess.Models;

namespace Movies.Shared.DataAccess;

public sealed class MovieActorRepository(IMoviesDbContext context) : IMovieActorRepository
{
    private readonly IMoviesDbContext _context = context;

    public async Task<MovieActorDto?> AddAsync(MovieActorDto movieActor)
    {
        var newMovieActor = new MovieActor
        {
            MovieId = movieActor.MovieID,
            ActorId = movieActor.ActorID
        };
        await _context.SaveChangesAsync();
        return newMovieActor?.ToDto();
    }

    public async Task<bool> DeleteAsync(int movieId, int actorId)
    {
        var movieActor = await _context.MoviesActors.SingleOrDefaultAsync(x => x.MovieId == movieId && x.ActorId == actorId);

        if (movieActor is not null)
        {
            _context.MoviesActors.Remove(movieActor);
            await _context.SaveChangesAsync();
        }

        // Make sure it is gone
        return !(await _context.MoviesActors.AnyAsync(x => x.MovieId == movieId && x.ActorId == actorId));
    }

    public async Task<IEnumerable<MovieActorDto>> GetAllAsync()
    {
        return await _context.MoviesActors
            .Select(m => m.ToDto())
            .ToListAsync();
    }

    public async Task<IEnumerable<MovieActorDto>> GetAllByActorIdAsync(int id)
    {
        return await _context.MoviesActors
            .Where(x => x.ActorId == id)
            .Select(m => m.ToDto())
            .ToListAsync();
    }

    public async Task<IEnumerable<MovieActorDto>> GetAllByMovieIdAsync(int id)
    {
        return await _context.MoviesActors
            .Where(x => x.MovieId == id)
            .Select(m => m.ToDto())
            .ToListAsync();
    }

    public async Task<MovieActorDto?> GetByIdAsync(int movieId, int actorId)
    {
        var movieActor = await _context.MoviesActors
            .FirstOrDefaultAsync(x => x.MovieId == movieId && x.ActorId == actorId);

        return movieActor?.ToDto();
    }
}
