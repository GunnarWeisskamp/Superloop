using DAOEntityFramework.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace DAOEntityFramework
{
    public partial class AppContext : DbContext
    {
        public DbSet<ToDo> ToDos { get; set; }
        public AppContext() {
           
        }
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {
            
        }
    }
}
