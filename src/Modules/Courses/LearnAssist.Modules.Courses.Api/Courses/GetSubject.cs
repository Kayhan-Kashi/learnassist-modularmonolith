using LearnAssist.Modules.Courses.Api.Database;
using Microsoft.EntityFrameworkCore;

namespace LearnAssist.Modules.Courses.Api.Courses;

public static class GetSubject
{
    public static void MapEndPoint(IEndpointRouteBuilder app)
    {
        app.MapGet("subjects/{id}", async (Guid id, CoursesDbContext context) =>
        {
            SubjectResponse? subject = await context.Subjects
                .Where(s => s.Id == id)
                .Select(d => 
                    new SubjectResponse(d.Id, d.Name, d.Description, d.HisDate, d.HisTime))
                .SingleOrDefaultAsync();
            
            return subject is null ? Results.NotFound() : Results.Ok(subject);

        }).WithTags(Tags.Courses);
    }
    
    
}
