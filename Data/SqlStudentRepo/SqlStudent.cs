using Education_Api_L1.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Education_Api_L1.Data
{
    public class SqlStudent : IStudentRepo
    {
        private readonly Education_Api_L1_Context _context;


        public SqlStudent(Education_Api_L1_Context context)
        {
            _context = context;
        }


        public IEnumerable<Student> GetAllStudents()
        {
            return _context.Students.ToList();
        }


        public Student GetById(int id)
        {
            return _context.Students.FirstOrDefault(p => p.id == id);
        }


        public void CreateStudent(Student std)
        {
            if (std == null)
            {
                throw new ArgumentException(nameof(std));
            }

            _context.Students.Add(std);
        }


        public void UpdateStudent(Student std)
        {
            
        }

        public void DeleteStudent(Student std)
        {
            if (std == null)
            {
                throw new ArgumentException(nameof(std));
            }
            _context.Students.Remove(std);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
