﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShop.Data;
using MovieShop.Entities;

namespace MovieShop.Service
{
    public class MovieTestService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        public MovieTestService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public Movie GetMovieDetails(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetMoviesByGenre(int genreId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetTopGrossingMovies()
        {
            return _movieRepository.GetTopGrossingMovies();
        }
    }
}
