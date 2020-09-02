using CandidateTesting.JeffersonBompadre.AdjacentMaxDistance.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace CandidateTesting.JeffersonBompadre.AdjacentMaxDistance.Repositories.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Indice> Indice { get; set; }
        public DbSet<ValueInArray> ValueInArray { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            IndiceModel(modelBuilder);
            ValueInArrayModel(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        void IndiceModel(ModelBuilder builder)
        {
            builder.Entity<Indice>()
                .ToTable("TBL_Indice");
            builder.Entity<Indice>()
                .HasKey(x => x.Id)
                .HasName("PK_TBL_Indice");
            builder.Entity<Indice>()
                .Property(x => x.Id)
                .ValueGeneratedNever()
                .HasColumnName("Indice_Id");
            builder.Entity<Indice>()
                .Property(x => x.ValueId)
                .HasColumnName("Value_Id");
            builder.Entity<Indice>()
                .HasOne(x => x.ValueInArray)
                .WithMany(x => x.Indices)
                .HasForeignKey(x => x.ValueId)
                .HasConstraintName("FK_Indice_ValueArray");
        }

        void ValueInArrayModel(ModelBuilder builder)
        {
            builder.Entity<ValueInArray>()
                .ToTable("TBL_ValueArray");
            builder.Entity<ValueInArray>()
                .HasKey(x => x.Id)
                .HasName("PK_TBL_ValueArray");
            builder.Entity<ValueInArray>()
                .Property(x => x.Id)
                .HasColumnName("Value_Id");
            builder.Entity<ValueInArray>()
                .Property(x => x.Value)
                .HasColumnName("Value_Array");
            builder.Entity<ValueInArray>()
                .HasIndex(b => b.Value)
                .HasName("IDX_Value")
                .IsUnique();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlite("Data Source=ArrayValues.db");
    }
}
