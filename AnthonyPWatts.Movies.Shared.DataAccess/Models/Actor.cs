using AnthonyPWatts.Movies.Shared.Contracts.DTOs;

namespace Movies.Shared.DataAccess.Models;

internal sealed class Actor
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public DateOnly? BirthDate { get; set; }

    public ActorDto ToDto()
    {
        return new ActorDto(
            Id,
            Name ?? "",
            BirthDate?.ToDateTime(new TimeOnly(0))); 
    }
}
