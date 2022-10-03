using BackendWebProj.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendWebProj.Context
{
    public class BackendWebContext : DbContext
    {
        public BackendWebContext(
            DbContextOptions<BackendWebContext> options) : base(options)
        {
        }
        
        public DbSet<Employ> Employ { get; set; }
    }
}
