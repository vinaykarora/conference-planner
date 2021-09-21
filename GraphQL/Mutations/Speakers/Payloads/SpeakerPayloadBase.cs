
using System.Collections.Generic;
using ConferencePlanner.GraphQL.Common;
using ConferencePlanner.GraphQL.Data;

namespace ConferencePlanner.GraphQL.Mutations.Speakers
{
    public class SpeakerPayloadBase : Payload
    {
        protected SpeakerPayloadBase(Speaker speaker)
        {
            Speaker = speaker;
        }

        protected SpeakerPayloadBase(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public Speaker? Speaker { get; }
    }
}
