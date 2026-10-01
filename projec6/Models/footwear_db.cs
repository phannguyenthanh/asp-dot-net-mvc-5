namespace project5.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class footwear_db : DbContext
    {
        public footwear_db()
            : base("name=footwear_db")
        {
        }

        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Letter> Letters { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Pay> Pays { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Slider> Sliders { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Brand)
                .HasForeignKey(e => e.IdBrand)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Category)
                .HasForeignKey(e => e.IdCategory)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Client>()
                .Property(e => e.Cnt)
                .IsUnicode(false);

            modelBuilder.Entity<Letter>()
                .Property(e => e.First_name)
                .IsFixedLength();

            modelBuilder.Entity<Letter>()
                .Property(e => e.Last_name)
                .IsFixedLength();

            modelBuilder.Entity<Letter>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Letter>()
                .Property(e => e.Textcontent)
                .IsUnicode(false);

            modelBuilder.Entity<Letter>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Pay>()
                .HasMany(e => e.Transactions)
                .WithOptional(e => e.Pay)
                .HasForeignKey(e => e.IdPay)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Product>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Images)
                .WithOptional(e => e.Product)
                .HasForeignKey(e => e.IdProduct)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.Product)
                .HasForeignKey(e => e.IdProduct)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Transaction>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.Phone)
                .IsFixedLength();

            modelBuilder.Entity<Transaction>()
                .Property(e => e.Security)
                .IsUnicode(false);

            modelBuilder.Entity<Transaction>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.Transaction)
                .HasForeignKey(e => e.IdTransaction)
                .WillCascadeOnDelete();

            modelBuilder.Entity<User>()
                .Property(e => e.First_name)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.Last_name)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Passwold)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Address)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.Avatar)
                .IsUnicode(false);
        }
    }
}
