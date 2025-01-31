﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZapAgenda_api_aspnet.data;

#nullable disable

namespace ZapAgenda_api_aspnet.Migrations
{
    [DbContext(typeof(CoreDBContext))]
    [Migration("20250131131039_AdicionaCpfUsuario")]
    partial class AdicionaCpfUsuario
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("ZapAgenda_api_aspnet.models.Cargo", b =>
                {
                    b.Property<int>("IdCargo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdCargo"));

                    b.Property<string>("NomeCargo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdCargo");

                    b.ToTable("Cargo");

                    b.HasData(
                        new
                        {
                            IdCargo = 1,
                            NomeCargo = "Admin"
                        },
                        new
                        {
                            IdCargo = 2,
                            NomeCargo = "User"
                        },
                        new
                        {
                            IdCargo = 3,
                            NomeCargo = "MaxAdmin"
                        });
                });

            modelBuilder.Entity("ZapAgenda_api_aspnet.models.Empresa", b =>
                {
                    b.Property<int>("IdEmpresa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdEmpresa"));

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("varchar(8)");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)");

                    b.Property<string>("Complemento")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("NomeMunicipio")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Numero")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("varchar(3)");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("TipoEmpresa")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdEmpresa");

                    b.ToTable("Empresa");
                });

            modelBuilder.Entity("ZapAgenda_api_aspnet.models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<string>("Cpf")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("IdCargo")
                        .HasColumnType("int");

                    b.Property<int>("IdEmpresa")
                        .HasColumnType("int");

                    b.Property<string>("NomeInteiro")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("NomeUsuario")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("PerfilBloqueado")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("TentativasLogin")
                        .HasColumnType("int");

                    b.Property<DateTime>("UltimaModificacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("UltimaTentativaFalhaLogin")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("UltimoLogin")
                        .HasColumnType("datetime(6)");

                    b.HasKey("IdUsuario");

                    b.HasIndex("IdCargo");

                    b.HasIndex("IdEmpresa");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("ZapAgenda_api_aspnet.models.Usuario", b =>
                {
                    b.HasOne("ZapAgenda_api_aspnet.models.Cargo", "Cargo")
                        .WithMany("Usuario")
                        .HasForeignKey("IdCargo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ZapAgenda_api_aspnet.models.Empresa", "Empresa")
                        .WithMany("Usuario")
                        .HasForeignKey("IdEmpresa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cargo");

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("ZapAgenda_api_aspnet.models.Cargo", b =>
                {
                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ZapAgenda_api_aspnet.models.Empresa", b =>
                {
                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
