using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieShop.Data;
using MovieShop.Entities;
using MovieShop.Service;
using System.Linq;
using Moq;

namespace MovieShop.UnitTests
{
    [TestClass]
    public class MovieServiceUnitTest
    {
        // System Under Test
        private MovieService _sut;
        private List<Movie> _fakeMovies;
        private readonly Mock<IMovieRepository> _mockMovieRepository;

        public MovieServiceUnitTest()
        {
            _mockMovieRepository = new Mock<IMovieRepository>();
            _sut = new MovieService(_mockMovieRepository.Object);
        }

        [TestInitialize]
        // Trigerred before every test case
        public void TestInitialize()
        {
            _fakeMovies = new List<Movie> {
                new Movie
                          {
                              id = 1,
                              title = "TestMovie1",
                              Budget = 2900000,
                          },
                          new Movie
                          {
                              id = 2,
                              title = "TestMovie2",
                              Budget = 550000,
                          },
                          new Movie
                          {
                              id = 3,
                              title = "TestMovie3",
                              Budget = 7800000,
                          },
                          new Movie
                          {
                              id = 4,
                              title = "TestMovie4",
                              Budget = 60800000,
                          },
                          new Movie
                          {
                              id = 5,
                              title = "TestMovie5",
                              Budget = 4567000,
                          }

            };

            // using Moq we are going to setup mock methods for IMovieRepository
            _mockMovieRepository.Setup(m => m.GetTopGrossingMovies()).Returns(_fakeMovies);
            _mockMovieRepository.Setup(m => m.GetById(It.IsAny<int>()))
                .Returns((int id) => _fakeMovies.FirstOrDefault(x => x.id == id));

        }

        [TestMethod]
        public void Test_For_TopGrossingMovies_From_FakeData()
        {

            // Act
            var topMovies = _sut.GetTopGrossingMovies();

            // Assert
            // you can do multiple asserts in one unit test method
            
            // checking topMovies is not null
            Assert.IsNotNull(topMovies);

            // check totalnumber of movies equal to 5
            Assert.AreEqual(5, topMovies.Count());

            // Check the returned type
            CollectionAssert.AllItemsAreInstancesOfType(topMovies.ToList(), typeof(Movie));
        }


        // new Unit Test method for Testing GetMovieDetails method in Movie Service
        //  Movie GetMovieDetails(int id);
        // Assert, check movie name, id, type, is not null
        [TestMethod]
        public void Test_For_GetMovieDetails_From_FakeData()
        {
            //act
            var movie = _sut.GetMovieDetails(1);

            //assert
            Assert.IsNotNull(movie.title);
            Assert.IsNotNull(movie.id);
            //var genres = movie.Genres;
            //Assert.IsNotNull(genres);

        }
    }


    //public class FakeMovieRepository : IMovieRepository
    //{
    //    private List<Movie> _fakeMovies;
    //    public void Add(Movie entity)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Delete(Movie entity)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Delete(Expression<Func<Movie, bool>> where)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Movie Get(Expression<Func<Movie, bool>> where)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IEnumerable<Movie> GetAll()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Movie GetById(int id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IEnumerable<Movie> GetMany(Expression<Func<Movie, bool>> where)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IEnumerable<Movie> GetMoviesByGenre(int genreId)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IEnumerable<Movie> GetTopGrossingMovies()
    //    {
    //        // Instead of using Database we need to return fake movies from memory
    //        _fakeMovies = new List<Movie> {
    //            new Movie
    //                      {
    //                          id = 1,
    //                          title = "TestMovie1",
    //                          Budget = 2900000,
    //                      },
    //                      new Movie
    //                      {
    //                          id = 2,
    //                          title = "TestMovie2",
    //                          Budget = 550000,
    //                      },
    //                      new Movie
    //                      {
    //                          id = 3,
    //                          title = "TestMovie3",
    //                          Budget = 7800000,
    //                      },
    //                      new Movie
    //                      {
    //                          id = 4,
    //                          title = "TestMovie4",
    //                          Budget = 60800000,
    //                      },
    //                      new Movie
    //                      {
    //                          id = 5,
    //                          title = "TestMovie5",
    //                          Budget = 4567000,
    //                      }

    //        };
    //        return _fakeMovies;
    //    }

    //    public void Update(Movie entity)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
