﻿using CinemaApp.Core.Contracts;
using CinemaApp.Core.Models;
using CinemaApp.Infrastructure.Data.Common;
using CinemaApp.Infrastructure.Data.Models;
using System.Text.Json;

namespace CinemaApp.Core.Services
{
    public class CinemaService : ICinemaService
    {
        private readonly IRepository repo;

        public CinemaService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task AddCinemaAsync(CinemaModel model)
        {
            if (repo.AllReadonly<Cinema>().Any(c => c.Name == model.Name))
            {
                throw new ArgumentException("Cinema already exists");
            }

            Cinema cinema = new Cinema()
            {
                Address = model.Address,
                Name = model.Name
            };

            await repo.AddAsync(cinema);
            await repo.SaveChangesAsync();
        }

        public List<Cinema> GetAllCinemas()
        {
            return repo.All<Cinema>().ToList();
        }

        public async Task InsertAdditionalMovies(List<Movie> movies)
        {
            await repo.AddAsync(movies);
        }
    }
}
