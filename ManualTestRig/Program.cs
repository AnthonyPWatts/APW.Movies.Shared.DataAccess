using Movies.Shared.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var moviesDbConnectionString = builder.Configuration.GetConnectionString("MoviesDB") ?? 
    throw new InvalidOperationException("MoviesDB connection string is missing");

builder.Services.AddDataAccess(moviesDbConnectionString);
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
