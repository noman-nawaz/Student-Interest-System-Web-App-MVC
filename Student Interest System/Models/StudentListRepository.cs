using System.Data.SqlClient;
using System.Data;

namespace Student_Interest_System_Mvc.Models
{
    public class StudentListRepository
    {

        private readonly string connectionString;
        private List<Student> studentList {  get; set; }

        public StudentListRepository()
        {
            this.connectionString = connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StudentDB;Integrated Security=True;Connect Timeout=30;Encrypt=False";
            studentList = new List<Student>();

        }

        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * FROM Students";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Student student = new Student
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                FullName = reader["FullName"].ToString(),
                                RollNumber = reader["RollNumber"].ToString(),
                                EmailAddress = reader["EmailAddress"].ToString(),
                                Gender = reader["Gender"].ToString(),
                                DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                                City = reader["City"].ToString(),
                                Interest = reader["Interest"].ToString(),
                                Department = reader["Department"].ToString(),
                                DegreeTitle = reader["DegreeTitle"].ToString(),
                                Subject = reader["Subject"].ToString(),
                                StartDate = Convert.ToDateTime(reader["StartDate"]),
                                EndDate = Convert.ToDateTime(reader["EndDate"])
                            };

                            students.Add(student);
                        }
                    }
                }
            }

            studentList = students;
            return students;
        }

        public Student GetStudentById(int studentId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * FROM Students WHERE Id = @StudentId";
                    command.Parameters.AddWithValue("@StudentId", studentId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Student student = new Student
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                FullName = reader["FullName"].ToString(),
                                RollNumber = reader["RollNumber"].ToString(),
                                EmailAddress = reader["EmailAddress"].ToString(),
                                Gender = reader["Gender"].ToString(),
                                DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                                City = reader["City"].ToString(),
                                Interest = reader["Interest"].ToString(),
                                Department = reader["Department"].ToString(),
                                DegreeTitle = reader["DegreeTitle"].ToString(),
                                Subject = reader["Subject"].ToString(),
                                StartDate = Convert.ToDateTime(reader["StartDate"]),
                                EndDate = Convert.ToDateTime(reader["EndDate"])
                            };

                            return student;
                        }
                    }
                }
            }

            // If no student found with the given ID, return null or handle accordingly.
            return null;
        }

        public bool DeleteStudentById(int studentId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand command = new SqlCommand())
                        {
                            command.Connection = connection;
                            command.Transaction = transaction;
                            command.CommandType = CommandType.Text;
                            command.CommandText = "DELETE FROM Students WHERE Id = @StudentId";
                            command.Parameters.AddWithValue("@StudentId", studentId);

                            int rowsAffected = command.ExecuteNonQuery();

                            // If no rows affected, the student with the given ID doesn't exist.
                            if (rowsAffected == 0)
                            {
                                transaction.Rollback(); // Rollback the transaction.
                                return false;
                            }

                            transaction.Commit(); // Commit the transaction if successful.
                            return true;
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions (log, rethrow, etc.)
                        transaction.Rollback();
                        // Log or rethrow the exception as needed.
                        return false;
                    }
                }
            }

        }

        public void UpdateStudent(Student student)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand command = new SqlCommand())
                        {
                            command.Connection = connection;
                            command.Transaction = transaction;
                            command.CommandType = CommandType.Text;
                            command.CommandText = "UPDATE Students SET FullName = @FullName, RollNumber = @RollNumber, " +
                                                  "EmailAddress = @EmailAddress, Gender = @Gender, DateOfBirth = @DateOfBirth, " +
                                                  "City = @City, Interest = @Interest, Department = @Department, " +
                                                  "DegreeTitle = @DegreeTitle, Subject = @Subject, " +
                                                  "StartDate = @StartDate, EndDate = @EndDate WHERE Id = @StudentId";

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
                            command.Parameters.AddWithValue("@StudentId", student.Id);

                            int rowsAffected = command.ExecuteNonQuery();

                            // If no rows affected, the student with the given ID doesn't exist.
                            if (rowsAffected == 0)
                            {
                                transaction.Rollback(); // Rollback the transaction.
                                
                            }

                            transaction.Commit(); // Commit the transaction if successful.
                            
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions (log, rethrow, etc.)
                        transaction.Rollback();
                        // Log or rethrow the exception as needed.
                       
                    }
                }
            }
        }




    }
}
