using CourierDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace CourierDatabaseImplement
{
    public class CourierDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder
                    .UseSqlServer(
                        @"Data Source=DESKTOP-SP8LH2A\SQLEXPRESS;
                          Initial Catalog=CourierDatabase;
                          Integrated Security=True;
                          MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<DeliveryAct> DeliveryActs { set; get; }
    }
}
