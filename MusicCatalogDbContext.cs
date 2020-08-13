using ICT_Operator_App.Model;
using ICT_Operator_App.Model.JWTAuth;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ICT_Operator_App {
  public class MusicCatalogDbContext : DbContext {
    public MusicCatalogDbContext(DbContextOptions<MusicCatalogDbContext> options) : base(options) { }
    public DbSet<Song> Songs { get; set; }
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Album> Albums { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<SongTag> SongsTags { get; set; }
    public DbSet<LocalUser> LocalUsers { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      modelBuilder.Entity<SongTag>().HasKey(sc => new { sc.SongId, sc.TagId });
    }
  }
}
