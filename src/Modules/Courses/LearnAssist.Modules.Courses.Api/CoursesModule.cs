using LearnAssist.Modules.Courses.Api.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LearnAssist.Modules.Courses.Api.Courses;

public static class CoursesModule
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        CreateSubject.MapEndpoint(app);
        GetSubject.MapEndPoint(app);
    }

    public static IServiceCollection AddCoursesModule(this IServiceCollection services, IConfiguration configuration)
    {
        string databaseConnectionString = configuration.GetConnectionString("Database")!;
        services.AddDbContext<CoursesDbContext>(options => 
            options.UseNpgsql(
                databaseConnectionString,
                npgsqlOptions => npgsqlOptions
                    .MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Courses))
                .UseSnakeCaseNamingConvention());
        return services;
    }
}

