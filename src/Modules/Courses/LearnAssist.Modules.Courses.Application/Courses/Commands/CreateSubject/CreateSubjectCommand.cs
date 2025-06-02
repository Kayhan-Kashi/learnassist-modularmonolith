using MediatR;

namespace LearnAssist.Modules.Courses.Application.Courses;

public sealed record CreateSubjectCommand(string Name, string Description) : IRequest<Guid>;
