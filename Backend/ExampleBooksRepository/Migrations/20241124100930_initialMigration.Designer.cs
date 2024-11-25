﻿// <auto-generated />
using System;
using ExampleBooksRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ExampleBooksRepository.Migrations
{
    [DbContext(typeof(MainDbContext))]
    [Migration("20241124100930_initialMigration")]
    partial class initialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ExampleBooksRepository.Entity.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DayOfBirth")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Author", "ExampleBooksApp");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DayOfBirth = new DateTime(1988, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Saskia",
                            LastName = "Esseintes",
                            MiddleName = "des"
                        },
                        new
                        {
                            Id = 2,
                            DayOfBirth = new DateTime(1987, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Matilda",
                            LastName = "Mal",
                            MiddleName = "du"
                        },
                        new
                        {
                            Id = 3,
                            DayOfBirth = new DateTime(1989, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Juliette",
                            LastName = "Wolpertinger",
                            MiddleName = ""
                        });
                });

            modelBuilder.Entity("ExampleBooksRepository.Entity.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("PublisherId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("PublisherId");

                    b.ToTable("Book", "ExampleBooksApp");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            DateCreated = new DateTime(2024, 6, 8, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "learning the basics of programming.",
                            ISBN = "1234567890",
                            PublisherId = 1,
                            Title = "Programming basics"
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 2,
                            DateCreated = new DateTime(2024, 6, 8, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Learning the essentials of Docker and Docker-Compose.",
                            ISBN = "1234567891",
                            PublisherId = 2,
                            Title = "Docker Essentials"
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 3,
                            DateCreated = new DateTime(2024, 6, 8, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "For all of those with nostalgic feelings.",
                            ISBN = "1234567893",
                            PublisherId = 3,
                            Title = "Old School PHP"
                        });
                });

            modelBuilder.Entity("ExampleBooksRepository.Entity.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Publisher", "ExampleBooksApp");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "White Seal Publishing"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Penguin Publishing Inc."
                        },
                        new
                        {
                            Id = 3,
                            Name = "Artic Publishing"
                        });
                });

            modelBuilder.Entity("ExampleBooksRepository.Entity.Book", b =>
                {
                    b.HasOne("ExampleBooksRepository.Entity.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");

                    b.HasOne("ExampleBooksRepository.Entity.Publisher", "Publisher")
                        .WithMany()
                        .HasForeignKey("PublisherId");

                    b.Navigation("Author");

                    b.Navigation("Publisher");
                });
#pragma warning restore 612, 618
        }
    }
}
