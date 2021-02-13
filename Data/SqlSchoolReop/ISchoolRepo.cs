using Education_Api_L1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Education_Api_L1.Data.SqlSchoolReop
{
    public interface ISchoolRepo
    {
        bool SaveChanges();
        IEnumerable<School> GetAllSchools();
        School GetById(int id);
        void CreateSchool(School std);
        void UpdateSchool(School std);
        void DeleteSchool(School std);
    }
}
