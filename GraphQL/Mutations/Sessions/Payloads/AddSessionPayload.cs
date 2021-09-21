using System.Collections.Generic;
using ConferencePlanner.GraphQL.Common;
using ConferencePlanner.GraphQL.Data;

namespace ConferencePlanner.GraphQL.Mutations.Sessions
{
    public class AddSessionPayload : SessionPayloadBase
    {
        public AddSessionPayload(Session session)
            : base(session)
        {
        }

        public AddSessionPayload(UserError error)
            : base(new[] { error })
        {
        } 
    }
}
