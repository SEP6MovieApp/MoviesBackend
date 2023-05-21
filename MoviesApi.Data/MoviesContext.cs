﻿using Microsoft.EntityFrameworkCore;
using MoviesApi.Data.Models;

namespace MoviesApi.Data;

public class MoviesContext : DbContext, IMoviesContext
{
    public MoviesContext(DbContextOptions options) : base(options)
    {
        Database.Migrate();
    }

    public DbSet<FavoriteMovie> FavoriteMovies { get; set; } = null!;
    public DbSet<Favorites> Favorites { get; set; } = null!;
    public DbSet<Rating> Ratings { get; set; } = null!;
    public DbSet<RatedMovie> RatedMovies { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //creating a composite primary key
        modelBuilder.Entity<Favorites>()
            .HasKey(x => new {x.FavoriteMovieId, x.UserId});

        //this is the primary key but not autogenerated using fluent api
        modelBuilder.Entity<FavoriteMovie>()
            .Property(p => p.FavoriteMovieId)
            .ValueGeneratedNever();
        
        modelBuilder.Entity<RatedMovie>()
            .HasKey(rm => new {rm.RatedMovieId, rm.UserId});
        
        modelBuilder.Entity<Rating>()
            .Property(p => p.MovieId)
            .ValueGeneratedNever();

        base.OnModelCreating(modelBuilder);
    }
}