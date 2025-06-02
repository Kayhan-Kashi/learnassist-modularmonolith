using System.Globalization;
using LearnAssist.Modules.Courses.Api.Courses;
using LearnAssist.Modules.Courses.Application.Abstractions.Data;
using LearnAssist.Modules.Courses.Domain.Courses;
using LearnAssist.Modules.Courses.Domain.Courses.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace LearnAssist.Modules.Courses.Api.Database;

public sealed class CoursesDbContext(DbContextOptions<CoursesDbContext> options) : DbContext(options), IUnitOfWork
{
    internal DbSet<Subject> Subjects { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Courses);
    }
    
    public override int SaveChanges()
    {
        foreach (var entry in ChangeTracker.Entries<Entity>())
        {
            if (entry.State == EntityState.Added)
            {
                PersianCalendar persianCalendar = new PersianCalendar();
                DateTime now = DateTime.UtcNow;

                int year = persianCalendar.GetYear(now);
                int month = persianCalendar.GetMonth(now);
                int day = persianCalendar.GetDayOfMonth(now);

                entry.Entity.HisDate = $"{year:0000}-{month:00}-{day:00}";
                entry.Entity.HisTime = now.ToString("HH:mm:ss"); // Keep time
            }
        }

        return base.SaveChanges();
    }
}   

internal static class Schemas
{
    internal const string Courses = "courses";
}
