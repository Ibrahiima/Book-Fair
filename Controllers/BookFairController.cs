using Book_Fair.Context;
using Book_Fair.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Book_Fair.Controllers
{
    public class BookFairController : Controller
    {
        BFDbContext BookFairDB = new BFDbContext();
        public IActionResult Index()
        {
            var query = BookFairDB.Book.Include(book => book.Author).ToList();
            return View(query);
        }

        public IActionResult Create()
        {
            var authors = BookFairDB.Author.ToList();
            ViewBag.Authors = authors;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            var authorName = book.Author.Name.ToLower();
            var author = BookFairDB.Author.FirstOrDefault(author => author.Name.ToLower() == authorName);

            if (author != null)
            {
                if (author.Books == null)
                {
                    author.Books = new List<Book>();
                }
                author.Books.Add(book);
            }
            else
            {
                var newAuthor = new Author { Name = authorName };
                newAuthor.Books = new List<Book> { book };
                BookFairDB.Author.Add(newAuthor);
            }

            BookFairDB.SaveChanges();
            return RedirectToAction("Index");
        }
    

        public IActionResult Edit(int BookId)
        {
            var book = BookFairDB.Book.Include(b => b.Author).FirstOrDefault(b => b.BookId == BookId);
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {

            BookFairDB.Book.Update(book);
            BookFairDB.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int BookId)
        {
            var bookToDelete = BookFairDB.Book.FirstOrDefault(d => d.BookId == BookId);

            if (bookToDelete == null)
            {
                return NotFound();
            }

            BookFairDB.Book.Remove(bookToDelete);
            BookFairDB.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
