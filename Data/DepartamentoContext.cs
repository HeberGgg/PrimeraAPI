using Microsoft.EntityFrameworkCore;
using PruebaApi.Models;

namespace PruebaApi.Data
{

    public class DepartamentoContext : DbContext
    {
        public DepartamentoContext(DbContextOptions<DepartamentoContext>options):base(options)
        {

        }
        public DbSet<Departamento> Departamento      { get; set; }

    }

}