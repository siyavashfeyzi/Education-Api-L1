using Education_Api_L1.Models;
using Microsoft.EntityFrameworkCore;

namespace Education_Api_L1.Data
{
    public class Education_Api_L1_Context : DbContext
    {
        public Education_Api_L1_Context(DbContextOptions<Education_Api_L1_Context>opt) : base (opt)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<School> Schools { get; set; }
    }
}
