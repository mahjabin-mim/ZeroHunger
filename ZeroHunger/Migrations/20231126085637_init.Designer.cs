﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ZeroHunger.Data;

#nullable disable

namespace ZeroHunger.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231126085637_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ZeroHunger.Models.Admin", b =>
                {
                    b.Property<string>("adminUsername")
                        .HasColumnType("text");

                    b.Property<string>("adminPassword")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("adminPhone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("adminUsername");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("ZeroHunger.Models.Applicants", b =>
                {
                    b.Property<string>("email")
                        .HasColumnType("text");

                    b.Property<string>("appAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("appName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("appPhone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("appStatus")
                        .HasColumnType("boolean");

                    b.Property<string>("applyDate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("email");

                    b.ToTable("Applicants");
                });

            modelBuilder.Entity("ZeroHunger.Models.CollectRequest", b =>
                {
                    b.Property<int>("reqId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("reqId"));

                    b.Property<string>("empUsername")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("foodType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("maxPreservationTime")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("quantity")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("reqPosted")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("reqStarus")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("restUserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("reqId");

                    b.HasIndex("restUserName");

                    b.ToTable("CollectRequest");
                });

            modelBuilder.Entity("ZeroHunger.Models.Employee", b =>
                {
                    b.Property<string>("empUserName")
                        .HasColumnType("text");

                    b.Property<int>("completedReq")
                        .HasColumnType("integer");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("empAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("empName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("empPassword")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("empPhone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("joinningDate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("empUserName");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("ZeroHunger.Models.Restaurant", b =>
                {
                    b.Property<string>("restUserName")
                        .HasColumnType("text");

                    b.Property<string>("registratineDate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("restLocation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("restName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("restPassword")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("restPhone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("restUserName");

                    b.ToTable("Restaurant");
                });

            modelBuilder.Entity("ZeroHunger.Models.CollectRequest", b =>
                {
                    b.HasOne("ZeroHunger.Models.Restaurant", "Restaurant")
                        .WithMany("CollectRequest")
                        .HasForeignKey("restUserName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("ZeroHunger.Models.Restaurant", b =>
                {
                    b.Navigation("CollectRequest");
                });
#pragma warning restore 612, 618
        }
    }
}
