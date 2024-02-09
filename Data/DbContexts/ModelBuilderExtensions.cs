namespace FirmaMeble.Data.DbContexts
{
    using Microsoft.EntityFrameworkCore;

    public static class ModelBuilderExtensions
    {
        public static void ConfigureCreateDate<TEntity>(this ModelBuilder modelBuilder) where TEntity : class
        {
            modelBuilder.Entity<TEntity>()
                .Property<DateTime>("CreateDate")
                .HasDefaultValueSql("GETUTCDATE()")
                .HasColumnType("date");
        }
    }
}
