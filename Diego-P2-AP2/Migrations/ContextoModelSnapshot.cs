﻿// <auto-generated />
using System;
using Diego_P2_AP2.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Diego_P2_AP2.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("Diego_P2_AP2.Models.Clientes", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombres")
                        .HasColumnType("TEXT");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");

                    b.HasData(
                        new
                        {
                            ClienteId = 1,
                            Nombres = "FERRETERIA GAMA"
                        },
                        new
                        {
                            ClienteId = 2,
                            Nombres = "AVALON DISCO"
                        },
                        new
                        {
                            ClienteId = 3,
                            Nombres = "PRESTAMOS CEFIPROD"
                        });
                });

            modelBuilder.Entity("Diego_P2_AP2.Models.Cobros", b =>
                {
                    b.Property<int>("CobroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<string>("Observaciones")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("TotalCobrado")
                        .HasColumnType("TEXT");

                    b.HasKey("CobroId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Cobros");
                });

            modelBuilder.Entity("Diego_P2_AP2.Models.CobrosDetalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Cobrado")
                        .HasColumnType("TEXT");

                    b.Property<int?>("CobroId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("VentaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CobroId");

                    b.HasIndex("VentaId");

                    b.ToTable("CobrosDetalle");
                });

            modelBuilder.Entity("Diego_P2_AP2.Models.Ventas", b =>
                {
                    b.Property<int>("VentaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Balance")
                        .HasColumnType("TEXT");

                    b.Property<int>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Monto")
                        .HasColumnType("TEXT");

                    b.HasKey("VentaId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Ventas");

                    b.HasData(
                        new
                        {
                            VentaId = 1,
                            Balance = 1000m,
                            ClienteId = 1,
                            Fecha = new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Monto = 1000m
                        },
                        new
                        {
                            VentaId = 2,
                            Balance = 800m,
                            ClienteId = 1,
                            Fecha = new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Monto = 900m
                        },
                        new
                        {
                            VentaId = 3,
                            Balance = 2000m,
                            ClienteId = 2,
                            Fecha = new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Monto = 2000m
                        },
                        new
                        {
                            VentaId = 4,
                            Balance = 1800m,
                            ClienteId = 2,
                            Fecha = new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Monto = 1900m
                        },
                        new
                        {
                            VentaId = 5,
                            Balance = 3000m,
                            ClienteId = 3,
                            Fecha = new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Monto = 3000m
                        },
                        new
                        {
                            VentaId = 6,
                            Balance = 1900m,
                            ClienteId = 3,
                            Fecha = new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Monto = 2900m
                        });
                });

            modelBuilder.Entity("Diego_P2_AP2.Models.Cobros", b =>
                {
                    b.HasOne("Diego_P2_AP2.Models.Clientes", "Cliente")
                        .WithMany("Cobro")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Diego_P2_AP2.Models.CobrosDetalle", b =>
                {
                    b.HasOne("Diego_P2_AP2.Models.Cobros", "Cobro")
                        .WithMany("Detalle")
                        .HasForeignKey("CobroId");

                    b.HasOne("Diego_P2_AP2.Models.Ventas", "Venta")
                        .WithMany()
                        .HasForeignKey("VentaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cobro");

                    b.Navigation("Venta");
                });

            modelBuilder.Entity("Diego_P2_AP2.Models.Ventas", b =>
                {
                    b.HasOne("Diego_P2_AP2.Models.Clientes", "Cliente")
                        .WithMany("Venta")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Diego_P2_AP2.Models.Clientes", b =>
                {
                    b.Navigation("Cobro");

                    b.Navigation("Venta");
                });

            modelBuilder.Entity("Diego_P2_AP2.Models.Cobros", b =>
                {
                    b.Navigation("Detalle");
                });
#pragma warning restore 612, 618
        }
    }
}
