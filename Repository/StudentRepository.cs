using ADOwebAPI.Models;
using Microsoft.Data.SqlClient;


namespace ADOwebAPI.Repository
{
    public class StudentRepository:IStudentRepository
    {
        private readonly string cs;

        public  StudentRepository(IConfiguration config)
        {
            cs = config.GetConnectionString("DefaultConnection");
        }

        public List<Students> GetStudents()
        {
            List<Students> list = new();
            using SqlConnection con = new SqlConnection(cs);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Students", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                list.Add(new Students
                {
                    StudentId = dr.GetInt32(dr.GetOrdinal("StudentId")),
                    FirstName = dr.GetString(dr.GetOrdinal("FirstName")),
                    LastName = dr.GetString(dr.GetOrdinal("LastName")),
                    Age = dr.GetInt32(dr.GetOrdinal("Age"))
                });
            }
            return list;
        }

        public void PostStudent(Students student)
        {
            using SqlConnection con = new SqlConnection(cs);
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Students Values (@id,@fn,@ln,@age)", con);

            cmd.Parameters.AddWithValue("@id", student.Age);
            cmd.Parameters.AddWithValue("@fn", student.FirstName);
            cmd.Parameters.AddWithValue("@ln", student.LastName);
            cmd.Parameters.AddWithValue("@age", student.Age);

            cmd.ExecuteNonQuery();

        }

        public void UpdateStudent(Students student)
        {
            using SqlConnection con = new SqlConnection(cs);
            con.Open();
            SqlCommand cmd = new SqlCommand("Update Students set FirstName=@fn,LastName=@ln,Age=@age where StudentId=@id", con);

            cmd.Parameters.AddWithValue("@fn", student.FirstName);
            cmd.Parameters.AddWithValue("@ln", student.LastName);
            cmd.Parameters.AddWithValue("@age", student.Age);
            cmd.Parameters.AddWithValue("id", student.StudentId);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using SqlConnection con = new SqlConnection(cs);
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete from Students where StudentId=@id", con);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }
    }
}
