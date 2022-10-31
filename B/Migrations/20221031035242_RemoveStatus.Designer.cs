﻿// <auto-generated />
using B.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace B.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221031035242_RemoveStatus")]
    partial class RemoveStatus
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc.2.22472.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("B.Data.Entities.Division", b =>
                {
                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("ParentName")
                        .HasColumnType("text");

                    b.HasKey("Name");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("ParentName");

                    b.ToTable("divisions", (string)null);
                });

            modelBuilder.Entity("B.Data.Entities.Division", b =>
                {
                    b.HasOne("B.Data.Entities.Division", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentName")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("B.Data.Entities.Division", b =>
                {
                    b.Navigation("Children");
                });
#pragma warning restore 612, 618
        }
    }
}
