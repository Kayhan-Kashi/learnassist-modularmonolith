using LearnAssist.Modules.Courses.Domain.Courses.Abstractions;

namespace LearnAssist.Modules.Courses.Domain.Courses.Events;

public sealed class SubjectCreatedDomainEvent(Guid eventId) : DomainEvent
{
    public Guid EventId { get; init; } = eventId;
}
