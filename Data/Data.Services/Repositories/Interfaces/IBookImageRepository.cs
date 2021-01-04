using Data.Models.Models;
using Data.Services.DtoModels.CreateDtos;
using Data.Services.DtoModels.Dtos;
using Data.Services.DtoModels.UpdateDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.Repositories.Interfaces
{
    public interface IBookImageRepository
    {
        ICollection<BookImageDto> GetBookImages();
        BookImageDto GetBookImageById(int bookImageId);
        BookImage GetBookImageByIdNotMapped(int bookImageId);
        BookDto GetBookOfAnBookImage(int bookImageId);
        bool BookImageExists(int bookImageId);
        bool CreateBookImage(BookImageCreateDto bookImageToCreateDto);
        bool UpdateBookImage(BookImageUpdateDto bookImageToUpdateDto);
        bool DeleteBookImage(BookImage bookImageToDelete);
        bool Save();
    }
}
