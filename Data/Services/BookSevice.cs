using my_book.Data.Models;
using my_book.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_book.Data.Services
{
    public class BookSevice
    {
        private AppDbContext _context;
        public BookSevice(AppDbContext context)
        {
            _context = context;
        }

        public void AddBook(BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                CoverUrl = book.CoverUrl,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.IsRead ? book.Rate.Value : null,
                Genre = book.Genre,
                Description = book.Description,
                DateAdded = DateTime.Now,
                PublisherId = book.PublisherId

            };
            _context.Books.Add(_book);
            _context.SaveChanges();

            foreach(var id in book.AuthorIds)
            {
                var _book_author = new Book_Author()
                {
                    BookId = _book.Id,
                    AuthorId = id
                };

                _context.Book_Authors.Add(_book_author);
                _context.SaveChanges();
            }
        }

        public List<Book> GetAllBooks() => _context.Books.ToList();

        public Book GetBookById(int bookId) => _context.Books.FirstOrDefault(x=>x.Id == bookId);

        public BookAuthorVM GetBookAuthorById(int bookId)
        {
            var _bookAuthor = _context.Books.Where(x => x.Id == bookId).Select(book => new BookAuthorVM()
            {
                Title = book.Title,
                CoverUrl = book.CoverUrl,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.IsRead ? book.Rate.Value : null,
                Genre = book.Genre,
                Description = book.Description,
                PublisherName = book.Publisher.Name,
                AuthorNames = book.Book_Authors.Select(a=>a.Author.FullName).ToList()

            }).FirstOrDefault();

            return _bookAuthor;
        }

        public Book UpdateBookById(int bookId,BookVM book)
        {
            var _book = _context.Books.FirstOrDefault(x => x.Id == bookId);
            if(_book != null)
            {
                _book.Title = book.Title;
                _book.CoverUrl = book.CoverUrl;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.IsRead ? book.DateRead.Value : null;
                _book.Rate = book.IsRead ? book.Rate.Value : null;
                _book.Genre = book.Genre;
                _book.Description = book.Description;

                _context.SaveChanges();
            }
            return _book;
        }

        public void DeleteBookById(int bookId)
        {
            var _book = _context.Books.FirstOrDefault(x => x.Id == bookId);
            if (_book != null)
            {

                _context.Books.Remove(_book);
                _context.SaveChanges();
            }
        }
    }
}
