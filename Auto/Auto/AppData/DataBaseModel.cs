namespace Auto.AppData
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataBaseModel : DbContext
    {
        public DataBaseModel()
            : base("name=DataBaseModel")
        {
        }

        public virtual DbSet<har_avto> har_avto { get; set; }
        public virtual DbSet<Pokupatel> Pokupatel { get; set; }
        public virtual DbSet<Prodaji> Prodaji { get; set; }
        public virtual DbSet<Prodavets> Prodavets { get; set; }
        public virtual DbSet<SystemUsers> SystemUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<har_avto>()
                .Property(e => e.CarNum)
                .IsUnicode(false);

            modelBuilder.Entity<har_avto>()
                .Property(e => e.Firm)
                .IsUnicode(false);

            modelBuilder.Entity<har_avto>()
                .Property(e => e.Model)
                .IsUnicode(false);

            modelBuilder.Entity<har_avto>()
                .Property(e => e.Color)
                .IsUnicode(false);

            modelBuilder.Entity<har_avto>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<har_avto>()
                .Property(e => e.FuelType)
                .IsUnicode(false);

            modelBuilder.Entity<har_avto>()
                .HasOptional(e => e.Prodaji)
                .WithRequired(e => e.har_avto)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Pokupatel>()
                .Property(e => e.FullName)
                .IsUnicode(false);

            modelBuilder.Entity<Pokupatel>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Pokupatel>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Pokupatel>()
                .HasMany(e => e.Prodaji)
                .WithOptional(e => e.Pokupatel)
                .HasForeignKey(e => e.Buyer)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Prodaji>()
                .Property(e => e.CarNum)
                .IsUnicode(false);

            modelBuilder.Entity<Prodavets>()
                .Property(e => e.FullName)
                .IsUnicode(false);

            modelBuilder.Entity<Prodavets>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Prodavets>()
                .HasMany(e => e.Prodaji)
                .WithRequired(e => e.Prodavets)
                .HasForeignKey(e => e.Seller);

            modelBuilder.Entity<Prodavets>()
                .HasMany(e => e.SystemUsers)
                .WithOptional(e => e.Prodavets)
                .WillCascadeOnDelete();
        }
    }
}
