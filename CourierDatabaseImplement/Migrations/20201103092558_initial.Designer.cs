﻿// <auto-generated />
using System;
using CourierDatabaseImplement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CourierDatabaseImplement.Migrations
{
    [DbContext(typeof(CourierDatabase))]
    [Migration("20201103092558_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CourierDatabaseImplement.Models.DeliveryAct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CourierFIO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DeliveryType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("DeliveryActs");
                });
#pragma warning restore 612, 618
        }
    }
}
