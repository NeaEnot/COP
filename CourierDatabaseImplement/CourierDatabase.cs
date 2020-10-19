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
                        @"Data Source=DESKTOP-S65O0I4\SQLEXPRESS;
                          Initial Catalog=CourierDatabase;
                          Integrated Security=True;
                          MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<DeliveryAct> DeliveryActs { set; get; }
    }
}
