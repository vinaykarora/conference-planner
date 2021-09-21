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
namespace ConferencePlanner.GraphQL.Queries.Tracks
{
    [ExtendObjectType(Name = "Query")]
    public class TrackQueries
    {
        [UseApplicationDbContext]
        public Task<List<Track>> GetTracks([ScopedService] ApplicationDbContext context) =>
            context.Tracks.ToListAsync();

        public Task<Track> GetTrackAsync(
            [ID(nameof(Track))] int id,
            TrackByIdDataLoader dataLoader,
            CancellationToken cancellationToken) =>
            dataLoader.LoadAsync(id, cancellationToken);
    }
}
