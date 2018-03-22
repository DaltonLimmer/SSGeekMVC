using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSGeek.Models;
using System.Data.SqlClient;

namespace SSGeek.DAL
{
    public class ForumPostSqlDAL : IForumPostDAL
    {
        private string _connectionString;

        public ForumPostSqlDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<ForumPost> GetAllPosts()
        {
            List<ForumPost> posts = new List<ForumPost>();
            string SQL_GetAllPosts = @"Select * from forum_post order by id desc";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(SQL_GetAllPosts, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ForumPost fp = new ForumPost()
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Username = Convert.ToString(reader["username"]),
                        Subject = Convert.ToString(reader["subject"]),
                        Message = Convert.ToString(reader["message"]),
                        PostDate = Convert.ToDateTime(reader["post_date"])
                    };

                    posts.Add(fp);
                }
            }

            return posts;
        }

        public bool SaveNewPost(ForumPost post)
        {
            bool isSuccessful = true;
            string SQL_SaveNewPost = @"Insert into forum_post (username, subject, message) 
            values (@username, @subject, @message); Select Cast(Scope_identity() as int);";
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_SaveNewPost, conn);

                    cmd.Parameters.Add(new SqlParameter("@username", post.Username));
                    cmd.Parameters.Add(new SqlParameter("@subject", post.Subject));
                    cmd.Parameters.Add(new SqlParameter("@message", post.Message));
                    int newId = (int)cmd.ExecuteScalar();
                }
            }

            catch(SqlException e)
            {
                Console.WriteLine(e.Message);
                isSuccessful = false;
            }
                return isSuccessful;
        }
    }
}