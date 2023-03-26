using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStore.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly BookStore.Data.BookStoreContext _context;

        public IndexModel(BookStore.Data.BookStoreContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;
        
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? MovieGenre { get; set; }
        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Book
                orderby m.Genre
                select m.Genre;

            var books = from b in _context.Book
                select b;

            if (!string.IsNullOrEmpty(SearchString))
            {
                books = books.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(MovieGenre))
            {
                books = books.Where(x => x.Genre == MovieGenre);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Book = await books.ToListAsync();
        }
    }
}
