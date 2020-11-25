using Data.Models.Interfaces;
using Data.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data.DataConnection
{
    public class ApplicationDbContext : DbContext
    {
        private IConfigurationRoot configurationRoot;

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookImage> BookImages { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Fine> Fines { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Librarian> Librarians { get; set; }
        public virtual DbSet<LibraryManagingDirector> LibraryManagingDirectors { get; set; }
        public virtual DbSet<Loan> Loans { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Reader> Readers { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Reviewer> Reviewers { get; set; }
        public virtual DbSet<AuthorPublisher> AuthorsPublishers { get; set; }
        public virtual DbSet<BookAuthor> BooksAuthors { get; set; }
        public virtual DbSet<BookGenre> BooksGenres { get; set; }
        public virtual DbSet<BookReviewer> BooksReviewers { get; set; }
        public virtual DbSet<LibrarianBook> LibrariansBooks { get; set; }
        public virtual DbSet<ReaderBook> ReadersBooks { get; set; }
        public virtual DbSet<ReaderLibrarian> ReadersLibrarians { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            configurationRoot = new ConfigurationBuilder().SetBasePath(Path.Combine(@"C:\Users\Plamenna Petrova\AppData\Roaming\Microsoft\UserSecrets\a43cfe22-e250-4be4-98a5-662b66e4b74b")).AddJsonFile("secrets.json").Build();
            dbContextOptionsBuilder.UseSqlServer(configurationRoot.GetSection("DefaultConnection:ConnectionString").Value);

            //dbContextOptionsBuilder.UseSqlServer("Server=.;Database=Library;Trusted_Connection=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //method Seed(ModelBuilder modelBuilder)

            modelBuilder.Entity<Book>()
                        .HasOne<BookImage>(bi => bi.BookImage)
                        .WithOne(b => b.Book)
                        .HasForeignKey<BookImage>(bi => bi.BookId);

            modelBuilder.Entity<BookImage>()
                        .HasOne<Book>(b => b.Book)
                        .WithOne(bi => bi.BookImage)
                        .HasForeignKey<BookImage>(bi => bi.BookId);

            modelBuilder.Entity<AuthorPublisher>()
                        .HasKey(ap => new { ap.AuthorId, ap.PublisherId });
            modelBuilder.Entity<AuthorPublisher>()
                        .HasOne(a => a.Author)
                        .WithMany(ap => ap.AuthorsPublishers)
                        .HasForeignKey(a => a.AuthorId);
            modelBuilder.Entity<AuthorPublisher>()
                        .HasOne(p => p.Publisher)
                        .WithMany(ap => ap.AuthorsPublishers)
                        .HasForeignKey(p => p.PublisherId);

            modelBuilder.Entity<BookAuthor>()
                        .HasKey(ba => new { ba.BookId, ba.AuthorId });
            modelBuilder.Entity<BookAuthor>()
                        .HasOne(a => a.Author)
                        .WithMany(ba => ba.BooksAuthors)
                        .HasForeignKey(a => a.AuthorId);
            modelBuilder.Entity<BookAuthor>()
                        .HasOne(b => b.Book)
                        .WithMany(ba => ba.BooksAuthors)
                        .HasForeignKey(b => b.BookId);

            modelBuilder.Entity<BookGenre>()
                        .HasKey(bg => new { bg.BookId, bg.GenreId });
            modelBuilder.Entity<BookGenre>()
                        .HasOne(b => b.Book)
                        .WithMany(bg => bg.BooksGenres)
                        .HasForeignKey(b => b.BookId);
            modelBuilder.Entity<BookGenre>()
                        .HasOne(g => g.Genre)
                        .WithMany(bg => bg.BooksGenres)
                        .HasForeignKey(g => g.GenreId);

            modelBuilder.Entity<BookReviewer>()
                       .HasKey(br => new { br.BookId, br.ReviewerId });
            modelBuilder.Entity<BookReviewer>()
                       .HasOne(b => b.Book)
                       .WithMany(br => br.BooksReviewers)
                       .HasForeignKey(b => b.BookId);
            modelBuilder.Entity<BookReviewer>()
                       .HasOne(r => r.Reviewer)
                       .WithMany(br => br.BooksReviewers)
                       .HasForeignKey(r => r.ReviewerId);

            modelBuilder.Entity<LibrarianBook>()
                       .HasKey(lb => new { lb.LibrarianId, lb.BookId });
            modelBuilder.Entity<LibrarianBook>()
                       .HasOne(l => l.Librarian)
                       .WithMany(lb => lb.LibrariansBooks)
                       .HasForeignKey(l => l.LibrarianId);
            modelBuilder.Entity<LibrarianBook>()
                       .HasOne(b => b.Book)
                       .WithMany(lb => lb.LibrariansBooks)
                       .HasForeignKey(b => b.BookId);

            modelBuilder.Entity<ReaderBook>()
                       .HasKey(rb => new { rb.ReaderId, rb.BookId });
            modelBuilder.Entity<ReaderBook>()
                       .HasOne(r => r.Reader)
                       .WithMany(rb => rb.ReadersBooks)
                       .HasForeignKey(r => r.ReaderId);
            modelBuilder.Entity<ReaderBook>()
                       .HasOne(b => b.Book)
                       .WithMany(rb => rb.ReadersBooks)
                       .HasForeignKey(b => b.BookId);

            modelBuilder.Entity<ReaderLibrarian>()
                      .HasKey(rl => new { rl.ReaderId, rl.LibrarianId });
            modelBuilder.Entity<ReaderLibrarian>()
                      .HasOne(r => r.Reader)
                      .WithMany(rl => rl.ReadersLibrarians)
                      .HasForeignKey(r => r.ReaderId);
            modelBuilder.Entity<ReaderLibrarian>()
                      .HasOne(l => l.Librarian)
                      .WithMany(rl => rl.ReadersLibrarians)
                      .HasForeignKey(l => l.LibrarianId);

            //modelBuilder.Entity<Author>()
            //           .HasOne<Country>(c => c.Country)
            //           .WithMany(a => a.Authors)
            //           .HasForeignKey(a => a.CountryId);

            //modelBuilder.Entity<Publisher>()
            //           .HasOne<Country>(c => c.Country)
            //           .WithMany(p => p.Publishers)
            //           .HasForeignKey(p => p.CountryId);

            //seed OnModelCreating parameter

            //Data Seeds

            List<Book> books = new List<Book>()
            {
               new Book()
               {
                   Id = 1,
                   ISBN = "978-3-16-148410-0",
                   BookTitle = "The Queen's Gambit",
                   BookEdition = "third",
                   DatePublished = new DateTime(1983, 3, 10),
                   BookPages = 243,
                   BookAnnotation = "A story about an young chess player Beth Harmon and her struggles with defining herself in the chess world",
                   CreatedAt = new DateTime(2020, 11, 22)
               },
               new Book()
               {
                   Id = 2,
                   ISBN = "1004-3-16-148410-0",
                   BookTitle = "The Castle",
                   BookEdition = "first",
                   DatePublished = new DateTime(1926, 5, 9),
                   BookPages = 302,
                   BookAnnotation = "Kafka's unsurmounted masterpiece!",
                   CreatedAt = new DateTime(2020, 11, 22)
               },
               new Book()
               {
                   Id = 3,
                   ISBN = "834-3-16-148410-0",
                   BookTitle = "The Amazing Adventures of Kavalier and Clay",
                   BookEdition = "second",
                   DatePublished = new DateTime(2000, 4, 3),
                   BookPages = 705,
                   BookAnnotation = "Michael Chabon's Pulitzer winning work!",
                   CreatedAt = new DateTime(2020, 11, 22)
               },
            };


            List<BookAuthor> booksAuthors = new List<BookAuthor>()
            {
                new BookAuthor()
                {
                    BookId = 1,
                    AuthorId = 1,
                },
                new BookAuthor()
                {
                    BookId = 2,
                    AuthorId = 2,
                },
                new BookAuthor()
                {
                    BookId = 3,
                    AuthorId = 3,
                }
            };

            List<Country> countries = new List<Country>()
            {
                new Country()
                {
                    Id = 1,
                    CountryName = "USA",
                    CreatedAt = new DateTime(2020, 11, 22)
                },
                new Country()
                {
                    Id = 2,
                    CountryName = "Czech Republic",
                    CreatedAt = new DateTime(2020, 11, 22)
                },
                new Country()
                {
                    Id = 3,
                    CountryName = "Germany",
                    CreatedAt = new DateTime(2020, 11, 22)
                }
            };


            List<Author> authors = new List<Author>()
            {
                new Author()
                {
                    Id = 1,
                    AuthorFirstName = "Walter",
                    AuthorLastName = "Tevis",
                    AuthorBiography = "Born in the USA...",
                    CountryId = countries[0].Id,
                    //CountryId = 1,
                    CreatedAt = new DateTime(2020, 11, 22)
                },
                new Author()
                {
                    Id = 2,
                    AuthorFirstName = "Franz",
                    AuthorLastName = "Kafka",
                    AuthorBiography = "Born in Prague, Czech Republic",
                    CountryId = countries[1].Id,
                    //CountryId = 2,
                    CreatedAt = new DateTime(2020, 11, 22)
                },
                new Author()
                {
                    Id = 3,
                    AuthorFirstName = "Michael",
                    AuthorLastName = "Chabon",
                    AuthorBiography = "Modern American author",
                    CountryId = countries[0].Id,
                    //CountryId = 1,
                    CreatedAt = new DateTime(2020, 11, 22)
                }
            };


            List<Publisher> publishers = new List<Publisher>()
            {
                new Publisher()
                {
                    Id = 1,
                    PublisherName = "Verlagsgruppe Random House",
                    CountryId = countries[2].Id,
                    CreatedAt = new DateTime(2020, 11, 22)
                },
                new Publisher()
                {
                    Id = 2,
                    PublisherName = "Joella Goldman",
                    CountryId = countries[2].Id,
                    CreatedAt = new DateTime(2020, 11, 22)
                },
            };

            List<AuthorPublisher> authorsPublishers = new List<AuthorPublisher>(){
                new AuthorPublisher()
                {
                    AuthorId = 1,
                    PublisherId = 1
                },
                new AuthorPublisher()
                {
                    AuthorId = 2,
                    PublisherId = 2
                },
                new AuthorPublisher()
                {
                    AuthorId = 3,
                    PublisherId = 1
                }
            };

            modelBuilder.Entity<Country>().HasData(countries);
            modelBuilder.Entity<Author>().HasData(authors);
            modelBuilder.Entity<Book>().HasData(books);
            modelBuilder.Entity<BookAuthor>().HasData(booksAuthors);
            modelBuilder.Entity<Publisher>().HasData(publishers);
            modelBuilder.Entity<AuthorPublisher>().HasData(authorsPublishers);
            base.OnModelCreating(modelBuilder);

        }

        private void ApplyChanges()
        {
            var entries = this.ChangeTracker.Entries().Where(x => x.Entity is IAuditInfo).ToList();

            foreach (var entry in entries)
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedAt = DateTime.UtcNow;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entity.ModifiedAt = DateTime.UtcNow;
                }
                else
                {
                    entity.DeletedAt = DateTime.UtcNow;
                }
            }
        }

        public override int SaveChanges()
        {
            return SaveChanges(true);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyChanges();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            this.ApplyChanges();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return SaveChangesAsync(cancellationToken);
        }
    }
}
