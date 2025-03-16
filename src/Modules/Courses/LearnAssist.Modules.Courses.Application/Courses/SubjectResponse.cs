namespace LearnAssist.Modules.Courses.Api.Courses;

public sealed record SubjectResponse(
    Guid Id,
    string Name,
    string Description,
    string HisDate,
    string HisTime
);
