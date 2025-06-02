namespace LearnAssist.Modules.Courses.Api.Courses;

public sealed record SubjectResponse
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public string HisDate { get; init; }
    public string HisTime { get; init; }
}
