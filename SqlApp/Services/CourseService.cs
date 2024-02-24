using Microsoft.Data.SqlClient;
using SqlApp.Models;

namespace SqlApp.Services
{
    public class CourseService
    {

        private readonly IConfiguration _configuration;
        public CourseService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        private SqlConnection GetConnection(string connectionString)
        {
          
            return new SqlConnection(connectionString);
        }

        public IEnumerable<Course> GetCourses()
        {
            List<Course> courseList = new List<Course>();
            string statement = "select CourseID, CourseName, Rating from dbo.Aramcourse";

            SqlConnection connection = GetConnection(_configuration.GetConnectionString("SQLConnection"));
            connection.Open();
            SqlCommand command = new SqlCommand(statement, connection);

            using(SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Course course = new Course()
                    {
                        CourseID = reader.GetInt32(0),
                        CourseName = reader.GetString(1),
                        Rating = reader.GetDecimal(2)
                    };
                 courseList.Add(course);
                }
            }
            connection.Close();
            return courseList;

        }
    }
}
