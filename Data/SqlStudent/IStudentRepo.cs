using Education_Api_L1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
