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
namespace ConferencePlanner.GraphQL.Queries.Attendees
{
    [ExtendObjectType(Name = "Query")]
    public class AttendeeQueries
    {
        [UseApplicationDbContext]
        public Task<List<Attendee>> GetAttendees([ScopedService] ApplicationDbContext context) =>
            context.Attendees.ToListAsync();

        public Task<Attendee> GetAttendeeAsync(
            [ID(nameof(Attendee))] int id,
            AttendeeByIdDataLoader dataLoader,
            CancellationToken cancellationToken) =>
            dataLoader.LoadAsync(id, cancellationToken);
    }
}
