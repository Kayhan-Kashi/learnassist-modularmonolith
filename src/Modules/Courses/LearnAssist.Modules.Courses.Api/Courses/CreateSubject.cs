using LearnAssist.Modules.Courses.Api.Database;

namespace LearnAssist.Modules.Courses.Api.Courses;

public static class CreateSubject
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("subjects", async (Request request, CoursesDbContext context) =>
        {
            var subject = new Subject
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                CreatedAt = DateTime.UtcNow,
                HisDate =  "14031218",
                HisTime = DateTime.Now.TimeOfDay.ToString()
            };
            
            context.Subjects.Add(subject);
            await context.SaveChangesAsync();
            return Results.Ok(subject.Id);
        }).WithTags(Tags.Courses);
    }

    internal sealed class Request
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string HisTime { get; set; }
        public string HisDate { get; set; }
        public DateTime CreatedAt { get; set; }
    }
    
}
