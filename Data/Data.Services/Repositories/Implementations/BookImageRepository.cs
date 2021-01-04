using Data.DataConnection;
using Data.Models.Models;
using Data.Services.DtoModels.CreateDtos;
using Data.Services.DtoModels.Dtos;
using Data.Services.DtoModels.UpdateDtos;
using Data.Services.Helpers;
using Data.Services.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Services.Repositories.Implementations
{
    public class BookImageRepository : IBookImageRepository
    {
        private readonly ApplicationDbContext _bookImageContext;

        public BookImageRepository(ApplicationDbContext bookImageContext)
        {
            _bookImageContext = bookImageContext;
        }

        public ICollection<BookImageDto> GetBookImages()
        {
            var bookImages = _bookImageContext.BookImages.OrderBy(bi => bi.BookImageUrl).ToList();
            var mappedBookImages = MapConfig.Mapper.Map<ICollection<BookImageDto>>(bookImages);
            return mappedBookImages;
        }

        public BookImageDto GetBookImageById(int bookImageId)
        {
            var singleBookImage = _bookImageContext.BookImages.Where(bi => bi.Id == bookImageId).FirstOrDefault();
            var mappedBookImage = MapConfig.Mapper.Map<BookImageDto>(singleBookImage);
            return mappedBookImage;
        }

        public BookImage GetBookImageByIdNotMapped(int bookImageId)
        {
            var bookImage = _bookImageContext.BookImages.Where(bi => bi.Id == bookImageId).FirstOrDefault();
            return bookImage;
        }

        public BookDto GetBookOfAnBookImage(int bookImageId)
        {
            //var bookId = _bookImageContext.BookImages.Where(bi => bi.Id == bookImageId).Select(b => b.Book.Id).FirstOrDefault();
            var book = _bookImageContext.BookImages.Where(bi => bi.Id == bookImageId).Select(b => b.Book).FirstOrDefault();
            var mappedBook = MapConfig.Mapper.Map<BookDto>(book);
            //return _bookImageContext.Books.Where(b => b.Id == bookId).FirstOrDefault();
            return mappedBook;
        }

        public bool BookImageExists(int bookImageId)
        {
            return _bookImageContext.BookImages.Any(bi => bi.Id == bookImageId);
        }

        public bool CreateBookImage(BookImageCreateDto bookImageToCreateDto)
        {
            var bookImageToCreate = MapConfig.Mapper.Map<BookImage>(bookImageToCreateDto);
            _bookImageContext.Add(bookImageToCreate);
            return Save();
        }

        public bool UpdateBookImage(BookImageUpdateDto bookImageToUpdateDto)
        {
            var bookImageToUpdate = MapConfig.Mapper.Map<BookImage>(bookImageToUpdateDto);
            _bookImageContext.Update(bookImageToUpdate);
            return Save();
        }

        public bool DeleteBookImage(BookImage bookImageToDelete)
        {
            _bookImageContext.Remove(bookImageToDelete);
            return Save();
        }

        public bool Save()
        {
            var saved = _bookImageContext.SaveChanges();
            return saved >= 0 ? true : false;
        }
    }
}
