using Data.DataConnection;
using Data.Models.Models;
using Data.Services.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Services.Repositories.Implementations
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDbContext _genreContext;

        public GenreRepository(ApplicationDbContext genreContext)
        {
            _genreContext = genreContext;
        }

        public ICollection<Genre> GetGenres()
        {
            return _genreContext.Genres.OrderBy(g => g.GenreName).ToList();
        }

        public Genre GetGenreById(int genreId)
        {
            return _genreContext.Genres.Where(g => g.Id == genreId).FirstOrDefault();
        }

        public ICollection<Book> GetAllBooksForGenre(int genreId)
        {
            return _genreContext.BooksGenres.Where(g => g.GenreId == genreId).Select(b => b.Book).ToList();
        }

        public ICollection<Genre> GetAllGenresForABook(int bookId)
        {
            return _genreContext.BooksGenres.Where(b => b.BookId == bookId).Select(g => g.Genre).ToList();
        }

        public bool GenreExists(int genreId)
        {
            return _genreContext.Genres.Any(g => g.Id == genreId);
        }

        public bool IsDuplicateGenreName(int genreId, string genreName)
        {
            var genre = _genreContext.Genres.Where(g => g.GenreName.Trim().ToUpper() == genreName.Trim().ToUpper() && g.Id != genreId).FirstOrDefault();

            return genre == null ? false : true;
        }

        public bool CreateGenre(Genre genre)
        {
            _genreContext.Add(genre);
            return Save();
        }

        public bool UpdateGenre(Genre genre)
        {
            _genreContext.Update(genre);
            return Save();
        }

        public bool DeleteGenre(Genre genre)
        {
            _genreContext.Remove(genre);
            return Save();
        }

        public bool Save()
        {
            var saved = _genreContext.SaveChanges();
            return saved >= 0 ? true : false;
        }
    }
}
