using AnthonyPWatts.Movies.Shared.Contracts.DTOs;
using AnthonyPWatts.Movies.Shared.Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ManualTestRig.Pages;

public sealed class IndexModel(ILogger<IndexModel> logger, IMovieRepository movieRepository) : PageModel
{
    private readonly ILogger<IndexModel> _logger = logger;
    private readonly IMovieRepository _movieRepository = movieRepository 
        ?? throw new ArgumentNullException(nameof(movieRepository));

    public IEnumerable<MovieDto> Movies = [];

    public async Task OnGet()
    {
        Movies = await _movieRepository.GetAllAsync() ?? [];
    }
}
