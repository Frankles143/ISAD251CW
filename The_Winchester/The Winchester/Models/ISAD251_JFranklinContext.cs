using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace The_Winchester
{
    public partial class ISAD251_JFranklinContext : DbContext
    {
        public ISAD251_JFranklinContext()
        {
        }

        public ISAD251_JFranklinContext(DbContextOptions<ISAD251_JFranklinContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MonthlySales> MonthlySales { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Sales> Sales { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=socem1.uopnet.plymouth.ac.uk;Database=ISAD251_JFranklin;User Id=JFranklin; Password=ISAD251_22203114");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MonthlySales>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("MonthlySales");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.TotalCost).HasColumnType("decimal");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("Order_pk")
                    .IsClustered(false);

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.Completed).HasColumnName("completed");

                entity.Property(e => e.Preparing).HasColumnName("preparing");

                entity.Property(e => e.TableNumber).HasColumnName("table_number");

                entity.Property(e => e.TimeCompleted)
                    .HasColumnName("time_completed")
                    .HasColumnType("datetime");

                entity.Property(e => e.TimeOrdered)
                    .HasColumnName("time_ordered")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("Order_User_user_id_fk");
            });

            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductId })
                    .HasName("Order_Details_pk")
                    .IsClustered(false);

                entity.ToTable("Order_Details");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Order_Details_Order_order_Id_fk");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Order_Details_Product_product_id_fk");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("Product_pk")
                    .IsClustered(false);

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.InUse).HasColumnName("in_use");

                entity.Property(e => e.ProdCategory)
                    .IsRequired()
                    .HasColumnName("prod_category");

                entity.Property(e => e.ProdDesc).HasColumnName("prod_desc");

                entity.Property(e => e.ProdName)
                    .IsRequired()
                    .HasColumnName("prod_name");

                entity.Property(e => e.ProdPrice)
                    .HasColumnName("prod_price")
                    .HasColumnType("decimal");

                entity.Property(e => e.Stock).HasColumnName("stock");
            });

            modelBuilder.Entity<Sales>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Sales");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.TotalCost).HasColumnType("decimal");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("User_pk")
                    .IsClustered(false);

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Admin).HasColumnName("admin");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
