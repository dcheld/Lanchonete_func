using Microsoft.EntityFrameworkCore;
using Pedido.Core.Data;

namespace Pedido.Core.Infra
{
    public class SnackBarContext : DbContext
    {
        public DbSet<Ingredient> Ingredients { get; set; }
        public SnackBarContext(DbContextOptions<SnackBarContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // modelBuilder.ApplyAllConfigurationsFromCurrentAssembly();
        }

    }
}
