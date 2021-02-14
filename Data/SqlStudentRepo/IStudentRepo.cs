using Education_Api_L1.Models;
using System.Collections.Generic;

namespace Education_Api_L1.Data
{
    public interface IStudentRepo
    {
        bool SaveChanges();
        IEnumerable<Student> GetAllStudents();
        Student GetById(int id);
        void CreateStudent(Student std);
        void UpdateStudent(Student std);
        void DeleteStudent(Student std);

    }
}
