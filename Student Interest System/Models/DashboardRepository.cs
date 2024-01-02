using System.Data.SqlClient;
using System.Data;

namespace Student_Interest_System_Mvc.Models
{
    public class DashboardRepository
    {
        private readonly string connectionString;
        public List<string> top5Interests;
        public List<string> bottom5Interests;
        public int noOfInterests;
        public Dictionary<string, int> departmentDictionary;
        public Dictionary<string, int> degreeDictionary;
        public Dictionary<string, int> genderDictionary;



        public DashboardRepository()
        {
            this.connectionString = connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StudentDB;Integrated Security=True;Connect Timeout=30;Encrypt=False";
            List<string> interests = GetInterests();
            top5Interests = GetTop5Interests(interests);
            bottom5Interests = GetBottom5Interests(interests);
            noOfInterests = GetDistinctNoOfInterests();
            departmentDictionary = GetDepartmentCounts();
            degreeDictionary = GetDegreeCounts();
            genderDictionary = GetGenderCounts();

        }
        public int GetDistinctNoOfInterests()
        {
            StudentRepository studentRepository = new StudentRepository();
            return studentRepository.GetInterestsFromDatabase().Count();
        }

        private List<string> GetInterests()
        {
            List<string> interests = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;

                    // Retrieve all interests from the Students table
                    command.CommandText = "SELECT Interest FROM Students";

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

        private List<string> GetTop5Interests(List<string> allInterests)
        {
            var interestCounts = allInterests
                .GroupBy(i => i)
                .Select(g => new { Interest = g.Key, Count = g.Count() })
                .OrderByDescending(g => g.Count)
                .Take(5)
                .Select(g => g.Interest)
                .ToList();

            return interestCounts;
        }

        private List<string> GetBottom5Interests(List<string> allInterests)
        {
            var interestCounts = allInterests
                .GroupBy(i => i)
                .Select(g => new { Interest = g.Key, Count = g.Count() })
                .OrderBy(g => g.Count)
                .Take(5)
                .Select(g => g.Interest)
                .ToList();

            return interestCounts;
        }

        public Dictionary<string, int> GetDepartmentCounts()
        {
            Dictionary<string, int> departmentCounts = new Dictionary<string, int>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT Department, COUNT(*) AS DepartmentCount FROM Students GROUP BY Department";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string department = reader["Department"].ToString();
                            int count = Convert.ToInt32(reader["DepartmentCount"]);

                            departmentCounts.Add(department, count);
                        }
                    }
                }
            }

            return departmentCounts;
        }

        public Dictionary<string, int> GetDegreeCounts()
        {
            Dictionary<string, int> degreeCounts = new Dictionary<string, int>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT DegreeTitle, COUNT(*) AS DegreeCount FROM Students GROUP BY DegreeTitle";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string degreeTitle = reader["DegreeTitle"].ToString();
                            int count = Convert.ToInt32(reader["DegreeCount"]);

                            degreeCounts.Add(degreeTitle, count);
                        }
                    }
                }
            }

            return degreeCounts;
        }

        public Dictionary<string, int> GetGenderCounts()
        {
            Dictionary<string, int> genderCounts = new Dictionary<string, int>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT Gender, COUNT(*) AS GenderCount FROM Students GROUP BY Gender";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string gender = reader["Gender"].ToString();
                            int count = Convert.ToInt32(reader["GenderCount"]);

                            genderCounts.Add(gender, count);
                        }
                    }
                }
            }

            return genderCounts;
        }


    }
}
