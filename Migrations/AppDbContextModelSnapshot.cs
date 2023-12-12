﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using linqQueries.Data;

#nullable disable

namespace linqQueries.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EnrolledStudent", b =>
                {
                    b.Property<int>("enrollseid")
                        .HasColumnType("int");

                    b.Property<int>("studentssid")
                        .HasColumnType("int");

                    b.HasKey("enrollseid", "studentssid");

                    b.HasIndex("studentssid");

                    b.ToTable("EnrolledStudent");
                });

            modelBuilder.Entity("linqQueries.Model.Class", b =>
                {
                    b.Property<int>("cid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("cid"));

                    b.Property<int?>("Enrolledeid")
                        .HasColumnType("int");

                    b.Property<int?>("facultyfid")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("roomNo")
                        .HasColumnType("int");

                    b.HasKey("cid");

                    b.HasIndex("Enrolledeid");

                    b.HasIndex("facultyfid");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("linqQueries.Model.Enrolled", b =>
                {
                    b.Property<int>("eid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("eid"));

                    b.HasKey("eid");

                    b.ToTable("Enrolled");
                });

            modelBuilder.Entity("linqQueries.Model.Faculty", b =>
                {
                    b.Property<int>("fid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("fid"));

                    b.Property<int?>("Studentsid")
                        .HasColumnType("int");

                    b.Property<int>("depid")
                        .HasColumnType("int");

                    b.Property<int?>("enrolleid")
                        .HasColumnType("int");

                    b.Property<string>("fname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("standing")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("fid");

                    b.HasIndex("Studentsid");

                    b.HasIndex("enrolleid");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("linqQueries.Model.Student", b =>
                {
                    b.Property<int>("sid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("sid"));

                    b.Property<int?>("Classcid")
                        .HasColumnType("int");

                    b.Property<string>("major")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("standing")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("sid");

                    b.HasIndex("Classcid");

                    b.ToTable("stu");
                });

            modelBuilder.Entity("EnrolledStudent", b =>
                {
                    b.HasOne("linqQueries.Model.Enrolled", null)
                        .WithMany()
                        .HasForeignKey("enrollseid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("linqQueries.Model.Student", null)
                        .WithMany()
                        .HasForeignKey("studentssid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("linqQueries.Model.Class", b =>
                {
                    b.HasOne("linqQueries.Model.Enrolled", null)
                        .WithMany("classes")
                        .HasForeignKey("Enrolledeid");

                    b.HasOne("linqQueries.Model.Faculty", "faculty")
                        .WithMany("classes")
                        .HasForeignKey("facultyfid");

                    b.Navigation("faculty");
                });

            modelBuilder.Entity("linqQueries.Model.Faculty", b =>
                {
                    b.HasOne("linqQueries.Model.Student", null)
                        .WithMany("faculty")
                        .HasForeignKey("Studentsid");

                    b.HasOne("linqQueries.Model.Enrolled", "enroll")
                        .WithMany()
                        .HasForeignKey("enrolleid");

                    b.Navigation("enroll");
                });

            modelBuilder.Entity("linqQueries.Model.Student", b =>
                {
                    b.HasOne("linqQueries.Model.Class", null)
                        .WithMany("students")
                        .HasForeignKey("Classcid");
                });

            modelBuilder.Entity("linqQueries.Model.Class", b =>
                {
                    b.Navigation("students");
                });

            modelBuilder.Entity("linqQueries.Model.Enrolled", b =>
                {
                    b.Navigation("classes");
                });

            modelBuilder.Entity("linqQueries.Model.Faculty", b =>
                {
                    b.Navigation("classes");
                });

            modelBuilder.Entity("linqQueries.Model.Student", b =>
                {
                    b.Navigation("faculty");
                });
#pragma warning restore 612, 618
        }
    }
}