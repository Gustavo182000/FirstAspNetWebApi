using FirstAspNetWebApi.Model;
using Microsoft.EntityFrameworkCore;

namespace FirstAspNetWebApi.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<FuncionarioModel> Funcionarios { get; set; }

    }
}
