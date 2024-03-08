﻿// <auto-generated />
using System;
using CrudApiProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CrudApiProject.Migrations
{
    [DbContext(typeof(APIDemoDbClass))]
    partial class APIDemoDbClassModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CrudApiProject.Models.Orders", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("order_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("total_cost")
                        .HasColumnType("real");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("user_id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("CrudApiProject.Models.Products", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<float>("actual_price")
                        .HasColumnType("real");

                    b.Property<int>("available_quantity")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<float>("selling_price")
                        .HasColumnType("real");

                    b.HasKey("id");

                    b.ToTable("products");
                });

            modelBuilder.Entity("CrudApiProject.Models.Report", b =>
                {
                    b.Property<string>("first_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("last_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("order_id")
                        .HasColumnType("int");

                    b.Property<int>("product_quantity")
                        .HasColumnType("int");

                    b.ToTable("Report");
                });

            modelBuilder.Entity("CrudApiProject.Models.Role", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("role_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("CrudApiProject.Models.UserRole", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("role_id")
                        .HasColumnType("int");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("role_id")
                        .IsUnique();

                    b.HasIndex("user_id")
                        .IsUnique();

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("CrudApiProject.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("first_name")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("last_name")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("email")
                        .IsUnique();

                    b.HasIndex("username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CrudApiProject.Models.order_products", b =>
                {
                    b.Property<int>("order_id")
                        .HasColumnType("int");

                    b.Property<int>("product_id")
                        .HasColumnType("int");

                    b.Property<int>("product_quantity")
                        .HasColumnType("int");

                    b.HasKey("order_id", "product_id");

                    b.HasIndex("product_id");

                    b.ToTable("orderProducts");
                });

            modelBuilder.Entity("CrudApiProject.Models.Orders", b =>
                {
                    b.HasOne("CrudApiProject.Models.Users", "user")
                        .WithMany()
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.ClientCascade);

                    b.Navigation("user");
                });

            modelBuilder.Entity("CrudApiProject.Models.UserRole", b =>
                {
                    b.HasOne("CrudApiProject.Models.Role", "role")
                        .WithOne()
                        .HasForeignKey("CrudApiProject.Models.UserRole", "role_id")
                        .OnDelete(DeleteBehavior.ClientCascade);

                    b.HasOne("CrudApiProject.Models.Users", "user")
                        .WithOne()
                        .HasForeignKey("CrudApiProject.Models.UserRole", "user_id")
                        .OnDelete(DeleteBehavior.ClientCascade);

                    b.Navigation("role");

                    b.Navigation("user");
                });

            modelBuilder.Entity("CrudApiProject.Models.order_products", b =>
                {
                    b.HasOne("CrudApiProject.Models.Orders", "order")
                        .WithMany()
                        .HasForeignKey("order_id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("CrudApiProject.Models.Products", "product")
                        .WithMany()
                        .HasForeignKey("product_id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("order");

                    b.Navigation("product");
                });
#pragma warning restore 612, 618
        }
    }
}
