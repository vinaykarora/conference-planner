using ConferencePlanner.GraphQL.Data;
using HotChocolate.Types.Relay;

namespace ConferencePlanner.GraphQL.Mutations.Sessions
{
    public record RenameSessionInput([ID(nameof(Session))] int SessionId, string Title);
}
