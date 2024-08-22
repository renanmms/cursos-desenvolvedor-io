using Microsoft.EntityFrameworkCore;
using PrimeiraAPP.Models;

namespace PrimeiraAPP.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Aluno> Alunos { get; set; }
    }
}
