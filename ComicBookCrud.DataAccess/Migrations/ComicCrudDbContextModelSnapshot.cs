﻿// <auto-generated />
using ComicBookCrud.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ComicBookCrud.DataAccess.Migrations
{
    [DbContext(typeof(ComicCrudDbContext))]
    partial class ComicCrudDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ComicBookCrud.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 1,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 2,
                            Name = "Sci-Fi"
                        },
                        new
                        {
                            Id = 3,
                            DisplayOrder = 3,
                            Name = "Gritty"
                        });
                });

            modelBuilder.Entity("ComicBookCrud.Models.ComicBook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<double>("CoverPrice")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Issue")
                        .HasColumnType("int");

                    b.Property<double>("ListPrice")
                        .HasColumnType("float");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("ComicBooks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Neil Gaiman & Dave McKean",
                            CategoryId = 1,
                            CoverPrice = 3.5,
                            Description = "Two girls awaken in a greenhouse and encounter DC characters like Batman and Swamp Thing",
                            ImageUrl = "",
                            Issue = 1,
                            ListPrice = 11.99,
                            Publisher = "DC Comics",
                            Title = "Black Orchid: Book One"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Neil Gaiman & Dave McKean",
                            CategoryId = 1,
                            CoverPrice = 3.5,
                            Description = "Black Orchid tries to remember her sister; Carl returns to get revenge on Philip for stealing his woman",
                            ImageUrl = "",
                            Issue = 2,
                            ListPrice = 12.99,
                            Publisher = "DC Comics",
                            Title = "Black Orchid: Book Two"
                        },
                        new
                        {
                            Id = 3,
                            Author = "James Tynion & Fernando Blanco",
                            CategoryId = 2,
                            CoverPrice = 9.9900000000000002,
                            Description = "Issues 1-5 of the infamouse \"w0rldtr33\" series. In 1999, Gabriel and his friends discover the Undernet -- a secret architecture to the Internet.",
                            ImageUrl = "",
                            Issue = 1,
                            ListPrice = 9.9900000000000002,
                            Publisher = "Image Comics",
                            Title = "w0rltr33"
                        });
                });

            modelBuilder.Entity("ComicBookCrud.Models.ComicBook", b =>
                {
                    b.HasOne("ComicBookCrud.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
