using System.Data.Common;
using Dapper;
using LearnAssist.Modules.Courses.Api.Courses;
using LearnAssist.Modules.Courses.Application.Abstractions.Data;
using MediatR;

namespace LearnAssist.Modules.Courses.Application.Courses;

public sealed record GetSubjectQuery(Guid Id) : IRequest<SubjectResponse?>; 

internal sealed class GetSubjectQueryHandler(IDbConnectionFactory dbConnectionFactory) : IRequestHandler<GetSubjectQuery, SubjectResponse?>
{
    public async Task<SubjectResponse?> Handle(GetSubjectQuery request, CancellationToken cancellationToken)
    {
        await using DbConnection connection = await dbConnectionFactory.OpenConnectionAsync();
        
        const string sql =
            $""" 
                SELECT 
                    id as {nameof(SubjectResponse.Id)},
                    name as {nameof(SubjectResponse.Name)},
                    description as {nameof(SubjectResponse.Description)},
                FROM courses
                WHERE id = @Id
            """;

        SubjectResponse? subject = await connection.QuerySingleOrDefaultAsync(sql, request);
        return subject;
    }
}
