﻿// <auto-generated />
using System;
using Indivis.Infrastructure.Persistence.EntityFramework.IndivisContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Indivis.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(IndivisContext))]
    [Migration("20240130210300_NewTablePage")]
    partial class NewTablePage
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Indivis.Core.Domain.Entities.CoreEntities.Language", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(0);

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnOrder(3);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(998);

                    b.Property<string>("Culture")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnOrder(5);

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(6);

                    b.Property<string>("FLag")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnOrder(7);

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(999);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnOrder(1);

                    b.Property<byte>("Sort")
                        .HasColumnType("tinyint")
                        .HasColumnOrder(8);

                    b.Property<byte>("State")
                        .HasColumnType("tinyint")
                        .HasColumnOrder(9999);

                    b.HasKey("Id");

                    b.ToTable("Language", (string)null);
                });

            modelBuilder.Entity("Indivis.Core.Domain.Entities.CoreEntities.ManyToMany.Url_UrlSystemType", b =>
                {
                    b.Property<Guid>("UrlId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UrlSystemTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UrlId", "UrlSystemTypeId");

                    b.HasIndex("UrlSystemTypeId");

                    b.ToTable("Url_UrlSystemType");
                });

            modelBuilder.Entity("Indivis.Core.Domain.Entities.CoreEntities.Page", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(0);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(998);

                    b.Property<Guid>("LanguageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(999);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<byte>("State")
                        .HasColumnType("tinyint")
                        .HasColumnOrder(9999);

                    b.Property<Guid>("UrlId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.HasIndex("UrlId")
                        .IsUnique();

                    b.ToTable("Page");
                });

            modelBuilder.Entity("Indivis.Core.Domain.Entities.CoreEntities.Url", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(0);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(998);

                    b.Property<string>("FullPath")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<Guid>("LanguageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(999);

                    b.Property<Guid?>("ParentUrlId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<byte>("State")
                        .HasColumnType("tinyint")
                        .HasColumnOrder(9999);

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.HasIndex("ParentUrlId");

                    b.ToTable("Url", (string)null);
                });

            modelBuilder.Entity("Indivis.Core.Domain.Entities.CoreEntities.UrlSystemType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(0);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(998);

                    b.Property<string>("InterfaceType")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(999);

                    b.Property<byte>("State")
                        .HasColumnType("tinyint")
                        .HasColumnOrder(9999);

                    b.HasKey("Id");

                    b.ToTable("UrlSystemType");
                });

            modelBuilder.Entity("Indivis.Core.Domain.Entities.CoreEntities.ManyToMany.Url_UrlSystemType", b =>
                {
                    b.HasOne("Indivis.Core.Domain.Entities.CoreEntities.Url", "Url")
                        .WithMany("Url_UrlSystemTypes")
                        .HasForeignKey("UrlId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Indivis.Core.Domain.Entities.CoreEntities.UrlSystemType", "UrlSystemType")
                        .WithMany("Url_UrlSystemTypes")
                        .HasForeignKey("UrlSystemTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Url");

                    b.Navigation("UrlSystemType");
                });

            modelBuilder.Entity("Indivis.Core.Domain.Entities.CoreEntities.Page", b =>
                {
                    b.HasOne("Indivis.Core.Domain.Entities.CoreEntities.Language", null)
                        .WithMany()
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Indivis.Core.Domain.Entities.CoreEntities.Url", "Url")
                        .WithOne()
                        .HasForeignKey("Indivis.Core.Domain.Entities.CoreEntities.Page", "UrlId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Url");
                });

            modelBuilder.Entity("Indivis.Core.Domain.Entities.CoreEntities.Url", b =>
                {
                    b.HasOne("Indivis.Core.Domain.Entities.CoreEntities.Language", null)
                        .WithMany()
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Indivis.Core.Domain.Entities.CoreEntities.Url", "ParentUrl")
                        .WithMany("SubUrls")
                        .HasForeignKey("ParentUrlId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("ParentUrl");
                });

            modelBuilder.Entity("Indivis.Core.Domain.Entities.CoreEntities.Url", b =>
                {
                    b.Navigation("SubUrls");

                    b.Navigation("Url_UrlSystemTypes");
                });

            modelBuilder.Entity("Indivis.Core.Domain.Entities.CoreEntities.UrlSystemType", b =>
                {
                    b.Navigation("Url_UrlSystemTypes");
                });
#pragma warning restore 612, 618
        }
    }
}
