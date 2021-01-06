using Data.Models.Models;
using Data.Services.DtoModels.CreateDtos;
using Data.Services.DtoModels.Dtos;
using Data.Services.DtoModels.UpdateDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.Repositories.Interfaces
{
    public interface IGenreRepository
    {
        ICollection<GenreDto> GetGenres();
        GenreDto GetGenreById(int genreId);
        Genre GetGenreByIdNotMapped(int genreId);
        ICollection<GenreDto> GetAllGenresForABook(int bookId);
        ICollection<BookDto> GetAllBooksForGenre(int genreId);
        bool GenreExists(int genreId);
        bool IsDuplicateGenreName(int genreId, string genreName);
        bool CreateGenre(GenreCreateDto genreToCreateDto);
        bool UpdateGenre(GenreUpdateDto genreToUpdateDto);
        bool DeleteGenre(Genre genre);
        bool Save();
    }
}
