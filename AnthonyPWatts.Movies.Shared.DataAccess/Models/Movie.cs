using AnthonyPWatts.Movies.Shared.Contracts.DTOs;

namespace Movies.Shared.DataAccess.Models;

internal sealed class Movie
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public int? ReleaseYear { get; set; }

    public string? Genre { get; set; }

    public string? Director { get; set; }

    public MovieDto ToDto()
    {
        return new MovieDto(
            Id,
            Title ?? "",
            ReleaseYear,
            Genre ?? "",
            Director ?? "");
    }
}
