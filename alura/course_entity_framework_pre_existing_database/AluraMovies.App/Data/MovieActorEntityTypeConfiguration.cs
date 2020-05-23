using System;
using AluraMovies.App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AluraMovies.App.Data
{
    public class MovieActorEntityTypeConfiguration : IEntityTypeConfiguration<MovieActor>
    {
        public void Configure(EntityTypeBuilder<MovieActor> builder)
        {
            builder
                .ToTable("film_actor");

            builder
                .Property<int>("actor_id");

            builder
                .Property<int>("film_id");

            builder
                .HasKey("actor_id", "film_id");

            builder
                .Property<DateTime>("last_update")
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()");

            builder
                .HasOne(it => it.Actor)
                .WithMany(it => it.Movies)
                .HasForeignKey("actor_id");

            builder
                .HasOne(it => it.Movie)
                .WithMany(it => it.Actors)
                .HasForeignKey("film_id");
        }
    }
}