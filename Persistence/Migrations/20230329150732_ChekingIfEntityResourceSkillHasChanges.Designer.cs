﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Contexts;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(ResourceDbContext))]
    [Migration("20230329150732_ChekingIfEntityResourceSkillHasChanges")]
    partial class ChekingIfEntityResourceSkillHasChanges
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.Resource", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CurrentClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CurrentClientName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrentPositionDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CurrentPositionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CurrentStateDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CurrentStateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastDateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LocationDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("LocationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NessieID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonalEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResumeUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.Property<Guid>("UserCreatorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserLastModify")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WorkEmail")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Resource");
                });

            modelBuilder.Entity("Domain.Entities.ResourceExtraSkills", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BriefDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExperienceOveralTypeTag")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastDateModified")
                        .HasColumnType("datetime2");

                    b.Property<byte>("Point")
                        .HasColumnType("tinyint");

                    b.Property<string>("ResourceId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserCreatorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserLastModify")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("ResourceExtraSkills");
                });

            modelBuilder.Entity("Domain.Entities.ResourceSkills", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsComplice")
                        .HasColumnType("bit");

                    b.Property<Guid>("ResourceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ResourceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SkillAcceptanceURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SkillId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SkillName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.Property<Guid>("UserCreatorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("ResourceSkills");
                });
#pragma warning restore 612, 618
        }
    }
}
