﻿// <auto-generated />
using System;
using BankingAPIs.DATA;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BankingAPIs.Migrations
{
    [DbContext(typeof(DataBank))]
    [Migration("20230110194830_second")]
    partial class second
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BankingAPIs.ModelClass.AdminLogin", b =>
                {
                    b.Property<int>("BankId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("BankId");

                    b.ToTable("AdminLogins");
                });

            modelBuilder.Entity("BankingAPIs.ModelClass.CustomerAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("AccountBalance")
                        .HasColumnType("double");

                    b.Property<string>("AccountGenerated")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("AccountTypes")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Active")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("BVN")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("CustomerAccounts");
                });

            modelBuilder.Entity("BankingAPIs.ModelClass.Login", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("BankingAPIs.ModelClass.SignUp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AccountTypes")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("BVN")
                        .HasColumnType("bigint");

                    b.Property<string>("ConfirmPassword")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("varchar(12)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("varchar(12)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("varchar(12)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(28)
                        .HasColumnType("varchar(28)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("SignUps");
                });

            modelBuilder.Entity("BankingAPIs.ModelClass.Transcation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("AmountTransfered")
                        .HasColumnType("double");

                    b.Property<string>("DestinationAccount")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SourceAccount")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("TransDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("TransactionStat")
                        .HasColumnType("int");

                    b.Property<Guid>("TranscationId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("Transcations");
                });
#pragma warning restore 612, 618
        }
    }
}
