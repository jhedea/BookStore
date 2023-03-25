using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using BookStore.Data;

namespace BookStore.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new BookStoreContext((
                   serviceProvider.GetRequiredService<
                       DbContextOptions<BookStoreContext>>())))
        {
            if (context == null || typeof(Book) == null)
            {
                throw new ArgumentNullException("Null RazorPagesBookContext");
            }

            // Look for any Books.
            if (Book.Any())
            {
                return;   // DB has been seeded
            }

            Book.AddRange(
                new Book
                {
                    Title = "When Harry Met Sally",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Romantic Comedy",
                    Price = 7.99M
                },

                new Book
                {
                    Title = "Ghostbusters ",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Genre = "Comedy",
                    Price = 8.99M
                },

                new Book
                {
                    Title = "Ghostbusters 2",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Genre = "Comedy",
                    Price = 9.99M
                },

                new Book
                {
                    Title = "Rio Bravo",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Genre = "Western",
                    Price = 3.99M
                }
            );
            context.SaveChanges();
        }
    }
}