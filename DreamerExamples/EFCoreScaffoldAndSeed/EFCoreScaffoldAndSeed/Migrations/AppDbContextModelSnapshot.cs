﻿// <auto-generated />
using System;
using EFCoreModelsAndRelationships.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCoreScaffoldAndSeed.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFCoreMigration.Model.Edition", b =>
                {
                    b.Property<string>("EditionId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ISBN10");

                    b.Property<string>("Type");

                    b.HasKey("EditionId");

                    b.HasIndex("ISBN10");

                    b.ToTable("Edition");
                });

            modelBuilder.Entity("EFCoreModelsAndRelationships.Model.Author", b =>
                {
                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("ImageUrl");

                    b.HasKey("FirstName", "LastName");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            FirstName = "HasDataFName",
                            LastName = "HasDataLName"
                        });
                });

            modelBuilder.Entity("EFCoreModelsAndRelationships.Model.Book", b =>
                {
                    b.Property<int>("ISBN10");

                    b.Property<string>("ISBN13")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<int?>("NextInSeriesISBN10");

                    b.Property<int>("Pages");

                    b.Property<string>("PrimaryAuthor");

                    b.Property<string>("description");

                    b.Property<string>("imgurl");

                    b.Property<int>("price");

                    b.Property<DateTime>("publishedOn");

                    b.Property<string>("title")
                        .IsRequired();

                    b.HasKey("ISBN10");

                    b.HasAlternateKey("ISBN13")
                        .HasName("AlternateKey_ISBN13_UniqueConstraint");

                    b.HasIndex("NextInSeriesISBN10");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            ISBN10 = 1212121212,
                            ISBN13 = "01234567890123456789",
                            Pages = 0,
                            price = 123,
                            publishedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            title = "TheHasDataBook"
                        });
                });

            modelBuilder.Entity("EFCoreModelsAndRelationships.Model.BookAuthor", b =>
                {
                    b.Property<int>("BookAuhtorId");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<int>("ISBN");

                    b.HasKey("BookAuhtorId", "FirstName", "LastName");

                    b.HasIndex("ISBN");

                    b.HasIndex("FirstName", "LastName");

                    b.ToTable("BookAuthors");

                    b.HasData(
                        new
                        {
                            BookAuhtorId = 0,
                            FirstName = "HasDataFName",
                            LastName = "HasDataLName",
                            ISBN = 1212121212
                        });
                });

            modelBuilder.Entity("EFCoreModelsAndRelationships.Model.PriceOffer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookISBN");

                    b.Property<int?>("BookISBN10");

                    b.Property<int>("ISBN");

                    b.Property<int>("NewPrice");

                    b.Property<string>("PromotionText");

                    b.HasKey("Id");

                    b.HasIndex("BookISBN10");

                    b.ToTable("PriceOffers");
                });

            modelBuilder.Entity("EFCoreModelsAndRelationships.Model.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BookISBN10");

                    b.Property<string>("Comment");

                    b.Property<int>("EditionId");

                    b.Property<string>("EditionId1");

                    b.Property<int>("ISBN");

                    b.Property<int>("NumStars");

                    b.Property<DateTime>("ReviewDate");

                    b.Property<string>("VoterName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("BookISBN10");

                    b.HasIndex("EditionId1");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("EFCoreModelsAndRelationships.Model.Voter", b =>
                {
                    b.Property<string>("Firstname");

                    b.Property<string>("LastName");

                    b.Property<string>("Email");

                    b.Property<int>("ReviewId");

                    b.HasKey("Firstname", "LastName");

                    b.HasIndex("ReviewId");

                    b.ToTable("Voter");
                });

            modelBuilder.Entity("EFCoreMigration.Model.Edition", b =>
                {
                    b.HasOne("EFCoreModelsAndRelationships.Model.Book", "Book")
                        .WithMany("Editions")
                        .HasForeignKey("ISBN10")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EFCoreModelsAndRelationships.Model.Book", b =>
                {
                    b.HasOne("EFCoreModelsAndRelationships.Model.Book", "NextInSeries")
                        .WithMany()
                        .HasForeignKey("NextInSeriesISBN10");
                });

            modelBuilder.Entity("EFCoreModelsAndRelationships.Model.BookAuthor", b =>
                {
                    b.HasOne("EFCoreModelsAndRelationships.Model.Book", "Book")
                        .WithMany("BookAuthors")
                        .HasForeignKey("ISBN")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EFCoreModelsAndRelationships.Model.Author", "Author")
                        .WithMany("BookAuthors")
                        .HasForeignKey("FirstName", "LastName")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EFCoreModelsAndRelationships.Model.PriceOffer", b =>
                {
                    b.HasOne("EFCoreModelsAndRelationships.Model.Book", "Book")
                        .WithMany("PriceOffers")
                        .HasForeignKey("BookISBN10");
                });

            modelBuilder.Entity("EFCoreModelsAndRelationships.Model.Review", b =>
                {
                    b.HasOne("EFCoreModelsAndRelationships.Model.Book", "Book")
                        .WithMany("Reviews")
                        .HasForeignKey("BookISBN10");

                    b.HasOne("EFCoreMigration.Model.Edition", "Edition")
                        .WithMany()
                        .HasForeignKey("EditionId1");
                });

            modelBuilder.Entity("EFCoreModelsAndRelationships.Model.Voter", b =>
                {
                    b.HasOne("EFCoreModelsAndRelationships.Model.Review", "Review")
                        .WithMany("Voters")
                        .HasForeignKey("ReviewId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
