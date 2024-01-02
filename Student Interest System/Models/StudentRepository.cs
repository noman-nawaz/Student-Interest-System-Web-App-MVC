using System.Data.SqlClient;
using System.Data;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;

namespace Student_Interest_System_Mvc.Models
{
    public class StudentRepository
    {
        private readonly string connectionString;

        public StudentRepository()
        {
            this.connectionString = connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StudentDB;Integrated Security=True;Connect Timeout=30;Encrypt=False";
           
        }

        public void AddStudent(Student student)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT INTO Students (FullName, RollNumber, EmailAddress, Gender, DateOfBirth, City, Interest, Department, DegreeTitle, Subject, StartDate, EndDate) " +
                                          "VALUES (@FullName, @RollNumber, @EmailAddress, @Gender, @DateOfBirth, @City, @Interest, @Department, @DegreeTitle, @Subject, @StartDate, @EndDate)";

                    // Add parameters
                    command.Parameters.AddWithValue("@FullName", student.FullName);
                    command.Parameters.AddWithValue("@RollNumber", student.RollNumber);
                    command.Parameters.AddWithValue("@EmailAddress", student.EmailAddress);
                    command.Parameters.AddWithValue("@Gender", student.Gender);
                    command.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth);
                    command.Parameters.AddWithValue("@City", student.City);
                    command.Parameters.AddWithValue("@Interest", student.Interest);
                    command.Parameters.AddWithValue("@Department", student.Department);
                    command.Parameters.AddWithValue("@DegreeTitle", student.DegreeTitle);
                    command.Parameters.AddWithValue("@Subject", student.Subject);
                    command.Parameters.AddWithValue("@StartDate", student.StartDate);
                    command.Parameters.AddWithValue("@EndDate", student.EndDate);

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<string> GetInterestsFromDatabase()
        {
            List<string> interests = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT DISTINCT Interest FROM Students";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string interest = reader["Interest"].ToString();
                            interests.Add(interest);
                        }
                    }
                }
            }

            return interests;
        }



    }
}
