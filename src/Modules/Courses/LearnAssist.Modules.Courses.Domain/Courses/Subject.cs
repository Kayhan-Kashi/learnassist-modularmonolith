using LearnAssist.Modules.Courses.Domain.Courses.Abstractions;
using LearnAssist.Modules.Courses.Domain.Courses.Events;

namespace LearnAssist.Modules.Courses.Domain.Courses;

public sealed class Subject : Entity
{
    private Subject()
    {
        
    }

    private Subject(Guid id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }
    
    public string Name { get; private set; }
    public string Description { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public static Subject Create(
        string name,        
        string description)
    {
        Subject subject = new Subject(Guid.NewGuid(), name, description);
        subject.Raise(new SubjectCreatedDomainEvent(subject.Id));
        
        return subject;
    }
}
