using ConferencePlanner.GraphQL.Common;
using ConferencePlanner.GraphQL.Data;

namespace ConferencePlanner.GraphQL.Mutations.Sessions
{
    public class RenameSessionPayload : SessionPayloadBase
    {
        public RenameSessionPayload(Session session)
            : base(session)
        {
        }

        public RenameSessionPayload(UserError error)
            : base(new[] { error })
        {
        }
    }
}
