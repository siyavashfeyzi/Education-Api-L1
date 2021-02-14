using Education_Api_L1.Models;
using System.Collections.Generic;

namespace Education_Api_L1.Data
{
    public interface ISchoolRepo
    {
        bool SaveChanges();
        IEnumerable<School> GetAllSchools();
        School GetById(int id);
        void CreateSchool(School sch);
        void UpdateSchool(School sch);
        void DeleteSchool(School sch);
    }
}
