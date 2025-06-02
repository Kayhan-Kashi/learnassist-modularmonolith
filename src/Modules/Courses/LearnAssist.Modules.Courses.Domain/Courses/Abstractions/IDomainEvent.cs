namespace LearnAssist.Modules.Courses.Domain.Courses.Abstractions;

public interface IDomainEvent
{
    Guid Id { get; }
    DateTime OccurredOn { get; }
}
