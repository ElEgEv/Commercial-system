﻿// <auto-generated />
using System;
using BlacksmithWorkshopDatabaseImplement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlacksmithWorkshopDatabaseImplement.Migrations
{
    [DbContext(typeof(BlacksmithWorkshopDatabase))]
    [Migration("20230411085311_NewClear")]
    partial class NewClear
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BlacksmithWorkshopDatabaseImplement.Models.Manufacture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ManufactureName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Manufactures");
                });

            modelBuilder.Entity("BlacksmithWorkshopDatabaseImplement.Models.ManufactureWorkPiece", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("ManufactureId")
                        .HasColumnType("int");

                    b.Property<int>("WorkPieceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ManufactureId");

                    b.HasIndex("WorkPieceId");

                    b.ToTable("ManufactureWorkPieces");
                });

            modelBuilder.Entity("BlacksmithWorkshopDatabaseImplement.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateImplement")
                        .HasColumnType("datetime2");

                    b.Property<int>("ManufactureId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<double>("Sum")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ManufactureId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("BlacksmithWorkshopDatabaseImplement.Models.Shop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOpen")
                        .HasColumnType("datetime2");

                    b.Property<int>("MaxCountManufactures")
                        .HasColumnType("int");

                    b.Property<string>("ShopName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Shops");
                });

            modelBuilder.Entity("BlacksmithWorkshopDatabaseImplement.Models.ShopManufacture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("ManufactureId")
                        .HasColumnType("int");

                    b.Property<int>("ShopId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ManufactureId");

                    b.HasIndex("ShopId");

                    b.ToTable("ShopManufactures");
                });

            modelBuilder.Entity("BlacksmithWorkshopDatabaseImplement.Models.WorkPiece", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Cost")
                        .HasColumnType("float");

                    b.Property<string>("WorkPieceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WorkPieces");
                });

            modelBuilder.Entity("BlacksmithWorkshopDatabaseImplement.Models.ManufactureWorkPiece", b =>
                {
                    b.HasOne("BlacksmithWorkshopDatabaseImplement.Models.Manufacture", "Manufacture")
                        .WithMany("WorkPieces")
                        .HasForeignKey("ManufactureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlacksmithWorkshopDatabaseImplement.Models.WorkPiece", "WorkPiece")
                        .WithMany("ManufactureWorkPieces")
                        .HasForeignKey("WorkPieceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manufacture");

                    b.Navigation("WorkPiece");
                });

            modelBuilder.Entity("BlacksmithWorkshopDatabaseImplement.Models.Order", b =>
                {
                    b.HasOne("BlacksmithWorkshopDatabaseImplement.Models.Manufacture", "Manufacture")
                        .WithMany("Orders")
                        .HasForeignKey("ManufactureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manufacture");
                });

            modelBuilder.Entity("BlacksmithWorkshopDatabaseImplement.Models.ShopManufacture", b =>
                {
                    b.HasOne("BlacksmithWorkshopDatabaseImplement.Models.Manufacture", "Manufacture")
                        .WithMany("Shops")
                        .HasForeignKey("ManufactureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlacksmithWorkshopDatabaseImplement.Models.Shop", "Shop")
                        .WithMany("Manufactures")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manufacture");

                    b.Navigation("Shop");
                });

            modelBuilder.Entity("BlacksmithWorkshopDatabaseImplement.Models.Manufacture", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Shops");

                    b.Navigation("WorkPieces");
                });

            modelBuilder.Entity("BlacksmithWorkshopDatabaseImplement.Models.Shop", b =>
                {
                    b.Navigation("Manufactures");
                });

            modelBuilder.Entity("BlacksmithWorkshopDatabaseImplement.Models.WorkPiece", b =>
                {
                    b.Navigation("ManufactureWorkPieces");
                });
#pragma warning restore 612, 618
        }
    }
}
