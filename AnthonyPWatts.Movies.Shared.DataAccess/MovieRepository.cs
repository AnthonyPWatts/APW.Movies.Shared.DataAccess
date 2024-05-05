using AnthonyPWatts.Movies.Shared.Contracts.DTOs;
using AnthonyPWatts.Movies.Shared.Contracts.Interfaces;
using Microsoft.EntityFrameworkCore;
using Movies.Shared.DataAccess.Interfaces;
using Movies.Shared.DataAccess.Models;

namespace Movies.Shared.DataAccess;

public sealed class MovieRepository(IMoviesDbContext context) : IMovieRepository
{
    private readonly IMoviesDbContext _context = context;

    public async Task<MovieDto?> AddAsync(MovieDto movie)
    {
        //TODO: Add validation

        var newMovie = new Movie
        {
            Title = movie.Title,
            Director = movie.Director,
            Genre = movie.Genre
        };

        _context.Movies.Add(newMovie);
        await _context.SaveChangesAsync();
        return newMovie?.ToDto();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var movie = await _context.Movies.FindAsync(id);

        if (movie is not null)
        {
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }

        // Make sure it is gone
        return !(await _context.Movies.AnyAsync(x => x.Id == id));
    }

    public async Task<IEnumerable<MovieDto>> GetAllAsync()
    {
        return await _context.Movies
            .Select(m => m.ToDto())
            .ToListAsync();
    }

    public async Task<MovieDto?> GetByIdAsync(int id)
    {
        var movie = await _context.Movies.FindAsync(id);

        return movie?.ToDto();
    }

    public async Task<MovieDto?> UpdateAsync(MovieDto movie)
    {
        var existingMovie = await _context.Movies.FindAsync(movie.ID);

        if (existingMovie == null)
            return null;

        existingMovie.Title = movie.Title;
        existingMovie.Director = movie.Director;
        existingMovie.ReleaseYear = movie.ReleaseYear;
        existingMovie.Genre = movie.Genre;

        await _context.SaveChangesAsync();

        return existingMovie.ToDto();
    }
}
