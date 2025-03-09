﻿// <auto-generated />
using System;
using CompanyAndLibrary.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CompanyAndLibrary.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CompanyAndLibrary.Data.Entities.Company.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ApartmentNumber")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("Floor")
                        .HasColumnType("int");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StreetNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("CompanyAndLibrary.Data.Entities.Company.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ManagerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("CompanyAndLibrary.Data.Entities.Company.DepartmentLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("DepartmentLocations");
                });

            modelBuilder.Entity("CompanyAndLibrary.Data.Entities.Company.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("CompanyAndLibrary.Data.Entities.Company.EmployeeProject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("EmployeeId", "StartTime", "EndTime")
                        .IsUnique();

                    b.ToTable("EmployeeProjects");
                });

            modelBuilder.Entity("CompanyAndLibrary.Data.Entities.Company.Library.Book", b =>
                {
                    b.Property<string>("Isbn")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CatName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CategoryCatName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("NumPages")
                        .HasColumnType("int");

                    b.Property<string>("PubName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PubYear")
                        .HasColumnType("int");

                    b.Property<string>("PublisherPubName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Isbn");

                    b.HasIndex("CategoryCatName");

                    b.HasIndex("PublisherPubName");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("CompanyAndLibrary.Data.Entities.Company.Library.Borrow", b =>
                {
                    b.Property<int>("ReaderNr")
                        .HasColumnType("int");

                    b.Property<string>("CopyNr")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BookIsbn")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CopyNr1")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ReaderNr1")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ReaderNr", "CopyNr");

                    b.HasIndex("BookIsbn");

                    b.HasIndex("CopyNr1");

                    b.HasIndex("ReaderNr1");

                    b.ToTable("Borrows");
                });

            modelBuilder.Entity("CompanyAndLibrary.Data.Entities.Company.Library.Category", b =>
                {
                    b.Property<string>("CatName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CatName");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("CompanyAndLibrary.Data.Entities.Company.Library.Copy", b =>
                {
                    b.Property<string>("CopyNr")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BookIsbn")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Isbn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Shelf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CopyNr");

                    b.HasIndex("BookIsbn");

                    b.ToTable("Copies");
                });

            modelBuilder.Entity("CompanyAndLibrary.Data.Entities.Company.Library.InCat", b =>
                {
                    b.Property<string>("Isbn")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CatName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BookIsbn")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CategoryCatName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Isbn", "CatName");

                    b.HasIndex("BookIsbn");

                    b.HasIndex("CategoryCatName");

                    b.ToTable("InCats");
                });

            modelBuilder.Entity("CompanyAndLibrary.Data.Entities.Company.Library.Publisher", b =>
                {
                    b.Property<string>("PubName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PubCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PubName");

                    b.ToTable("Publishers");
                });

            modelBuilder.Entity("CompanyAndLibrary.Data.Entities.Company.Library.Publishes", b =>
                {
                    b.Property<string>("Isbn")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PubName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BookIsbn")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PublisherPubName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Isbn", "PubName");

                    b.HasIndex("BookIsbn");

                    b.HasIndex("PublisherPubName");

                    b.ToTable("Publishes");
                });

            modelBuilder.Entity("CompanyAndLibrary.Data.Entities.Company.Library.Reader", b =>
                {
                    b.Property<int>("ReaderNr")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReaderNr"));

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FamilyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReaderNr");

                    b.ToTable("Readers");
                });

            modelBuilder.Entity("CompanyAndLibrary.Data.Entities.Company.Library.ReaderPhoneNumber", b =>
                {
                    b.Property<int>("ReaderNr")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ReaderNr1")
                        .HasColumnType("int");

                    b.HasKey("ReaderNr", "PhoneNumber");

                    b.HasIndex("ReaderNr1");

                    b.ToTable("ReaderPhoneNumbers");
                });

            modelBuilder.Entity("CompanyAndLibrary.Data.Entities.Company.Manager", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId")
                        .IsUnique();

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("CompanyAndLibrary.Data.Entities.Company.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("CompanyAndLibrary.Data.Entities.Company.Address", b =>
                {
                    b.HasOne("CompanyAndLibrary.Data.Entities.Company.Employee", "Employee")
                        .WithOne()
                        .HasForeignKey("CompanyAndLibrary.Data.Entities.Company.Address", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("CompanyAndLibrary.Data.Entities.Company.DepartmentLocation", b =>
                {
                    b.HasOne("CompanyAndLibrary.Data.Entities.Company.Department", "Department")
                        .WithMany("Locations")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("CompanyAndLibrary.Data.Entities.Company.Employee", b =>
                {
                    b.HasOne("CompanyAndLibrary.Data.Entities.Company.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Department");
                });

            modelBuilder.Entity("CompanyAndLibrary.Data.Entities.Company.EmployeeProject", b =>
                {
                    b.HasOne("CompanyAndLibrary.Data.Entities.Company.Employee", "Employee")
                        .WithMany("EmployeeProjects")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CompanyAndLibrary.Data.Entities.Company.Project", "Project")
                        .WithMany("EmployeeProjects")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("CompanyAndLibrary.Data.Entities.Company.Library.Book", b =>
                {
                    b.HasOne("CompanyAndLibrary.Data.Entities.Company.Library.Category", "Category")
                        .WithMany("Books")
                        .HasForeignKey("CategoryCatName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CompanyAndLibrary.Data.Entities.Company.Library.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherPubName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("CompanyAndLibrary.Data.Entities.Company.Library.Borrow", b =>
                {
                    b.HasOne("CompanyAndLibrary.Data.Entities.Company.Library.Book", null)
                        .WithMany("Borrows")
                        .HasForeignKey("BookIsbn");

                    b.HasOne("CompanyAndLibrary.Data.Entities.Company.Library.Copy", "Copy")
                        .WithMany("Borrows")
                        .HasForeignKey("CopyNr1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CompanyAndLibrary.Data.Entities.Company.Library.Reader", "Reader")
                        .WithMany("Borrows")
                        .HasForeignKey("ReaderNr1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Copy");

                    b.Navigation("Reader");
                });

            modelBuilder.Entity("CompanyAndLibrary.Data.Entities.Company.Library.Copy", b =>
                {
                    b.HasOne("CompanyAndLibrary.Data.Entities.Company.Library.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookIsbn");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("CompanyAndLibrary.Data.Entities.Company.Library.InCat", b =>
                {
                    b.HasOne("CompanyAndLibrary.Data.Entities.Company.Library.Book", "Book")
                        .WithMany("InCats")
                        .HasForeignKey("BookIsbn");

                    b.HasOne("CompanyAndLibrary.Data.Entities.Company.Library.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryCatName");

                    b.Navigation("Book");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("CompanyAndLibrary.Data.Entities.Company.Library.Publishes", b =>
                {
                    b.HasOne("CompanyAndLibrary.Data.Entities.Company.Library.Book", "Book")
                        .WithMany("Publishes")
                        .HasForeignKey("BookIsbn");

                    b.HasOne("CompanyAndLibrary.Data.Entities.Company.Library.Publisher", "Publisher")
                        .WithMany()
                        .HasForeignKey("PublisherPubName");

                    b.Navigation("Book");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("CompanyAndLibrary.Data.Entities.Company.Library.ReaderPhoneNumber", b =>
                {
                    b.HasOne("CompanyAndLibrary.Data.Entities.Company.Library.Reader", "Reader")
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("ReaderNr1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reader");
                });

            modelBuilder.Entity("CompanyAndLibrary.Data.Entities.Company.Manager", b =>
                {
                    b.HasOne("CompanyAndLibrary.Data.Entities.Company.Department", "Department")
                        .WithOne("Manager")
                        .HasForeignKey("CompanyAndLibrary.Data.Entities.Company.Manager", "DepartmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CompanyAndLibrary.Data.Entities.Company.Employee", "Employee")
                        .WithOne("Manager")
                        .HasForeignKey("CompanyAndLibrary.Data.Entities.Company.Manager", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("CompanyAndLibrary.Data.Entities.Company.Project", b =>
                {
                    b.HasOne("CompanyAndLibrary.Data.Entities.Company.Department", "Department")
                        .WithMany("Projects")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("CompanyAndLibrary.Data.Entities.Company.Department", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Locations");

                    b.Navigation("Manager")
                        .IsRequired();

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("CompanyAndLibrary.Data.Entities.Company.Employee", b =>
                {
                    b.Navigation("EmployeeProjects");

                    b.Navigation("Manager")
                        .IsRequired();
                });

            modelBuilder.Entity("CompanyAndLibrary.Data.Entities.Company.Library.Book", b =>
                {
                    b.Navigation("Borrows");

                    b.Navigation("InCats");

                    b.Navigation("Publishes");
                });

            modelBuilder.Entity("CompanyAndLibrary.Data.Entities.Company.Library.Category", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("CompanyAndLibrary.Data.Entities.Company.Library.Copy", b =>
                {
                    b.Navigation("Borrows");
                });

            modelBuilder.Entity("CompanyAndLibrary.Data.Entities.Company.Library.Publisher", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("CompanyAndLibrary.Data.Entities.Company.Library.Reader", b =>
                {
                    b.Navigation("Borrows");

                    b.Navigation("PhoneNumbers");
                });

            modelBuilder.Entity("CompanyAndLibrary.Data.Entities.Company.Project", b =>
                {
                    b.Navigation("EmployeeProjects");
                });
#pragma warning restore 612, 618
        }
    }
}
