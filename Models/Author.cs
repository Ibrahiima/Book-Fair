using System.ComponentModel.DataAnnotations;

namespace Book_Fair.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public int Age { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
