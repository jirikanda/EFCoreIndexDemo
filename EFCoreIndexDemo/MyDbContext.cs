using Microsoft.EntityFrameworkCore;

namespace EFCoreIndexDemo
{
	public class MyDbContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			optionsBuilder.UseSqlServer("fake connection string");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<MyTable>(etb =>
			{
				etb.HasIndex(myTable => myTable.SomeNumber).IsUnique().HasFilter("0=1"); // this index is created but due the (weird) condition, it is useless
				etb.HasIndex(myTable => myTable.SomeNumber); // this index is not created
			});
		}
	}
}
