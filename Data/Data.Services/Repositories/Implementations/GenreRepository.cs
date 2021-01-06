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
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDbContext _genreContext;

        public GenreRepository(ApplicationDbContext genreContext)
        {
            _genreContext = genreContext;
        }

        public ICollection<GenreDto> GetGenres()
        {
            var genres = _genreContext.Genres.OrderBy(g => g.GenreName).ToList();
            var mappedGenres = MapConfig.Mapper.Map<ICollection<GenreDto>>(genres);
            return mappedGenres;
        }

        public GenreDto GetGenreById(int genreId)
        {
            var singleGenre = _genreContext.Genres.Where(g => g.Id == genreId).FirstOrDefault();
            var mappedGenre = MapConfig.Mapper.Map<GenreDto>(singleGenre);
            return mappedGenre;
        }

        public Genre GetGenreByIdNotMapped(int genreId)
        {
            var genre = _genreContext.Genres.Where(g => g.Id == genreId).FirstOrDefault();
            return genre;
        }

        public ICollection<BookDto> GetAllBooksForGenre(int genreId)
        {
            var booksForGenre = _genreContext.BooksGenres.Where(g => g.GenreId == genreId).Select(b => b.Book).ToList();
            var booksForGenreMapped = MapConfig.Mapper.Map<ICollection<BookDto>>(booksForGenre);
            return booksForGenreMapped;
        }

        public ICollection<GenreDto> GetAllGenresForABook(int bookId)
        {
            var genresForABook = _genreContext.BooksGenres.Where(b => b.BookId == bookId).Select(g => g.Genre).ToList();
            var genresForABookMapped = MapConfig.Mapper.Map<ICollection<GenreDto>>(genresForABook);
            return genresForABookMapped;
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

        public bool CreateGenre(GenreCreateDto genreToCreateDto)
        {
            var genreToCreate = MapConfig.Mapper.Map<Genre>(genreToCreateDto);
            _genreContext.Add(genreToCreate);
            return Save();
        }

        public bool UpdateGenre(GenreUpdateDto genreToUpdateDto)
        {
            var genreToUpdate = MapConfig.Mapper.Map<Genre>(genreToUpdateDto);
            _genreContext.Update(genreToUpdate);
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
