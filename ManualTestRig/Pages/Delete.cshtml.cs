using AnthonyPWatts.Movies.Shared.Contracts.DTOs;
using AnthonyPWatts.Movies.Shared.Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ManualTestRig.Pages;

public sealed class DeleteModel(IMovieRepository movieRepository) : PageModel
{
    private readonly IMovieRepository _movieRepository = movieRepository
        ?? throw new ArgumentNullException(nameof(movieRepository));

    public MovieDto? Movie { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Movie = await _movieRepository.GetByIdAsync(id);
        return Movie == null ? NotFound() : Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        var deleteResult = await _movieRepository.DeleteAsync(id);
        return deleteResult == false ? RedirectToPage("./Error") : RedirectToPage("./Index");
    }
}
