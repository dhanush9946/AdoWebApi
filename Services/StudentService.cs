using ADOwebAPI.Models;
using ADOwebAPI.Repository;

namespace ADOwebAPI.Services
{
    public class StudentService:IStudentService
    {
        private readonly IStudentRepository rep;

        public StudentService(IStudentRepository _repo)
        {
            rep = _repo;
        }

        public List<Students> GetStudents()
        {
            List<Students> std = rep.GetStudents();
            return std;
        }

        public void Posting(Students std)
        {
            rep.PostStudent(std);
        }

        public void  Update(Students std)
        {
            rep.UpdateStudent(std);
        }

        public void DeleteStudent(int id)
        {
            rep.Delete(id);
        }
    }
}
