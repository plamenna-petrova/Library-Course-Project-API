using Data.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DataConnection.Repositories.Interfaces
{
    public interface IBookImageRepository
    {
        ICollection<BookImage> GetBookImages();
        BookImage GetBookImageById(int bookImageId);
        Book GetBookOfAnBookImage(int bookImageId);
        bool BookImageExists(int bookImageId);
        bool CreateBookImage(BookImage bookImage);
        bool UpdateBookImage(BookImage bookImage);
        bool DeleteBookImage(BookImage bookImage);
        bool Save();
    }
}
