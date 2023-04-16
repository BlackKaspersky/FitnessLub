﻿// <auto-generated />
using System;
using FitnessLub.BL.Controller;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FitnessLub.BL.Migrations
{
    [DbContext(typeof(FitnessContext))]
    [Migration("20230416134912_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FitnessLub.BL.Model.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("CaloriesPerMinute")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("FitnessLub.BL.Model.Eating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("FoodId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Moment")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FoodId");

                    b.HasIndex("UserId");

                    b.ToTable("Eatings");
                });

            modelBuilder.Entity("FitnessLub.BL.Model.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ActivityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Finish")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ActivityId");

                    b.HasIndex("UserId");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("FitnessLub.BL.Model.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Callories")
                        .HasColumnType("float");

                    b.Property<double>("Carbohydrates")
                        .HasColumnType("float");

                    b.Property<double>("Fats")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Proteins")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("FitnessLub.BL.Model.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("FitnessLub.BL.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthData")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GenderId")
                        .HasColumnType("int");

                    b.Property<double>("Height")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FitnessLub.BL.Model.Eating", b =>
                {
                    b.HasOne("FitnessLub.BL.Model.Food", null)
                        .WithMany("Eatings")
                        .HasForeignKey("FoodId");

                    b.HasOne("FitnessLub.BL.Model.User", "User")
                        .WithMany("Eatings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FitnessLub.BL.Model.Exercise", b =>
                {
                    b.HasOne("FitnessLub.BL.Model.Activity", "Activity")
                        .WithMany("Exercises")
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitnessLub.BL.Model.User", "User")
                        .WithMany("Exercises")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Activity");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FitnessLub.BL.Model.User", b =>
                {
                    b.HasOne("FitnessLub.BL.Model.Gender", "Gender")
                        .WithMany("Users")
                        .HasForeignKey("GenderId");

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("FitnessLub.BL.Model.Activity", b =>
                {
                    b.Navigation("Exercises");
                });

            modelBuilder.Entity("FitnessLub.BL.Model.Food", b =>
                {
                    b.Navigation("Eatings");
                });

            modelBuilder.Entity("FitnessLub.BL.Model.Gender", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("FitnessLub.BL.Model.User", b =>
                {
                    b.Navigation("Eatings");

                    b.Navigation("Exercises");
                });
#pragma warning restore 612, 618
        }
    }
}