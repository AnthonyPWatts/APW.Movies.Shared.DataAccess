using AnthonyPWatts.Movies.Shared.Contracts.DTOs;

namespace Movies.Shared.DataAccess.Models;

internal sealed class MovieActor
{
    public int MovieId { get; set; }

    public int ActorId { get; set; }

    public Actor Actor { get; set; } = null!;
    public Movie Movie { get; set; } = null!;

    public MovieActorDto ToDto()
    {
        return new MovieActorDto
        {
            MovieID = MovieId,
            ActorID = ActorId
        };
    }
}
