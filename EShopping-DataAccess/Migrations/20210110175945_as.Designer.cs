﻿// <auto-generated />
using System;
using EShopping_DataAccess.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace EShopping_DataAccess.Migrations
{
    [DbContext(typeof(ShoppContext))]
    [Migration("20210110175945_as")]
    partial class @as
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("EShopping_Entity.BasketItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("ProductsId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int>("basketId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProductsId");

                    b.HasIndex("basketId");

                    b.ToTable("BasketItem");
                });

            modelBuilder.Entity("EShopping_Entity.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("CategoryName")
                        .HasColumnType("text");

                    b.HasKey("CategoryID");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("EShopping_Entity.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("EShopping_Entity.ProductCategory", b =>
                {
                    b.Property<int>("CategoryID")
                        .HasColumnType("integer");

                    b.Property<int>("ProductID")
                        .HasColumnType("integer");

                    b.HasKey("CategoryID", "ProductID");

                    b.HasIndex("ProductID");

                    b.ToTable("ProductCategory");
                });

            modelBuilder.Entity("EShopping_Entity.Products", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Descriptions")
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<decimal?>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("ProductName")
                        .HasColumnType("text");

                    b.Property<decimal?>("ReducedPrice")
                        .HasColumnType("numeric");

                    b.Property<int>("Stock")
                        .HasColumnType("integer");

                    b.HasKey("ProductID");

                    b.ToTable("products");
                });

            modelBuilder.Entity("EShopping_Entity.basket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("UserId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("baskets");
                });

            modelBuilder.Entity("EShopping_Entity.BasketItem", b =>
                {
                    b.HasOne("EShopping_Entity.Products", "Products")
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EShopping_Entity.basket", "basket")
                        .WithMany("basketItems")
                        .HasForeignKey("basketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("basket");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("EShopping_Entity.ProductCategory", b =>
                {
                    b.HasOne("EShopping_Entity.Category", "Category")
                        .WithMany("ProductCategories")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EShopping_Entity.Products", "Products")
                        .WithMany("ProductCategories")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("EShopping_Entity.Category", b =>
                {
                    b.Navigation("ProductCategories");
                });

            modelBuilder.Entity("EShopping_Entity.Products", b =>
                {
                    b.Navigation("ProductCategories");
                });

            modelBuilder.Entity("EShopping_Entity.basket", b =>
                {
                    b.Navigation("basketItems");
                });
#pragma warning restore 612, 618
        }
    }
}