using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSGeek.Models;
using System.Data.SqlClient;

namespace SSGeek.DAL
{

    public class ProductSqlDAL : IProductDAL
    {

        private string _connectionString;
        public ProductSqlDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Product GetProduct(int id)
        {
            Product p = null;
            string SQL_GetProduct = @"select * from products where product_id = @id";


            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(SQL_GetProduct, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    p = new Product()
                    {
                        ProductId = Convert.ToInt32(reader["product_id"]),
                        Name = Convert.ToString(reader["name"]),
                        Description = Convert.ToString(reader["description"]),
                        Price = Convert.ToDouble(reader["price"]),
                        ImageName = Convert.ToString(reader["image_name"])
                    };

                }
            }
            return p;
        }
       
        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            string SQL_GetAllProducts = @"Select * from products";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(SQL_GetAllProducts, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Product p = new Product()
                    {
                        ProductId = Convert.ToInt32(reader["product_id"]),
                        Name = Convert.ToString(reader["name"]),
                        Description = Convert.ToString(reader["description"]),
                        Price = Convert.ToDouble(reader["price"]),
                        ImageName = Convert.ToString(reader["image_name"])
                    };

                    products.Add(p);
                }
            }

            return products;
        }

		
    }
}