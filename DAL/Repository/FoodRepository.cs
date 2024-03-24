﻿using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace DAL.Repository
{
    public class FoodRepository
    {
        private string connectionString = "Data Source=.;Initial Catalog=QLCH;Integrated Security=True";
        public DataTable GetFoods()
        {
            DataTable foods = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("GetFoods", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(foods);
                    }
                }
            }

            return foods;
        }
        public bool DeleteFood(int foodID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("DeleteFood", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FoodID", foodID);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }
        public bool InsertFood(int foodId, string foodName, string unit, string price, int categoryId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("InsertFood", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FoodId", foodId);
                    command.Parameters.AddWithValue("@FoodName", foodName);
                    command.Parameters.AddWithValue("@Unit", unit);
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@CategoryId", categoryId);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
            }
        }
        public bool UpdateFood(int foodId, string newFoodName, string newUnit, string newPrice, int newCategoryId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("UpdateFood", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FoodId", foodId);
                    command.Parameters.AddWithValue("@FoodName", newFoodName);
                    command.Parameters.AddWithValue("@Unit", newUnit);
                    command.Parameters.AddWithValue("@Price", newPrice);
                    command.Parameters.AddWithValue("@CategoryId", newCategoryId);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
            }
        }
    }
}