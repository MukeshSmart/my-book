using my_book.Data.Models;
using my_book.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_book.Data.Services
{
    public class AuthorsService
    {
        private AppDbContext _context;
        public AuthorsService(AppDbContext context)
        {
            _context = context;
        }

        public void AddAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
                FullName = author.FullName
            };
            _context.Authors.Add(_author);
            _context.SaveChanges();
        }

        public AuthorBooksVM GetAuthorBooks(int authorId)
        {
            var _authorBooks = _context.Authors.Where(a => a.Id == authorId)
                .Select(x => new AuthorBooksVM()
                {
                    FullName = x.FullName,
                    BookTitles = x.Book_Authors.Select(ba=>ba.Book.Title).ToList()

                }).FirstOrDefault();
            return _authorBooks;
        }
    }
}