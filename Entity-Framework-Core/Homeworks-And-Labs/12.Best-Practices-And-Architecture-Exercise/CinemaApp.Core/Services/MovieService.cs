using CinemaApp.Core.Contracts;
using CinemaApp.Infrastructure.Data.Common;
using CinemaApp.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Core.Services
{
    public class MovieService : IMovieService
    {
        private readonly IRepository repostiory;

        public MovieService(IRepository repostiory)
        {
            this.repostiory = repostiory;
        }

        public IList<Movie> GetAllMovies()
        {
            return this.repostiory.All<Movie>().ToList();
        }

        public IQueryable<Movie> GetAllMovies(Func<Movie, bool> predicate)
        {
            return this.repostiory.All<Movie>()
                .Where(predicate).AsQueryable();
        }

        public IQueryable<Movie> GetAllMoviesPaged(int pageNumber, int pageSize)
        {
            if (pageNumber < 1)
            {
                throw new ArgumentException(nameof(pageNumber));
            }

            if (pageSize < 1)
            {
                throw new ArgumentException(nameof(pageSize));
            }

            return this.repostiory.All<Movie>()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
        }
    }
}
