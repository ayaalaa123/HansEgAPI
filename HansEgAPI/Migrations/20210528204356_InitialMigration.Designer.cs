﻿// <auto-generated />
using HansEgAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HansEgAPI.Migrations
{
    [DbContext(typeof(HansContext))]
    [Migration("20210528204356_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("HansEgAPI.Models.Governorate", b =>
                {
                    b.Property<int>("GovernorateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("GovernorateName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GovernorateId");

                    b.ToTable("Governorates");
                });

            modelBuilder.Entity("HansEgAPI.Models.Region", b =>
                {
                    b.Property<int>("RegionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("GovernorateId")
                        .HasColumnType("int");

                    b.Property<string>("RegionName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RegionId");

                    b.HasIndex("GovernorateId");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("HansEgAPI.Models.Region", b =>
                {
                    b.HasOne("HansEgAPI.Models.Governorate", "Governorate")
                        .WithMany()
                        .HasForeignKey("GovernorateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Governorate");
                });
#pragma warning restore 612, 618
        }
    }
}
