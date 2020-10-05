﻿// <auto-generated />
using EcomCandyShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EcomCandyShop.Migrations
{
    [DbContext(typeof(ShopContext))]
    partial class ShopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EcomCandyShop.Models.Basket", b =>
                {
                    b.Property<int>("BasketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("BasketId");

                    b.ToTable("Basket");
                });

            modelBuilder.Entity("EcomCandyShop.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryID = 1,
                            Name = "Chocolates"
                        },
                        new
                        {
                            CategoryID = 2,
                            Name = "Fruit Candy"
                        },
                        new
                        {
                            CategoryID = 3,
                            Name = "Gummy Candy"
                        },
                        new
                        {
                            CategoryID = 4,
                            Name = "Halloween Candy"
                        },
                        new
                        {
                            CategoryID = 5,
                            Name = "Hard Candy"
                        });
                });

            modelBuilder.Entity("EcomCandyShop.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("Decimal(18,2)");

                    b.HasKey("ProductID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductID = 1,
                            CategoryID = 1,
                            Code = "Chocolate_Assorted",
                            Name = "Assorted Chocolate",
                            Price = 4.99m
                        },
                        new
                        {
                            ProductID = 2,
                            CategoryID = 1,
                            Code = "Chocolate_Mixed",
                            Name = "Chocolate Mixed Candy",
                            Price = 5.99m
                        },
                        new
                        {
                            ProductID = 3,
                            CategoryID = 1,
                            Code = "Chocolate_MMS",
                            Name = "M&M",
                            Price = 3.75m
                        },
                        new
                        {
                            ProductID = 4,
                            CategoryID = 2,
                            Code = "Fruit_Chewy",
                            Name = "Chewy Fruit Candy",
                            Price = 6.9m
                        },
                        new
                        {
                            ProductID = 5,
                            CategoryID = 2,
                            Code = "Fruit_Pops",
                            Name = "Fruit Lolli Pops",
                            Price = 2.9m
                        },
                        new
                        {
                            ProductID = 6,
                            CategoryID = 2,
                            Code = "Fruit_Sour",
                            Name = "Sour Fruit Candy",
                            Price = 4.95m
                        },
                        new
                        {
                            ProductID = 7,
                            CategoryID = 3,
                            Code = "Gummy_Import",
                            Name = "Imported Gummy Candy",
                            Price = 11.9m
                        },
                        new
                        {
                            ProductID = 8,
                            CategoryID = 3,
                            Code = "Gummy_Sour",
                            Name = "Gummy Sour Candy",
                            Price = 1.9m
                        },
                        new
                        {
                            ProductID = 9,
                            CategoryID = 3,
                            Code = "Gummy_Traditional",
                            Name = "Traditional Gummy Candy",
                            Price = 2.9m
                        },
                        new
                        {
                            ProductID = 10,
                            CategoryID = 4,
                            Code = "Halloween_Assorted",
                            Name = "Assorted Halloween Candy",
                            Price = 3.5m
                        },
                        new
                        {
                            ProductID = 15,
                            CategoryID = 5,
                            Code = "Hard_Sour",
                            Name = "Sour Hard Candy",
                            Price = 5.55m
                        });
                });

            modelBuilder.Entity("EcomCandyShop.Models.Product", b =>
                {
                    b.HasOne("EcomCandyShop.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
