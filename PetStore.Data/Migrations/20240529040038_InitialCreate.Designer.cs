﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PetStore.Data;

#nullable disable

namespace PetStore.Data.Migrations
{
    [DbContext(typeof(ProductContext))]
    [Migration("20240529040038_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("PetStore.Data.ProductEntity", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasDiscriminator<string>("Discriminator").HasValue("ProductEntity");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("PetStore.Data.CatFoodEntity", b =>
                {
                    b.HasBaseType("PetStore.Data.ProductEntity");

                    b.Property<bool>("KittenFood")
                        .HasColumnType("INTEGER");

                    b.Property<double>("WeightPounds")
                        .HasColumnType("REAL");

                    b.HasDiscriminator().HasValue("CatFoodEntity");
                });

            modelBuilder.Entity("PetStore.Data.DogLeashEntity", b =>
                {
                    b.HasBaseType("PetStore.Data.ProductEntity");

                    b.Property<int>("LengthInches")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Material")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("DogLeashEntity");
                });
#pragma warning restore 612, 618
        }
    }
}
