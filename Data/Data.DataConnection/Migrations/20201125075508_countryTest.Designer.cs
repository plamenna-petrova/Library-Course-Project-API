﻿// <auto-generated />
using System;
using Data.DataConnection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.DataConnection.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20201125075508_countryTest")]
    partial class countryTest
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Data.Models.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AuthorBiography")
                        .HasMaxLength(3000)
                        .HasColumnType("nvarchar(3000)");

                    b.Property<string>("AuthorFirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("AuthorLastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorBiography = "Born in the USA...",
                            AuthorFirstName = "Walter",
                            AuthorLastName = "Tevis",
                            CountryId = 1,
                            CreatedAt = new DateTime(2020, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            AuthorBiography = "Born in Prague, Czech Republic",
                            AuthorFirstName = "Franz",
                            AuthorLastName = "Kafka",
                            CountryId = 2,
                            CreatedAt = new DateTime(2020, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            AuthorBiography = "Modern American author",
                            AuthorFirstName = "Michael",
                            AuthorLastName = "Chabon",
                            CountryId = 1,
                            CreatedAt = new DateTime(2020, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Data.Models.Models.AuthorPublisher", b =>
                {
                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("PublisherId")
                        .HasColumnType("int");

                    b.HasKey("AuthorId", "PublisherId");

                    b.HasIndex("PublisherId");

                    b.ToTable("AuthorsPublishers");

                    b.HasData(
                        new
                        {
                            AuthorId = 1,
                            PublisherId = 1
                        },
                        new
                        {
                            AuthorId = 2,
                            PublisherId = 2
                        },
                        new
                        {
                            AuthorId = 3,
                            PublisherId = 1
                        });
                });

            modelBuilder.Entity("Data.Models.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("BookAnnotation")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("BookEdition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BookPages")
                        .HasColumnType("int");

                    b.Property<string>("BookTitle")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DatePublished")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PublisherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PublisherId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookAnnotation = "A story about an young chess player Beth Harmon and her struggles with defining herself in the chess world",
                            BookEdition = "third",
                            BookPages = 243,
                            BookTitle = "The Queen's Gambit",
                            CreatedAt = new DateTime(2020, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DatePublished = new DateTime(1983, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ISBN = "978-3-16-148410-0"
                        },
                        new
                        {
                            Id = 2,
                            BookAnnotation = "Kafka's unsurmounted masterpiece!",
                            BookEdition = "first",
                            BookPages = 302,
                            BookTitle = "The Castle",
                            CreatedAt = new DateTime(2020, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DatePublished = new DateTime(1926, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ISBN = "1004-3-16-148410-0"
                        },
                        new
                        {
                            Id = 3,
                            BookAnnotation = "Michael Chabon's Pulitzer winning work!",
                            BookEdition = "second",
                            BookPages = 705,
                            BookTitle = "The Amazing Adventures of Kavalier and Clay",
                            CreatedAt = new DateTime(2020, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DatePublished = new DateTime(2000, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ISBN = "834-3-16-148410-0"
                        });
                });

            modelBuilder.Entity("Data.Models.Models.BookAuthor", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.HasKey("BookId", "AuthorId");

                    b.HasIndex("AuthorId");

                    b.ToTable("BooksAuthors");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            AuthorId = 1
                        },
                        new
                        {
                            BookId = 2,
                            AuthorId = 2
                        },
                        new
                        {
                            BookId = 3,
                            AuthorId = 3
                        });
                });

            modelBuilder.Entity("Data.Models.Models.BookGenre", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.HasKey("BookId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("BooksGenres");
                });

            modelBuilder.Entity("Data.Models.Models.BookImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("BookImageShortDecsription")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("BookImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BookId")
                        .IsUnique();

                    b.ToTable("BookImages");
                });

            modelBuilder.Entity("Data.Models.Models.BookReviewer", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("ReviewerId")
                        .HasColumnType("int");

                    b.HasKey("BookId", "ReviewerId");

                    b.HasIndex("ReviewerId");

                    b.ToTable("BooksReviewers");
                });

            modelBuilder.Entity("Data.Models.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryName = "USA",
                            CreatedAt = new DateTime(2020, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            CountryName = "Czech Republic",
                            CreatedAt = new DateTime(2020, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            CountryName = "Germany",
                            CreatedAt = new DateTime(2020, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Data.Models.Models.Fine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FineDescription")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<decimal>("FineFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("LibrarianId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ReaderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LibrarianId");

                    b.HasIndex("ReaderId");

                    b.ToTable("Fines");
                });

            modelBuilder.Entity("Data.Models.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("GenreDescription")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("GenreName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("Data.Models.Models.Librarian", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("LibrarianFirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LibrarianLastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("LibraryManagingDirectorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("LibraryManagingDirectorId");

                    b.ToTable("Librarians");
                });

            modelBuilder.Entity("Data.Models.Models.LibrarianBook", b =>
                {
                    b.Property<int>("LibrarianId")
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.HasKey("LibrarianId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("LibrariansBooks");
                });

            modelBuilder.Entity("Data.Models.Models.LibraryManagingDirector", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("LibraryManagingDirectorFirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LibraryManagingDirectorLastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("WorkingExperienceInYears")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("LibraryManagingDirectors");
                });

            modelBuilder.Entity("Data.Models.Models.Loan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("BookId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateToReturn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActiveLoan")
                        .HasColumnType("bit");

                    b.Property<DateTime>("IssueDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LibrarianId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ReaderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("LibrarianId");

                    b.HasIndex("ReaderId");

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("Data.Models.Models.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("PublisherName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Publishers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryId = 3,
                            CreatedAt = new DateTime(2020, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PublisherName = "Verlagsgruppe Random House"
                        },
                        new
                        {
                            Id = 2,
                            CountryId = 3,
                            CreatedAt = new DateTime(2020, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PublisherName = "Joella Goldman"
                        });
                });

            modelBuilder.Entity("Data.Models.Models.Reader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("HasPayedTheLibraryFee")
                        .HasColumnType("bit");

                    b.Property<decimal>("LibraryFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReaderAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReaderAge")
                        .HasColumnType("int");

                    b.Property<string>("ReaderCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReaderContactNumber")
                        .HasColumnType("int");

                    b.Property<string>("ReaderEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReaderFirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ReaderLastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Readers");
                });

            modelBuilder.Entity("Data.Models.Models.ReaderBook", b =>
                {
                    b.Property<int>("ReaderId")
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.HasKey("ReaderId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("ReadersBooks");
                });

            modelBuilder.Entity("Data.Models.Models.ReaderLibrarian", b =>
                {
                    b.Property<int>("ReaderId")
                        .HasColumnType("int");

                    b.Property<int>("LibrarianId")
                        .HasColumnType("int");

                    b.HasKey("ReaderId", "LibrarianId");

                    b.HasIndex("LibrarianId");

                    b.ToTable("ReadersLibrarians");
                });

            modelBuilder.Entity("Data.Models.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("BookId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("HeadLine")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("ReviewText")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ReviewerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("ReviewerId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Data.Models.Models.Reviewer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReviewerFirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ReviewerLastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Reviewers");
                });

            modelBuilder.Entity("Data.Models.Models.Author", b =>
                {
                    b.HasOne("Data.Models.Models.Country", "Country")
                        .WithMany("Authors")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Data.Models.Models.AuthorPublisher", b =>
                {
                    b.HasOne("Data.Models.Models.Author", "Author")
                        .WithMany("AuthorsPublishers")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Models.Models.Publisher", "Publisher")
                        .WithMany("AuthorsPublishers")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("Data.Models.Models.Book", b =>
                {
                    b.HasOne("Data.Models.Models.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherId");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("Data.Models.Models.BookAuthor", b =>
                {
                    b.HasOne("Data.Models.Models.Author", "Author")
                        .WithMany("BooksAuthors")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Models.Models.Book", "Book")
                        .WithMany("BooksAuthors")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Data.Models.Models.BookGenre", b =>
                {
                    b.HasOne("Data.Models.Models.Book", "Book")
                        .WithMany("BooksGenres")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Models.Models.Genre", "Genre")
                        .WithMany("BooksGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("Data.Models.Models.BookImage", b =>
                {
                    b.HasOne("Data.Models.Models.Book", "Book")
                        .WithOne("BookImage")
                        .HasForeignKey("Data.Models.Models.BookImage", "BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Data.Models.Models.BookReviewer", b =>
                {
                    b.HasOne("Data.Models.Models.Book", "Book")
                        .WithMany("BooksReviewers")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Models.Models.Reviewer", "Reviewer")
                        .WithMany("BooksReviewers")
                        .HasForeignKey("ReviewerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Reviewer");
                });

            modelBuilder.Entity("Data.Models.Models.Fine", b =>
                {
                    b.HasOne("Data.Models.Models.Librarian", "Librarian")
                        .WithMany()
                        .HasForeignKey("LibrarianId");

                    b.HasOne("Data.Models.Models.Reader", "Reader")
                        .WithMany("Fines")
                        .HasForeignKey("ReaderId");

                    b.Navigation("Librarian");

                    b.Navigation("Reader");
                });

            modelBuilder.Entity("Data.Models.Models.Librarian", b =>
                {
                    b.HasOne("Data.Models.Models.LibraryManagingDirector", "LibraryManagingDirector")
                        .WithMany("Librarians")
                        .HasForeignKey("LibraryManagingDirectorId");

                    b.Navigation("LibraryManagingDirector");
                });

            modelBuilder.Entity("Data.Models.Models.LibrarianBook", b =>
                {
                    b.HasOne("Data.Models.Models.Book", "Book")
                        .WithMany("LibrariansBooks")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Models.Models.Librarian", "Librarian")
                        .WithMany("LibrariansBooks")
                        .HasForeignKey("LibrarianId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Librarian");
                });

            modelBuilder.Entity("Data.Models.Models.Loan", b =>
                {
                    b.HasOne("Data.Models.Models.Book", "Book")
                        .WithMany("Loans")
                        .HasForeignKey("BookId");

                    b.HasOne("Data.Models.Models.Librarian", "Librarian")
                        .WithMany("Loans")
                        .HasForeignKey("LibrarianId");

                    b.HasOne("Data.Models.Models.Reader", "Reader")
                        .WithMany("Loans")
                        .HasForeignKey("ReaderId");

                    b.Navigation("Book");

                    b.Navigation("Librarian");

                    b.Navigation("Reader");
                });

            modelBuilder.Entity("Data.Models.Models.Publisher", b =>
                {
                    b.HasOne("Data.Models.Models.Country", "Country")
                        .WithMany("Publishers")
                        .HasForeignKey("CountryId");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Data.Models.Models.ReaderBook", b =>
                {
                    b.HasOne("Data.Models.Models.Book", "Book")
                        .WithMany("ReadersBooks")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Models.Models.Reader", "Reader")
                        .WithMany("ReadersBooks")
                        .HasForeignKey("ReaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Reader");
                });

            modelBuilder.Entity("Data.Models.Models.ReaderLibrarian", b =>
                {
                    b.HasOne("Data.Models.Models.Librarian", "Librarian")
                        .WithMany("ReadersLibrarians")
                        .HasForeignKey("LibrarianId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Models.Models.Reader", "Reader")
                        .WithMany("ReadersLibrarians")
                        .HasForeignKey("ReaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Librarian");

                    b.Navigation("Reader");
                });

            modelBuilder.Entity("Data.Models.Models.Review", b =>
                {
                    b.HasOne("Data.Models.Models.Book", "Book")
                        .WithMany("Reviews")
                        .HasForeignKey("BookId");

                    b.HasOne("Data.Models.Models.Reviewer", "Reviewer")
                        .WithMany("Reviews")
                        .HasForeignKey("ReviewerId");

                    b.Navigation("Book");

                    b.Navigation("Reviewer");
                });

            modelBuilder.Entity("Data.Models.Models.Reviewer", b =>
                {
                    b.HasOne("Data.Models.Models.Country", "Country")
                        .WithMany("Reviewers")
                        .HasForeignKey("CountryId");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Data.Models.Models.Author", b =>
                {
                    b.Navigation("AuthorsPublishers");

                    b.Navigation("BooksAuthors");
                });

            modelBuilder.Entity("Data.Models.Models.Book", b =>
                {
                    b.Navigation("BookImage");

                    b.Navigation("BooksAuthors");

                    b.Navigation("BooksGenres");

                    b.Navigation("BooksReviewers");

                    b.Navigation("LibrariansBooks");

                    b.Navigation("Loans");

                    b.Navigation("ReadersBooks");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("Data.Models.Models.Country", b =>
                {
                    b.Navigation("Authors");

                    b.Navigation("Publishers");

                    b.Navigation("Reviewers");
                });

            modelBuilder.Entity("Data.Models.Models.Genre", b =>
                {
                    b.Navigation("BooksGenres");
                });

            modelBuilder.Entity("Data.Models.Models.Librarian", b =>
                {
                    b.Navigation("LibrariansBooks");

                    b.Navigation("Loans");

                    b.Navigation("ReadersLibrarians");
                });

            modelBuilder.Entity("Data.Models.Models.LibraryManagingDirector", b =>
                {
                    b.Navigation("Librarians");
                });

            modelBuilder.Entity("Data.Models.Models.Publisher", b =>
                {
                    b.Navigation("AuthorsPublishers");

                    b.Navigation("Books");
                });

            modelBuilder.Entity("Data.Models.Models.Reader", b =>
                {
                    b.Navigation("Fines");

                    b.Navigation("Loans");

                    b.Navigation("ReadersBooks");

                    b.Navigation("ReadersLibrarians");
                });

            modelBuilder.Entity("Data.Models.Models.Reviewer", b =>
                {
                    b.Navigation("BooksReviewers");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
