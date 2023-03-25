namespace BookStore.Models;
using System.ComponentModel.DataAnnotations;

public class Book
{
    public int Id { get; set; }
    public string? Title { get; set; }
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
    public string? Genre { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }

    public static void AddRange(Book book, Book book1, Book book2, Book book3)
    {
        throw new NotImplementedException();
    }

    public static bool Any()
    {
        throw new NotImplementedException();
    }
}