namespace CtrlMensVendas.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class GesCtrlDb : DbContext
    {
        public GesCtrlDb()
            : base("name=GesCtrlDb")
        {
        }

        public virtual DbSet<CLIENTES> CLIENTES { get; set; }
        public virtual DbSet<MECANICOS> MECANICOS { get; set; }
        public virtual DbSet<PRODUTOS> PRODUTOS { get; set; }
        public virtual DbSet<VEICULOS> VEICULOS { get; set; }
        public virtual DbSet<VENDA> VENDA { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CLIENTES>()
                .Property(e => e.NOMECLI)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTES>()
                .Property(e => e.ENDERECOCLI)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTES>()
                .HasMany(e => e.VENDA)
                .WithRequired(e => e.CLIENTES)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MECANICOS>()
                .Property(e => e.NOMEMEC)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUTOS>()
                .Property(e => e.DESCPROD)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUTOS>()
                .Property(e => e.VALUNPROD)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PRODUTOS>()
                .HasMany(e => e.VENDA)
                .WithRequired(e => e.PRODUTOS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VEICULOS>()
                .Property(e => e.DESCVEICULO)
                .IsUnicode(false);

            modelBuilder.Entity<VEICULOS>()
                .Property(e => e.PLACAVEICULO)
                .IsUnicode(false);

            modelBuilder.Entity<VENDA>()
                .Property(e => e.QTD)
                .HasPrecision(18, 0);

            modelBuilder.Entity<VENDA>()
                .Property(e => e.VALORTOTAL)
                .HasPrecision(18, 0);
        }
    }
}
