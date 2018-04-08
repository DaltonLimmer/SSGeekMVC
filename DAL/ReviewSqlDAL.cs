using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FormsWithHttpPost.Models;
using System.Data.SqlClient;

namespace FormsWithHttpPost.DAL
{
    public class ReviewSqlDAL : IReviewDAL
    {
        private string _connectionString;

        public ReviewSqlDAL(string connectionString)
        {
            _connectionString = connectionString;
        }


        public List<Review> GetAllReviews()
        {
            List<Review> reviews = new List<Review>();
            string SQL_GetAllPosts = @"Select * from reviews order by review_date desc";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(SQL_GetAllPosts, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Review r = new Review()
                    {
                        Id = Convert.ToInt32(reader["review_id"]),
                        Username = Convert.ToString(reader["username"]),
                        Rating = Convert.ToInt32(reader["rating"]),
                        Title = Convert.ToString(reader["review_title"]),
                        Message = Convert.ToString(reader["review_text"]),
                        ReviewDate = Convert.ToDateTime(reader["review_date"])
                    };

                    reviews.Add(r);
                }
            }

            return reviews;
        }

        public bool SaveReview(Review newReview)
        {
            bool isSuccessful = true;
            string SQL_SaveNewReview = @"Insert into reviews (username, rating, review_title, review_text) 
            values (@username, @rating, @title, @message); Select Cast(Scope_identity() as int);";
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {


                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_SaveNewReview, conn);

                    cmd.Parameters.Add(new SqlParameter("@username", newReview.Username));
                    cmd.Parameters.Add(new SqlParameter("@rating", newReview.Rating));
                    cmd.Parameters.Add(new SqlParameter("@title", newReview.Title));
                    cmd.Parameters.Add(new SqlParameter("@message", newReview.Message));
                    int newId = (int)cmd.ExecuteScalar();
                }
            }

            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                isSuccessful = false;
            }
            return isSuccessful;
        }
    }
    
}