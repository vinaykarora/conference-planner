using System.Linq;
using ConferencePlanner.GraphQL.Data;
using ConferencePlanner.GraphQL.Extentions;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ConferencePlanner.GraphQL.DataLoader;
using System.Threading;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
namespace ConferencePlanner.GraphQL.Queries.Sessions
{
    [ExtendObjectType(Name = "Query")]
    public class SessionQueries
    {
        [UseApplicationDbContext]
        public Task<List<Session>> GetSessions([ScopedService] ApplicationDbContext context) =>
            context.Sessions.ToListAsync();

        public Task<Session> GetSessionAsync(
            [ID(nameof(Session))] int id,
            SessionByIdDataLoader dataLoader,
            CancellationToken cancellationToken) =>
            dataLoader.LoadAsync(id, cancellationToken);
    }
}
