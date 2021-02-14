using Education_Api_L1.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Education_Api_L1.Data
{
    public class SqlSchool : ISchoolRepo
    {
        private readonly Education_Api_L1_Context _context;

        public SqlSchool(Education_Api_L1_Context context)
        {
            _context = context;
        }

        public IEnumerable<School> GetAllSchools()
        {
            return _context.Schools.ToList();
        }


        public School GetById(int id)
        {
            return _context.Schools.FirstOrDefault(p => p.Id == id);
        }


        public void CreateSchool(School sch)
        {
            if (sch == null)
            {
                throw new ArgumentException(nameof(sch));
            }

            _context.Schools.Add(sch);
        }


        public void UpdateSchool(School sch)
        {
           
        }


        public void DeleteSchool(School sch)
        {
            if (sch == null)
            {
                throw new ArgumentException(nameof(sch));
            }

            _context.Schools.Remove(sch);
        }


        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
