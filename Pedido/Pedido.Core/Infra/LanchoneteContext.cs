using Microsoft.EntityFrameworkCore;

namespace Pedido.Core.Infra
{
    public class LanchoneteContext : DbContext
    {
        public LanchoneteContext(DbContextOptions<LanchoneteContext> options)
            : base(options)
        {

        }
    }
}
