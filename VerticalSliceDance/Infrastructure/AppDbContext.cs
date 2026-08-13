using Microsoft.EntityFrameworkCore;
using VerticalSliceDance.Domain;

namespace VerticalSliceDance.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<DanceStudio> DanceStudios => Set<DanceStudio>();
        public DbSet<Instructor> Instructors => Set<Instructor>();
        public DbSet<DanceClass> DanceClasses => Set<DanceClass>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Instructor>()
                .HasOne(i => i.DanceStudio)
                .WithMany()
                .HasForeignKey(i => i.StudioId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DanceClass>()
                .HasOne(dc => dc.Instructor)
                .WithMany()
                .HasForeignKey(dc => dc.InstructorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DanceClass>()
                .OwnsOne(dc => dc.Schedule);

            modelBuilder.Entity<DanceStudio>()
                .HasIndex(s => s.Name)
                .IsUnique();

            modelBuilder.Entity<DanceStudio>()
                .Property(s => s.Name)
                .HasMaxLength(150)
                .IsRequired();

            modelBuilder.Entity<Instructor>()
                .Property(i => i.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Instructor>()
                .Property(i => i.LastName)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<DanceClass>()
                .Property(dc => dc.Title)
                .HasMaxLength(150)
                .IsRequired();

            var studioId = Guid.Parse("11111111-1111-1111-1111-111111111111");
            var instructorId1 = Guid.Parse("22222222-2222-2222-2222-222222222222");
            var instructorId2 = Guid.Parse("33333333-3333-3333-3333-333333333333");

            modelBuilder.Entity<DanceStudio>().HasData(
            new DanceStudio { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), Name = "Rhythm Studio", Address = "Bulevar Oslobođenja 12" },
            new DanceStudio { Id = Guid.Parse("11111111-1111-1111-1111-111111111112"), Name = "Salsa Nation", Address = "Narodnog Fronta 45" },
            new DanceStudio { Id = Guid.Parse("11111111-1111-1111-1111-111111111113"), Name = "Urban Dance Hub", Address = "Zmaj Jovina 8" }
            );

            modelBuilder.Entity<Instructor>().HasData(
                new Instructor { Id = Guid.Parse("22222222-2222-2222-2222-222222222221"), FirstName = "Ana", LastName = "Jovanović", StudioId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
                new Instructor { Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), FirstName = "Marko", LastName = "Petrović", StudioId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
                new Instructor { Id = Guid.Parse("22222222-2222-2222-2222-222222222223"), FirstName = "Jovana", LastName = "Nikolić", StudioId = Guid.Parse("11111111-1111-1111-1111-111111111112") },
                new Instructor { Id = Guid.Parse("22222222-2222-2222-2222-222222222224"), FirstName = "Stefan", LastName = "Ilić", StudioId = Guid.Parse("11111111-1111-1111-1111-111111111112") },
                new Instructor { Id = Guid.Parse("22222222-2222-2222-2222-222222222225"), FirstName = "Milica", LastName = "Radovanović", StudioId = Guid.Parse("11111111-1111-1111-1111-111111111113") }
            );

            modelBuilder.Entity<DanceClass>().HasData(
                new DanceClass { Id = Guid.Parse("44444444-4444-4444-4444-444444444441"), Title = "Salsa Beginners", InstructorId = Guid.Parse("22222222-2222-2222-2222-222222222221") },
                new DanceClass { Id = Guid.Parse("44444444-4444-4444-4444-444444444442"), Title = "Salsa Advanced", InstructorId = Guid.Parse("22222222-2222-2222-2222-222222222221") },
                new DanceClass { Id = Guid.Parse("44444444-4444-4444-4444-444444444443"), Title = "Hip Hop Intermediate", InstructorId = Guid.Parse("22222222-2222-2222-2222-222222222222") },
                new DanceClass { Id = Guid.Parse("44444444-4444-4444-4444-444444444444"), Title = "Bachata Beginners", InstructorId = Guid.Parse("22222222-2222-2222-2222-222222222223") },
                new DanceClass { Id = Guid.Parse("44444444-4444-4444-4444-444444444445"), Title = "Kizomba Beginners", InstructorId = Guid.Parse("22222222-2222-2222-2222-222222222224") },
                new DanceClass { Id = Guid.Parse("44444444-4444-4444-4444-444444444446"), Title = "Breakdance Kids", InstructorId = Guid.Parse("22222222-2222-2222-2222-222222222225") }
            );
        }

    }
}
