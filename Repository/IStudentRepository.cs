using ADOwebAPI.Models;

namespace ADOwebAPI.Repository
{
    public interface IStudentRepository
    {
        public List<Students> GetStudents();
        public void PostStudent(Students student);

        public void UpdateStudent(Students std);

        public void Delete(int id);
    }
}
