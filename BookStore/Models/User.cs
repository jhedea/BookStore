using System.ComponentModel.DataAnnotations;

namespace BookStore.Models;

public class User
{
    
    [StringLength(60, MinimumLength = 3)]
    public int Id { get; set; }

    
    [Display(Name = "Join Date")]
    [DataType(DataType.Date)]
    public DateTime JoinDate { get; set; }
    
    
    [StringLength(60, MinimumLength = 3)]

    public string? Address { get; set; }
}