using System;
using AluraMovies.App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AluraMovies.App.Data
{
    public class ActorEntityTypeConfiguration : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder
                .ToTable("actor");

            builder
                .HasKey(it => it.Id);

            builder
                .Property(it => it.Id)
                .HasColumnName("actor_id");

            builder
                .Property(it => it.FirstName)
                .HasColumnName("first_name")
                .HasColumnType("varchar(45)")
                .IsRequired();

            builder
                .Property(it => it.LastName)
                .HasColumnName("last_name")
                .HasColumnType("varchar(45)")
                .IsRequired();

            builder
                .Property<DateTime>("last_update")
                .HasColumnType("datetime");
        }
    }
}
