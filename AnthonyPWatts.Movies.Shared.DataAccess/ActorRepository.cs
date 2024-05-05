using AnthonyPWatts.Movies.Shared.Contracts.DTOs;
using AnthonyPWatts.Movies.Shared.Contracts.Interfaces;
using Microsoft.EntityFrameworkCore;
using Movies.Shared.DataAccess.Interfaces;
using Movies.Shared.DataAccess.Models;

namespace Movies.Shared.DataAccess;

public sealed class ActorRepository(IMoviesDbContext context) : IActorRepository
{
    private readonly IMoviesDbContext _context = context;

    public async Task<ActorDto?> AddAsync(ActorDto actor)
    {
        //TODO: Add validation

        var newActor = new Actor
        {
            Name = actor.Name,
            BirthDate = actor.BirthDate == null ? null : new DateOnly(
                actor.BirthDate.Value.Year,
                actor.BirthDate.Value.Month,
                actor.BirthDate.Value.Day)
        };

        _context.Actors.Add(newActor);
        await _context.SaveChangesAsync();
        return newActor?.ToDto();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var actor = await _context.Actors
            .FirstOrDefaultAsync(x => x.Id == id);

        if (actor is not null)
        {
            _context.Actors.Remove(actor);
            await _context.SaveChangesAsync();
        }        

        return !(await _context.Actors.AnyAsync(x => x.Id == id));
    }

    public async Task<IEnumerable<ActorDto>> GetAllAsync()
    {
        return await _context.Actors
            .Select(m => m.ToDto())
            .ToListAsync();
    }

    public async Task<ActorDto?> GetByIdAsync(int id)
    {
        var actor = await _context.Actors
            .FirstOrDefaultAsync(x => x.Id == id);

        return actor?.ToDto();
    }

    public async Task<ActorDto?> UpdateAsync(ActorDto actor)
    {
        var existingActor= await _context.Actors
            .FirstOrDefaultAsync(x => x.Id == actor.ID);

        if (existingActor == null)
            return null;

        existingActor.Name = actor.Name;
        existingActor.BirthDate = actor.BirthDate == null ? null : new DateOnly(
            actor.BirthDate.Value.Year,             
            actor.BirthDate.Value.Month, 
            actor.BirthDate.Value.Day);

        await _context.SaveChangesAsync();

        return existingActor.ToDto();
    }
}
