using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;
using Book_Fair.Models;

namespace Book_Fair.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        public string Title { get; set; }

        public int PageCount { get; set; }
        public double Price { get; set; }
        public string GenreName { get; set; }

        public Author Author { get; set; }

    }
}
