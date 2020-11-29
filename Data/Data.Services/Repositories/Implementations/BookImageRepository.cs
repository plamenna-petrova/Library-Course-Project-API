using Data.DataConnection;
using Data.Models.Models;
using Data.Services.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Data.Services.Repositories.Implementations
{
    public class BookImageRepository : IBookImageRepository
    {
        private readonly ApplicationDbContext _bookImageContext;

        public BookImageRepository(ApplicationDbContext bookImageContext)
        {
            _bookImageContext = bookImageContext;
        }

        public ICollection<BookImage> GetBookImages()
        {
            return _bookImageContext.BookImages.OrderBy(bi => bi.BookImageUrl).ToList();
        }

        public BookImage GetBookImageById(int bookImageId)
        {
            return _bookImageContext.BookImages.Where(bi => bi.Id == bookImageId).FirstOrDefault();
        }

        public Book GetBookOfAnBookImage(int bookImageId)
        {
            var bookId = _bookImageContext.BookImages.Where(bi => bi.Id == bookImageId).Select(b => b.Book.Id).FirstOrDefault();
            return _bookImageContext.Books.Where(b => b.Id == bookId).FirstOrDefault();
        }

        public bool BookImageExists(int bookImageId)
        {
            return _bookImageContext.BookImages.Any(bi => bi.Id == bookImageId);
        }

        public bool CreateBookImage(BookImage bookImage)
        {
            _bookImageContext.Add(bookImage);
            return Save();
        }

        public bool UpdateBookImage(BookImage bookImage)
        {
            _bookImageContext.Update(bookImage);
            return Save();
        }

        public bool DeleteBookImage(BookImage bookImage)
        {
            _bookImageContext.Remove(bookImage);
            return Save();
        }

        public bool Save()
        {
            var saved = _bookImageContext.SaveChanges();
            return saved >= 0 ? true : false;
        }
    }
}