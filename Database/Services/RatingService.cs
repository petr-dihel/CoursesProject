using Database.Entities.Rating;
using Database.Mappers.Rating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Services
{
    public class RatingService
    {
        private RatingMapper ratingMapper;

        public RatingService()
        {
            this.ratingMapper = new RatingMapper();
        }

        public void Insert(RatingEntity entity)
        {
            this.ratingMapper.Insert(entity);
            this.CalculateAverageRating(entity.teacherId);
        }

        public void CalculateAverageRating(int teacherId)
        {
            this.ratingMapper.CalculateAverage(teacherId);
        }

    }
}
