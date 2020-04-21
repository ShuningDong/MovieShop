using MovieShop.Data;
using MovieShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Service
{
    public class CastService:ICastService
    {
        private readonly ICastRepository _castRepository;

        public CastService(ICastRepository castRepository)
        {
            _castRepository = castRepository;
        }

        public Cast GetCastDetails(int castId)
        {
            var cast = _castRepository.GetCastWithMovies(castId);
            return cast;
        }

        public void UpdateToCastTable(Cast cast)
        {
            _castRepository.Add(cast);
        }
    }
    public interface ICastService
    {
        Cast GetCastDetails(int castId);

        void UpdateToCastTable(Cast cast);
    }
}
