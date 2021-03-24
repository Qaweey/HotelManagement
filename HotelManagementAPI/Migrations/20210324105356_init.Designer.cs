﻿// <auto-generated />
using HotelManagementAPI.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HotelManagementAPI.Migrations
{
    [DbContext(typeof(HotelDBContext))]
    [Migration("20210324105356_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HotelManagementAPI.DataModel.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("HotelManagementAPI.DataModel.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("RoomNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoomtypeId")
                        .HasColumnType("int");

                    b.HasKey("RoomId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("RoomtypeId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("HotelManagementAPI.DataModel.Roomtype", b =>
                {
                    b.Property<int>("RoomtypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoomType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoomtypeId");

                    b.ToTable("Roomtypes");
                });

            modelBuilder.Entity("HotelManagementAPI.DataModel.Room", b =>
                {
                    b.HasOne("HotelManagementAPI.DataModel.Customer", "Customer")
                        .WithMany("ListOfRoom")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelManagementAPI.DataModel.Roomtype", "Rometype")
                        .WithMany("Room")
                        .HasForeignKey("RoomtypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Rometype");
                });

            modelBuilder.Entity("HotelManagementAPI.DataModel.Customer", b =>
                {
                    b.Navigation("ListOfRoom");
                });

            modelBuilder.Entity("HotelManagementAPI.DataModel.Roomtype", b =>
                {
                    b.Navigation("Room");
                });
#pragma warning restore 612, 618
        }
    }
}