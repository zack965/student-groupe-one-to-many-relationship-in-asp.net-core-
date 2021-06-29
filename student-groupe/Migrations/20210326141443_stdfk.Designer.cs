﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using student_groupe.Data;

namespace student_groupe.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210326141443_stdfk")]
    partial class stdfk
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("student_groupe.Models.Groupe", b =>
                {
                    b.Property<int>("Groupe_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Groupe_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Groupe_Id");

                    b.ToTable("Groupes");
                });

            modelBuilder.Entity("student_groupe.Models.Student", b =>
                {
                    b.Property<int>("Student_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Groupe_Id")
                        .HasColumnType("int");

                    b.Property<string>("Student_Filiere")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Student_Full_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Student_Id");

                    b.HasIndex("Groupe_Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("student_groupe.Models.Student", b =>
                {
                    b.HasOne("student_groupe.Models.Groupe", "groupe")
                        .WithMany("students")
                        .HasForeignKey("Groupe_Id");

                    b.Navigation("groupe");
                });

            modelBuilder.Entity("student_groupe.Models.Groupe", b =>
                {
                    b.Navigation("students");
                });
#pragma warning restore 612, 618
        }
    }
}