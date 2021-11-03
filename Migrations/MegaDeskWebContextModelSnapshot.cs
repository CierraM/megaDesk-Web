﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace megaDesk_Web.Migrations
{
    [DbContext(typeof(MegaDeskWebContext))]
    partial class MegaDeskWebContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("megaDesk_Web.Models.Delivery", b =>
                {
                    b.Property<int>("DeliveryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("lessThan1000Price")
                        .HasColumnType("INTEGER");

                    b.Property<int>("lessThan2000Price")
                        .HasColumnType("INTEGER");

                    b.Property<int>("moreThan2000Price")
                        .HasColumnType("INTEGER");

                    b.HasKey("DeliveryId");

                    b.ToTable("Delivery");
                });

            modelBuilder.Entity("megaDesk_Web.Models.Desk", b =>
                {
                    b.Property<int>("DeskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Depth")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DesktopMaterialId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumberOfDrawers")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SurfaceArea")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Width")
                        .HasColumnType("INTEGER");

                    b.HasKey("DeskId");

                    b.HasIndex("DesktopMaterialId");

                    b.ToTable("Desk");
                });

            modelBuilder.Entity("megaDesk_Web.Models.DeskQuote", b =>
                {
                    b.Property<int>("DeskQuoteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CustomerName")
                        .HasColumnType("TEXT");

                    b.Property<int>("DeliveryId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DeskId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("QuoteDate")
                        .HasColumnType("TEXT");

                    b.HasKey("DeskQuoteID");

                    b.HasIndex("DeliveryId");

                    b.HasIndex("DeskId");

                    b.ToTable("DeskQuote");
                });

            modelBuilder.Entity("megaDesk_Web.Models.DesktopMaterial", b =>
                {
                    b.Property<int>("DesktopMaterialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaterialName")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Price")
                        .HasColumnType("INTEGER");

                    b.HasKey("DesktopMaterialId");

                    b.ToTable("DesktopMaterial");
                });

            modelBuilder.Entity("megaDesk_Web.Models.Desk", b =>
                {
                    b.HasOne("megaDesk_Web.Models.DesktopMaterial", "DesktopMaterial")
                        .WithMany()
                        .HasForeignKey("DesktopMaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DesktopMaterial");
                });

            modelBuilder.Entity("megaDesk_Web.Models.DeskQuote", b =>
                {
                    b.HasOne("megaDesk_Web.Models.Delivery", "Delivery")
                        .WithMany()
                        .HasForeignKey("DeliveryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("megaDesk_Web.Models.Desk", "Desk")
                        .WithMany()
                        .HasForeignKey("DeskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Delivery");

                    b.Navigation("Desk");
                });
#pragma warning restore 612, 618
        }
    }
}
