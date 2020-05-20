using AluraMovies.App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AluraMovies.App.Data
{
    public class MovieEntityTypeConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder
                .ToTable("film");

            builder
                .HasKey(it => it.Id);

            builder
                .Property(it => it.Id)
                .HasColumnName("film_id");

            builder
                .Property(it => it.Title)
                .HasColumnName("title")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder
                .Property(it => it.Description)
                .HasColumnName("description")
                .HasColumnType("text");

            builder
                .Property(it => it.ReleaseYear)
                .HasColumnName("release_year")
                .HasColumnType("varchar(4)");

            builder
                .Property(it => it.Length)
                .HasColumnName("length")
                .HasColumnType("smallint");

            builder
                .Property(it => it.Rating)
                .HasColumnName("rating")
                .HasColumnType("varchar(10)");
        }
    }
}
