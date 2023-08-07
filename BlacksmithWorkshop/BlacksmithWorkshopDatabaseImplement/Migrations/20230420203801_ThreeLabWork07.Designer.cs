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
    [Migration("20230420203801_ThreeLabWork07")]
    partial class ThreeLabWork07
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BlacksmithWorkshopDatabaseImplement.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClientFIO")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("BlacksmithWorkshopDatabaseImplement.Models.Implementer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImplementerFIO")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Qualification")
                        .HasColumnType("int");

                    b.Property<int>("WorkExperience")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Implementers");
                });

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

            modelBuilder.Entity("BlacksmithWorkshopDatabaseImplement.Models.MessageInfo", b =>
                {
                    b.Property<string>("MessageId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateDelivery")
                        .HasColumnType("datetime2");

                    b.Property<string>("SenderName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MessageId");

                    b.HasIndex("ClientId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("BlacksmithWorkshopDatabaseImplement.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateImplement")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ImplementerId")
                        .HasColumnType("int");

                    b.Property<int>("ManufactureId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<double>("Sum")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ImplementerId");

                    b.HasIndex("ManufactureId");

                    b.ToTable("Orders");
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

            modelBuilder.Entity("BlacksmithWorkshopDatabaseImplement.Models.MessageInfo", b =>
                {
                    b.HasOne("BlacksmithWorkshopDatabaseImplement.Models.Client", "Client")
                        .WithMany("MessageInfos")
                        .HasForeignKey("ClientId");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("BlacksmithWorkshopDatabaseImplement.Models.Order", b =>
                {
                    b.HasOne("BlacksmithWorkshopDatabaseImplement.Models.Client", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlacksmithWorkshopDatabaseImplement.Models.Implementer", "Implementer")
                        .WithMany("Orders")
                        .HasForeignKey("ImplementerId");

                    b.HasOne("BlacksmithWorkshopDatabaseImplement.Models.Manufacture", "Manufacture")
                        .WithMany("Orders")
                        .HasForeignKey("ManufactureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Implementer");

                    b.Navigation("Manufacture");
                });

            modelBuilder.Entity("BlacksmithWorkshopDatabaseImplement.Models.Client", b =>
                {
                    b.Navigation("MessageInfos");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("BlacksmithWorkshopDatabaseImplement.Models.Implementer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("BlacksmithWorkshopDatabaseImplement.Models.Manufacture", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("WorkPieces");
                });

            modelBuilder.Entity("BlacksmithWorkshopDatabaseImplement.Models.WorkPiece", b =>
                {
                    b.Navigation("ManufactureWorkPieces");
                });
#pragma warning restore 612, 618
        }
    }
}
