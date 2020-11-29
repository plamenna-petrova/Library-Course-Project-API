using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IAuthorRepository AuthorRepository { get; }
        IBookRepository BookRepository { get; }
        IBookImageRepository BookImageRepository { get; }
        ICountryRepository CountryRepository { get; }
        IFineRepository FineRepository { get; }
        IGenreRepository GenreRepository { get; }
        ILibrarianRepository LibrarianRepository { get; }
        ILibraryManagingDirectorRepository LibraryManagingDirectorRepository { get; }
        ILoanRepository LoanRepository { get; }
        IPublisherRepository PublisherRepository { get; }
        IReaderRepository ReaderRepository { get; }
        IReviewRepository ReviewRepository { get; }
        IReviewerRepository ReviewerRepository { get; }
        void Commit();

    }
}