using AutoMapper;
using Data.DataConnection;
using Data.Services.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private IAuthorRepository _authorRepository;
        private IBookRepository _bookRepository;
        private IBookImageRepository _bookImageRepository;
        private ICountryRepository _countryRepository;
        private IFineRepository _fineRepository;
        private IGenreRepository _genreRepository;
        private ILibrarianRepository _librarianRepository;
        private ILibraryManagingDirectorRepository _libraryManagingDirectorRepository;
        private ILoanRepository _loanRepository;
        private IPublisherRepository _publisherRepository;
        private IReaderRepository _readerRepository;
        private IReviewRepository _reviewRepository;
        private IReviewerRepository _reviewerRepository;
        private readonly ApplicationDbContext _applicationDbContext;

        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IAuthorRepository AuthorRepository
        {
            get
            {
                if (_authorRepository == null)
                {
                    _authorRepository = new AuthorRepository(_applicationDbContext);
                }
                return _authorRepository;
            }
        }

        public IBookRepository BookRepository
        {
            get
            {
                if (_bookRepository == null)
                {
                    _bookRepository = new BookRepository(_applicationDbContext);
                }
                return _bookRepository;
            }
        }

        public IBookImageRepository BookImageRepository
        {
            get
            {
                if (_bookImageRepository == null)
                {
                    _bookImageRepository = new BookImageRepository(_applicationDbContext);
                }
                return _bookImageRepository;
            }
        }

        public ICountryRepository CountryRepository
        {
            get
            {
                if (_countryRepository == null)
                {
                    _countryRepository = new CountryRepository(_applicationDbContext);
                }
                return _countryRepository;
            }
        }

        public IFineRepository FineRepository
        {
            get
            {
                if (_fineRepository == null)
                {
                    _fineRepository = new FineRepository(_applicationDbContext);
                }
                return _fineRepository;
            }
        }

        public IGenreRepository GenreRepository
        {
            get
            {
                if (_genreRepository == null)
                {
                    _genreRepository = new GenreRepository(_applicationDbContext);
                }
                return _genreRepository;
            }
        }

        public ILibrarianRepository LibrarianRepository
        {
            get
            {
                if (_librarianRepository == null)
                {
                    _librarianRepository = new LibrarianRepository(_applicationDbContext);
                }
                return _librarianRepository;
            }

        }

        public ILibraryManagingDirectorRepository LibraryManagingDirectorRepository
        {
            get
            {
                if (_libraryManagingDirectorRepository == null)
                {
                    _libraryManagingDirectorRepository = new LibraryManagingDirectorRepository(_applicationDbContext);
                }
                return _libraryManagingDirectorRepository;
            }
        }

        public ILoanRepository LoanRepository
        {
            get
            {
                if (_loanRepository == null)
                {
                    _loanRepository = new LoanRepository(_applicationDbContext);
                }
                return _loanRepository;
            }
        }

        public IPublisherRepository PublisherRepository
        {
            get
            {
                if (_publisherRepository == null)
                {
                    _publisherRepository = new PublisherRepository(_applicationDbContext);
                }
                return _publisherRepository;
            }
        }

        public IReaderRepository ReaderRepository
        {
            get
            {
                if (_readerRepository == null)
                {
                    _readerRepository = new ReaderRepository(_applicationDbContext);
                }
                return _readerRepository;
            }
        }

        public IReviewRepository ReviewRepository
        {
            get
            {
                if (_reviewRepository == null)
                {
                    _reviewRepository = new ReviewRepository(_applicationDbContext);
                }
                return _reviewRepository;
            }
        }

        public IReviewerRepository ReviewerRepository
        {
            get
            {
                if (_reviewerRepository == null)
                {
                    _reviewerRepository = new ReviewerRepository(_applicationDbContext);
                }
                return _reviewerRepository;
            }
        }

        public void Commit()
        {
            _applicationDbContext.SaveChanges();
        }
    }
}
