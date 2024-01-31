﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ItsWdfs.Csharp.Exam.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240131104930_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Models.Employee.Employee", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Gender")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.Property<Guid?>("TownId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TownId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c559d086-2abf-4811-b86c-5fe3682ff3ca"),
                            BirthDate = new DateTime(2015, 12, 30, 23, 0, 0, 0, DateTimeKind.Utc),
                            Email = "ok@gipo.dev",
                            Gender = "Male",
                            Name = "John1",
                            Surname = "Doe",
                            TownId = new Guid("4e8db196-df99-42f4-a2b5-5647b2891ed8")
                        },
                        new
                        {
                            Id = new Guid("e436dbaa-a076-43ea-8bcb-4a4470d3e2d4"),
                            BirthDate = new DateTime(2015, 12, 30, 23, 0, 0, 0, DateTimeKind.Utc),
                            Email = "ok@gipo.dev",
                            Gender = "Male",
                            Name = "John2",
                            Surname = "Doe",
                            TownId = new Guid("c154caa7-e053-4b24-8377-d261f559a1da")
                        },
                        new
                        {
                            Id = new Guid("c7062ac4-439a-485a-83ac-3a13a9d1b85d"),
                            BirthDate = new DateTime(2015, 12, 30, 23, 0, 0, 0, DateTimeKind.Utc),
                            Email = "ok@gipo.dev",
                            Gender = "Male",
                            Name = "John3",
                            Surname = "Doe",
                            TownId = new Guid("cd27eac6-d6bd-4208-b516-c641a458de9f")
                        });
                });

            modelBuilder.Entity("Models.Town.Town", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CodiceCatastale")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Province")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Towns");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4e8db196-df99-42f4-a2b5-5647b2891ed8"),
                            CodiceCatastale = "G224",
                            Name = "Padova",
                            Province = "PD"
                        },
                        new
                        {
                            Id = new Guid("c154caa7-e053-4b24-8377-d261f559a1da"),
                            CodiceCatastale = "L840",
                            Name = "Vicenza",
                            Province = "VI"
                        },
                        new
                        {
                            Id = new Guid("cd27eac6-d6bd-4208-b516-c641a458de9f"),
                            CodiceCatastale = "L407",
                            Name = "Treviso",
                            Province = "TV"
                        });
                });

            modelBuilder.Entity("Models.Employee.Employee", b =>
                {
                    b.HasOne("Models.Town.Town", "Town")
                        .WithMany("Employees")
                        .HasForeignKey("TownId");

                    b.Navigation("Town");
                });

            modelBuilder.Entity("Models.Town.Town", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}