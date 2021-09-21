using System.Linq;
using HotChocolate;
using ConferencePlanner.GraphQL.Data;

namespace ConferencePlanner.GraphQL.Queries.Speakers
{
    public class SpeakersQuery
    {
        public IQueryable<Speaker> GetSpeakers([Service] ApplicationDbContext context) =>
            context.Speakers;
    }
}
