using ADOwebAPI.Models;

namespace ADOwebAPI.Services
{
    public interface IStudentService
    {
       public List<Students> GetStudents();
       public void Posting(Students std);
       public void Update(Students std);
        public void DeleteStudent(int id);


    }
}
