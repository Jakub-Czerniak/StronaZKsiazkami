using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.DataAccess;
using DataLibrary.Models;

namespace DataLibrary.BusinessLogic
{
    public class ReviewProcessor
    {
        public static int CreateReview(string text_review, int rating, string username, int book_id)
        {
            ReviewModel data = new ReviewModel
            {
                TextReview = text_review,
                Rating = rating,
                Username = username,
                BookId  = book_id
                
            };

            string sql = @"EXECUTE  PlaceReview @BookId, @Rating, @TextReview, @Username";

            return SqlDataAccess.SaveData(sql, data);
        }
        public static List<ReviewModel> LoadReview(int id)
        {
            ReviewModel data = new ReviewModel
            {
                Id = id
            };
            string sql = @"EXECUTE FindReviewById @Id";

            return SqlDataAccess.LoadData<ReviewModel>(sql, data);
        }
        public static List<ReviewModel> LoadReviewsByBookId(int id)
        {
            ReviewModel data = new ReviewModel
            {
                BookId = id
            };
            string sql = @"EXECUTE FindReviewById @Id";

            return SqlDataAccess.LoadData<ReviewModel>(sql, data);
        }
    }
}
