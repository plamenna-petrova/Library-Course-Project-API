using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.DataConnection;
using Data.DataConnection.Repositories.Implementations;
using Data.DataConnection.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LibraryAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
   
            services.AddControllers();

            services.AddScoped<ApplicationDbContext>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookImageRepository, BookImageRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IFineRepository, FineRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<ILibrarianRepository, LibrarianRepository>();
            services.AddScoped<ILibraryManagingDirectorRepository, LibraryManagingDirectorRepository>();
            services.AddScoped<ILoanRepository, LoanRepository>();
            services.AddScoped<IPublisherRepository, PublisherRepository>();
            services.AddScoped<IReaderRepository, ReaderRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
