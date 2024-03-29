﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using testData.database;

#nullable disable

namespace dbAPI.Migrations
{
    [DbContext(typeof(testDbContext))]
    [Migration("20231008124856_ApplicantJobStatus")]
    partial class ApplicantJobStatus
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0-preview.3.23174.2");

            modelBuilder.Entity("testData.Entities.Applicant", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("linkedin")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Applicants");
                });

            modelBuilder.Entity("testData.Entities.Applicant_job", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("applicantRefid")
                        .HasColumnType("INTEGER");

                    b.Property<int>("company_jobRefid")
                        .HasColumnType("INTEGER");

                    b.Property<int>("status")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("applicantRefid");

                    b.HasIndex("company_jobRefid");

                    b.ToTable("ApplicantJobs");
                });

            modelBuilder.Entity("testData.Entities.Company", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Companii");
                });

            modelBuilder.Entity("testData.Entities.Student", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("faculty")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("testData.Entities.company_job", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("companyRefid")
                        .HasColumnType("INTEGER");

                    b.Property<string>("jobDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("jobTitle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.HasIndex("companyRefid");

                    b.ToTable("company_jobs");
                });

            modelBuilder.Entity("testData.Entities.Applicant_job", b =>
                {
                    b.HasOne("testData.Entities.Applicant", "Applicant")
                        .WithMany()
                        .HasForeignKey("applicantRefid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("testData.Entities.company_job", "CompanyJob")
                        .WithMany()
                        .HasForeignKey("company_jobRefid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Applicant");

                    b.Navigation("CompanyJob");
                });

            modelBuilder.Entity("testData.Entities.company_job", b =>
                {
                    b.HasOne("testData.Entities.Company", "company")
                        .WithMany("CompanyJobs")
                        .HasForeignKey("companyRefid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("company");
                });

            modelBuilder.Entity("testData.Entities.Company", b =>
                {
                    b.Navigation("CompanyJobs");
                });
#pragma warning restore 612, 618
        }
    }
}
