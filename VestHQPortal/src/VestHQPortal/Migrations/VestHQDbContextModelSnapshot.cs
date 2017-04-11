using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using VestHQPortal.Data;

namespace VestHQPortal.Migrations
{
    [DbContext(typeof(VestHQDbContext))]
    partial class VestHQDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VestHQModel.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EmployerId");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("TwitterAccount")
                        .HasAnnotation("MaxLength", 200);

                    b.HasKey("Id");

                    b.HasIndex("EmployerId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("VestHQModel.Employer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EmployerName")
                        .HasAnnotation("MaxLength", 200);

                    b.HasKey("Id");

                    b.ToTable("Employer");
                });

            modelBuilder.Entity("VestHQModel.Holding", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CustomerId");

                    b.Property<int>("Share");

                    b.Property<int>("StockId");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("StockId");

                    b.ToTable("Holding");
                });

            modelBuilder.Entity("VestHQModel.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 200);

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 4);

                    b.HasKey("Id");

                    b.ToTable("Stock");
                });

            modelBuilder.Entity("VestHQModel.StockPriceHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date")
                        .HasColumnName("DateTime")
                        .HasColumnType("smalldatetime");

                    b.Property<double>("Price");

                    b.Property<int>("StockId");

                    b.HasKey("Id")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("StockId");

                    b.HasIndex("StockId", "Date")
                        .IsUnique()
                        .HasName("IX_StockPriceHistory_StockDate")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.ToTable("StockPriceHistory");
                });

            modelBuilder.Entity("VestHQModel.Customer", b =>
                {
                    b.HasOne("VestHQModel.Employer", "Employer")
                        .WithMany("Customers")
                        .HasForeignKey("EmployerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VestHQModel.Holding", b =>
                {
                    b.HasOne("VestHQModel.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("VestHQModel.Stock", "Stock")
                        .WithMany()
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VestHQModel.StockPriceHistory", b =>
                {
                    b.HasOne("VestHQModel.Stock", "Stock")
                        .WithMany("StockHistories")
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
