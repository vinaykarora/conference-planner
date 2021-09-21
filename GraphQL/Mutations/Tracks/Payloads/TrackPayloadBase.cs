
using System.Collections.Generic;
using ConferencePlanner.GraphQL.Common;
using ConferencePlanner.GraphQL.Data;

namespace ConferencePlanner.GraphQL.Mutations.Tracks
{
    public class TrackPayloadBase : Payload
    {
        public TrackPayloadBase(Track track)
        {
            Track = track;
        }

        public TrackPayloadBase(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public Track? Track { get; }
    }
}
