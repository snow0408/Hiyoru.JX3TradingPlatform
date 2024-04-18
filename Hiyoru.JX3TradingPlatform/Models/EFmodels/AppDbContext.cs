using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Hiyoru.JX3TradingPlatform.Models.EFmodels
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("name=AppDbContext")
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Skins> Skins { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>()
                .HasOptional(e => e.Categories1)
                .WithRequired(e => e.Categories2);

            modelBuilder.Entity<Products>()
                .Property(e => e.BuyerID)
                .IsUnicode(false);

            modelBuilder.Entity<Products>()
                .Property(e => e.SellerID)
                .IsUnicode(false);

            modelBuilder.Entity<Products>()
                .Property(e => e.TransAccount)
                .IsFixedLength();

            modelBuilder.Entity<Skins>()
                .Property(e => e.PicturePath)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.BankAccount)
                .IsUnicode(false);
        }
    }
}
