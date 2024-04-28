using AnthonyPWatts.Movies.Shared.Contracts.DTOs;
using AnthonyPWatts.Movies.Shared.Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ManualTestRig.Pages
{
    public class IndexModel(ILogger<IndexModel> logger, IMovieRepository movieRepository) : PageModel
    {
        private readonly ILogger<IndexModel> _logger = logger;
        private readonly IMovieRepository _movieRepository = movieRepository;
        public IEnumerable<MovieDto> Movies { get; set; }

        public async Task OnGet()
        {
            Movies = await _movieRepository.GetAllAsync();
        }
    }
}
