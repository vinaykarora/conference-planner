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
namespace ConferencePlanner.GraphQL.Queries.Speakers
{
    [ExtendObjectType(Name = "Query")]
    public class SpeakerQueries
    {
        [UseApplicationDbContext]
        public Task<List<Speaker>> GetSpeakers([ScopedService] ApplicationDbContext context) =>
            context.Speakers.ToListAsync();

        public Task<Speaker> GetSpeakerAsync(
            [ID(nameof(Speaker))] int id,
            SpeakerByIdDataLoader dataLoader,
            CancellationToken cancellationToken) =>
            dataLoader.LoadAsync(id, cancellationToken);
    }
}
