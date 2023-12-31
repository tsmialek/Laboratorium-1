﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231211181556_PCs_DiskTypes")]
    partial class PCsDiskTypes
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("Data.Entities.ContactEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Birth")
                        .HasColumnType("TEXT")
                        .HasColumnName("birth_date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("contacts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Birth = new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "adam@wsei.edu.pl",
                            Name = "Adam",
                            Phone = "127813268163"
                        },
                        new
                        {
                            Id = 2,
                            Birth = new DateTime(1999, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "ewa@wsei.edu.pl",
                            Name = "Ewa",
                            Phone = "293443823478"
                        });
                });

            modelBuilder.Entity("Data.Entities.DiskType", b =>
                {
                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.HasKey("Type");

                    b.ToTable("DiskTypes");

                    b.HasData(
                        new
                        {
                            Type = "HDD"
                        },
                        new
                        {
                            Type = "SSD"
                        },
                        new
                        {
                            Type = "NVMe"
                        });
                });

            modelBuilder.Entity("Data.Entities.PCEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Disk")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("DiskTypeId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("GPU")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Manufacturer")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Processor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ProductionDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("RAM")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DiskTypeId");

                    b.ToTable("pcs");
                });

            modelBuilder.Entity("Data.Entities.PCEntity", b =>
                {
                    b.HasOne("Data.Entities.DiskType", "DiskTypeNav")
                        .WithMany()
                        .HasForeignKey("DiskTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DiskTypeNav");
                });
#pragma warning restore 612, 618
        }
    }
}
