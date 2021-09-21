using ConferencePlanner.GraphQL.Data;

namespace ConferencePlanner.GraphQL.Mutations.Speakers
{
    public class AddSpeakerPayload
    {
        public AddSpeakerPayload(Speaker speaker)
        {
            Speaker = speaker;
        }

        public Speaker Speaker { get; }
    }
}
