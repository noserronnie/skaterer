﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Skateshop.Data;

namespace Skateshop.Migrations
{
    [DbContext(typeof(SkatererContext))]
    partial class SkateshopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16");

            modelBuilder.Entity("DeckProductShoppingCart", b =>
                {
                    b.Property<long>("DeckProductsId")
                        .HasColumnType("bigint");

                    b.Property<long>("ShoppingCartsId")
                        .HasColumnType("bigint");

                    b.HasKey("DeckProductsId", "ShoppingCartsId");

                    b.HasIndex("ShoppingCartsId");

                    b.ToTable("DeckProductShoppingCart");
                });

            modelBuilder.Entity("GriptapeProductShoppingCart", b =>
                {
                    b.Property<long>("GriptapeProductsId")
                        .HasColumnType("bigint");

                    b.Property<long>("ShoppingCartsId")
                        .HasColumnType("bigint");

                    b.HasKey("GriptapeProductsId", "ShoppingCartsId");

                    b.HasIndex("ShoppingCartsId");

                    b.ToTable("GriptapeProductShoppingCart");
                });

            modelBuilder.Entity("ShoppingCartTrucksProduct", b =>
                {
                    b.Property<long>("ShoppingCartsId")
                        .HasColumnType("bigint");

                    b.Property<long>("TrucksProductsId")
                        .HasColumnType("bigint");

                    b.HasKey("ShoppingCartsId", "TrucksProductsId");

                    b.HasIndex("TrucksProductsId");

                    b.ToTable("ShoppingCartTrucksProduct");
                });

            modelBuilder.Entity("ShoppingCartWheelsProduct", b =>
                {
                    b.Property<long>("ShoppingCartsId")
                        .HasColumnType("bigint");

                    b.Property<long>("WheelsProductsId")
                        .HasColumnType("bigint");

                    b.HasKey("ShoppingCartsId", "WheelsProductsId");

                    b.HasIndex("WheelsProductsId");

                    b.ToTable("ShoppingCartWheelsProduct");
                });

            modelBuilder.Entity("Skateshop.Models.Brand", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brand");
                });

            modelBuilder.Entity("Skateshop.Models.DeckProduct", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long?>("BrandId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Length")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Nose")
                        .HasColumnType("real");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.Property<float>("Tail")
                        .HasColumnType("real");

                    b.Property<float>("Wheelbase")
                        .HasColumnType("real");

                    b.Property<float>("Width")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("DeckProduct");
                });

            modelBuilder.Entity("Skateshop.Models.GriptapeProduct", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long?>("BrandId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Length")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.Property<float>("Width")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("GriptapeProduct");
                });

            modelBuilder.Entity("Skateshop.Models.ShoppingCart", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.HasKey("Id");

                    b.ToTable("ShoppingCart");
                });

            modelBuilder.Entity("Skateshop.Models.TrucksProduct", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<float>("AxleWidth")
                        .HasColumnType("real");

                    b.Property<long?>("BrandId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("HangerWidth")
                        .HasColumnType("real");

                    b.Property<float>("Height")
                        .HasColumnType("real");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("TrucksProduct");
                });

            modelBuilder.Entity("Skateshop.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("ShoppingCartId")
                        .HasColumnType("bigint");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ShoppingCartId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Skateshop.Models.WheelsProduct", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long?>("BrandId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Diameter")
                        .HasColumnType("real");

                    b.Property<float>("Hardness")
                        .HasColumnType("real");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.Property<float>("Width")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("WheelsProduct");
                });

            modelBuilder.Entity("DeckProductShoppingCart", b =>
                {
                    b.HasOne("Skateshop.Models.DeckProduct", null)
                        .WithMany()
                        .HasForeignKey("DeckProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Skateshop.Models.ShoppingCart", null)
                        .WithMany()
                        .HasForeignKey("ShoppingCartsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GriptapeProductShoppingCart", b =>
                {
                    b.HasOne("Skateshop.Models.GriptapeProduct", null)
                        .WithMany()
                        .HasForeignKey("GriptapeProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Skateshop.Models.ShoppingCart", null)
                        .WithMany()
                        .HasForeignKey("ShoppingCartsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ShoppingCartTrucksProduct", b =>
                {
                    b.HasOne("Skateshop.Models.ShoppingCart", null)
                        .WithMany()
                        .HasForeignKey("ShoppingCartsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Skateshop.Models.TrucksProduct", null)
                        .WithMany()
                        .HasForeignKey("TrucksProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ShoppingCartWheelsProduct", b =>
                {
                    b.HasOne("Skateshop.Models.ShoppingCart", null)
                        .WithMany()
                        .HasForeignKey("ShoppingCartsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Skateshop.Models.WheelsProduct", null)
                        .WithMany()
                        .HasForeignKey("WheelsProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Skateshop.Models.DeckProduct", b =>
                {
                    b.HasOne("Skateshop.Models.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId");

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("Skateshop.Models.GriptapeProduct", b =>
                {
                    b.HasOne("Skateshop.Models.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId");

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("Skateshop.Models.TrucksProduct", b =>
                {
                    b.HasOne("Skateshop.Models.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId");

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("Skateshop.Models.User", b =>
                {
                    b.HasOne("Skateshop.Models.ShoppingCart", "ShoppingCart")
                        .WithMany()
                        .HasForeignKey("ShoppingCartId");

                    b.Navigation("ShoppingCart");
                });

            modelBuilder.Entity("Skateshop.Models.WheelsProduct", b =>
                {
                    b.HasOne("Skateshop.Models.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId");

                    b.Navigation("Brand");
                });
#pragma warning restore 612, 618
        }
    }
}
