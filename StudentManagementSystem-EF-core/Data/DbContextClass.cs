using Microsoft.EntityFrameworkCore;
using StudentManagementSystem_EF_core.ModelEntity;

namespace StudentManagementSystem_EF_core.Data
{
    public class DbContextClass:DbContext
    {
        private readonly IConfiguration _configuration;
        public string connectionString {  get; set; }
        public DbContextClass(IConfiguration configuration)
        {
            _configuration= configuration;
            connectionString = _configuration["ConnectionStrings:DefaultConnection"];
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
        public DbSet<Student> student { get; set; }
    }
}
