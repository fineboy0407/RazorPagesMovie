using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;

namespace RazorPagesMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesMovieContext(serviceProvider.GetRequiredService<DbContextOptions<RazorPagesMovieContext>>()))
            {
                if (context == null || context.Movie == null)
                {
                    throw new ArgumentNullException("Null RazorPagesMovieContext");
                }

                // Look for any movies
                if(context.Movie.Any())
                {
                    return; // DB has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "When Harry meet Sally",
                        ReleaseDate = DateTime.Parse("1990-2-3"),
                        Genre = "Romantic Comedy",
                        Price = 7.99M,
                    },

                    new Movie
                    {
                        Title = "Ghostbusters",
                        ReleaseDate = DateTime.Parse("1999-11-3"),
                        Genre = "Comedy",
                        Price = 8.88M,
                    },

                    new Movie
                    {
                        Title = "Rio Bavo",
                        ReleaseDate = DateTime.Parse("2019-2-1"),
                        Genre = "Western",
                        Price = 2.5M,
                    }

                );

                context.SaveChanges();
            }
        }
    }
}
