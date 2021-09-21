using System.Threading.Tasks;
using ConferencePlanner.GraphQL.Data;
using HotChocolate;
using ConferencePlanner.GraphQL.Extentions;
namespace ConferencePlanner.GraphQL.Mutations.Speakers
{
    public class SpeakersMutation
    {
        [UseApplicationDbContext]
        public async Task<AddSpeakerPayload> AddSpeakerAsync(
            AddSpeakerInput input,
            [ScopedService] ApplicationDbContext context)
        {
            var speaker = new Speaker
            {
                Name = input.Name,
                Bio = input.Bio,
                WebSite = input.WebSite
            };

            context.Speakers.Add(speaker);
            await context.SaveChangesAsync();

            return new AddSpeakerPayload(speaker);
        }
    }
}
