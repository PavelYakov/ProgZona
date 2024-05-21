﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Product.Data.Context;

#nullable disable

namespace Product.Migrations
{
    [DbContext(typeof(ProductContext))]
    [Migration("20240411122041_UserCourseStageMigration")]
    partial class UserCourseStageMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Product.Data.Entity.AchievementEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Achievement", (string)null);
                });

            modelBuilder.Entity("Product.Data.Entity.CourseEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MainCourseId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PurchaseCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MainCourseId");

                    b.ToTable("Course", (string)null);
                });

            modelBuilder.Entity("Product.Data.Entity.MainCourseEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DifficultLevel")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PurchaseCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MainCourseEntity");
                });

            modelBuilder.Entity("Product.Data.Entity.StageEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PurchaseCount")
                        .HasColumnType("int");

                    b.Property<int>("StagePoint")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Stage", (string)null);
                });

            modelBuilder.Entity("Product.Data.Entity.TaskLessonEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Point")
                        .HasColumnType("int");

                    b.Property<int>("StageId")
                        .HasColumnType("int");

                    b.Property<string>("TrueAnswer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StageId");

                    b.ToTable("TaskLesson", (string)null);
                });

            modelBuilder.Entity("Product.Data.Entity.TestLessonEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Point")
                        .HasColumnType("int");

                    b.Property<int>("StageId")
                        .HasColumnType("int");

                    b.Property<string>("TrueAnswer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StageId");

                    b.ToTable("TestLesson", (string)null);
                });

            modelBuilder.Entity("Product.Data.Entity.UserAchievementEntity", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("AchievementId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "AchievementId");

                    b.HasIndex("AchievementId");

                    b.ToTable("UserAchievement", (string)null);
                });

            modelBuilder.Entity("Product.Data.Entity.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Point")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("Product.Data.Entity.UserFolderEntity.UserCourseEntity", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<bool>("IsBought")
                        .HasColumnType("bit");

                    b.HasKey("UserId", "CourseId");

                    b.ToTable("UserCourse", (string)null);
                });

            modelBuilder.Entity("Product.Data.Entity.UserFolderEntity.UserMainCourseEntity", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("MainCourseId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<bool>("IsBought")
                        .HasColumnType("bit");

                    b.HasKey("UserId", "MainCourseId");

                    b.ToTable("UserMainCourse", (string)null);
                });

            modelBuilder.Entity("Product.Data.Entity.UserFolderEntity.UserStageEntity", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("StageId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<bool>("IsBought")
                        .HasColumnType("bit");

                    b.HasKey("UserId", "StageId");

                    b.ToTable("UserStage", (string)null);
                });

            modelBuilder.Entity("Product.Data.Entity.CourseEntity", b =>
                {
                    b.HasOne("Product.Data.Entity.MainCourseEntity", "MainCourse")
                        .WithMany("Courses")
                        .HasForeignKey("MainCourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MainCourse");
                });

            modelBuilder.Entity("Product.Data.Entity.StageEntity", b =>
                {
                    b.HasOne("Product.Data.Entity.CourseEntity", "Course")
                        .WithMany("Stages")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Product.Data.Entity.TaskLessonEntity", b =>
                {
                    b.HasOne("Product.Data.Entity.StageEntity", "Stage")
                        .WithMany("Tasks")
                        .HasForeignKey("StageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stage");
                });

            modelBuilder.Entity("Product.Data.Entity.TestLessonEntity", b =>
                {
                    b.HasOne("Product.Data.Entity.StageEntity", "Stage")
                        .WithMany("Tests")
                        .HasForeignKey("StageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stage");
                });

            modelBuilder.Entity("Product.Data.Entity.UserAchievementEntity", b =>
                {
                    b.HasOne("Product.Data.Entity.AchievementEntity", "Achievement")
                        .WithMany("UserAchievements")
                        .HasForeignKey("AchievementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Product.Data.Entity.UserEntity", "User")
                        .WithMany("UserAchievements")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Achievement");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Product.Data.Entity.AchievementEntity", b =>
                {
                    b.Navigation("UserAchievements");
                });

            modelBuilder.Entity("Product.Data.Entity.CourseEntity", b =>
                {
                    b.Navigation("Stages");
                });

            modelBuilder.Entity("Product.Data.Entity.MainCourseEntity", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("Product.Data.Entity.StageEntity", b =>
                {
                    b.Navigation("Tasks");

                    b.Navigation("Tests");
                });

            modelBuilder.Entity("Product.Data.Entity.UserEntity", b =>
                {
                    b.Navigation("UserAchievements");
                });
#pragma warning restore 612, 618
        }
    }
}
