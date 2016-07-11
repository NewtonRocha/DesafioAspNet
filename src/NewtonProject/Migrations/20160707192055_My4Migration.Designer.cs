using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using NewtonProject;

namespace NewtonProject.Migrations
{
    [DbContext(typeof(NewtonProjectContext))]
    [Migration("20160707192055_My4Migration")]
    partial class My4Migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NewtonProject.Models.Atividade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao");

                    b.Property<string>("Name");

                    b.Property<int?>("PessoaId");

                    b.Property<DateTime?>("Termino");

                    b.Property<DateTime?>("inicio");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId");

                    b.ToTable("Atividades");
                });

            modelBuilder.Entity("NewtonProject.Models.Cargo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ClienteId");

                    b.Property<string>("Descricao");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Cargos");
                });

            modelBuilder.Entity("NewtonProject.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("NewtonProject.Models.Perfil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Perfils");
                });

            modelBuilder.Entity("NewtonProject.Models.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Admissao");

                    b.Property<int?>("CargoId");

                    b.Property<int?>("ClienteId");

                    b.Property<DateTime?>("Demissao");

                    b.Property<DateTime>("Nascimento");

                    b.Property<string>("Name");

                    b.Property<int?>("PerfilId");

                    b.HasKey("Id");

                    b.HasIndex("CargoId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("PerfilId");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("NewtonProject.Models.Atividade", b =>
                {
                    b.HasOne("NewtonProject.Models.Pessoa")
                        .WithMany("Atividades")
                        .HasForeignKey("PessoaId");
                });

            modelBuilder.Entity("NewtonProject.Models.Cargo", b =>
                {
                    b.HasOne("NewtonProject.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");
                });

            modelBuilder.Entity("NewtonProject.Models.Pessoa", b =>
                {
                    b.HasOne("NewtonProject.Models.Cargo", "Cargo")
                        .WithMany()
                        .HasForeignKey("CargoId");

                    b.HasOne("NewtonProject.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");

                    b.HasOne("NewtonProject.Models.Perfil", "Perfil")
                        .WithMany()
                        .HasForeignKey("PerfilId");
                });
        }
    }
}
