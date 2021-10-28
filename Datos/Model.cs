using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public partial class Model : DbContext
    {
        public Model(string connectionString) : base(GetOptions(connectionString))
        {
        }

        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<TipoDocumento> TipoDocumento { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>()
                .Property(e => e.Nombres)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.Apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.ValoraGanar)
                .HasPrecision(20, 2);

            modelBuilder.Entity<TipoDocumento>()
                .Property(e => e.Valor)
                .IsUnicode(false);

            modelBuilder.Entity<TipoDocumento>()
                .HasMany(e => e.Persona)
                .WithOne(e => e.TipoDocumento1)
                .HasForeignKey(e => e.TipoDocumento);
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }
    }
}
