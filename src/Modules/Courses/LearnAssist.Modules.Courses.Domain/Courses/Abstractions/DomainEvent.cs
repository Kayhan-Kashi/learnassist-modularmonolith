namespace LearnAssist.Modules.Courses.Domain.Courses.Abstractions;

public abstract class DomainEvent : IDomainEvent
{
    protected DomainEvent()
    {
        Id = Guid.NewGuid();
        OccurredOn = DateTime.UtcNow;
    }

    protected DomainEvent(Guid id, DateTime occurredOn)
    {
        Id = id;
        OccurredOn = occurredOn;
    }
    
    public Guid Id { get; }
    public DateTime OccurredOn { get; }
}

