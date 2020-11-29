using Data.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.Repositories.Interfaces
{
    public interface IGenreRepository
    {
        ICollection<Genre> GetGenres();
        Genre GetGenreById(int genreId);
        ICollection<Genre> GetAllGenresForABook(int bookId);
        ICollection<Book> GetAllBooksForGenre(int genreId);
        bool GenreExists(int genreId);
        bool IsDuplicateGenreName(int genreId, string genreName);
        bool CreateGenre(Genre genre);
        bool UpdateGenre(Genre genre);
        bool DeleteGenre(Genre genre);
        bool Save();
    }
}
