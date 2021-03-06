using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ConferencePlanner.GraphQL.Data;
using ConferencePlanner.GraphQL.Mutations.Attendees;
using ConferencePlanner.GraphQL.Queries.Attendees;
using ConferencePlanner.GraphQL.Types;
using HotChocolate;
using HotChocolate.Execution;
using Snapshooter.Xunit;
using Xunit;

namespace GraphQL.Tests
{
    public class AttendeeTests
    {
        [Fact]
        public async Task Attendee_Schema_Changed()
        {
            // arrange
            // act
            ISchema schema = await new ServiceCollection()
                .AddPooledDbContextFactory<ApplicationDbContext>(
                    options => options.UseInMemoryDatabase("Data Source=conferences.db"))
                .AddGraphQL()
                .AddQueryType(d => d.Name("Query"))
                    .AddTypeExtension<AttendeeQueries>()
                .AddMutationType(d => d.Name("Mutation"))
                    .AddTypeExtension<AttendeeMutations>()
                .AddType<AttendeeType>()
                .AddType<SessionType>()
                .AddType<SpeakerType>()
                .AddType<TrackType>()
                .EnableRelaySupport()
                .BuildSchemaAsync();

            // assert
            schema.Print().MatchSnapshot();
        }

        [Fact]
        public async Task RegisterAttendee()
        {
            // arrange
            IRequestExecutor executor = await new ServiceCollection()
                .AddPooledDbContextFactory<ApplicationDbContext>(
                    options => options.UseInMemoryDatabase("Data Source=conferences.db"))
                .AddGraphQL()
                .AddQueryType(d => d.Name("Query"))
                    .AddTypeExtension<AttendeeQueries>()
                .AddMutationType(d => d.Name("Mutation"))
                    .AddTypeExtension<AttendeeMutations>()
                .AddType<AttendeeType>()
                .AddType<SessionType>()
                .AddType<SpeakerType>()
                .AddType<TrackType>()
                .EnableRelaySupport()
                .BuildRequestExecutorAsync();

            // act
            IExecutionResult result = await executor.ExecuteAsync(@"
                mutation RegisterAttendee {
                    registerAttendee(
                        input: {
                            emailAddress: ""vin.aroar@gmail.com""
                                firstName: ""vinay""
                                lastName: ""arora""
                                userName: ""vinay.arora""
                            })
                    {
                        attendee {
                            id
                        }
                    }
                }");

            // assert
            result.ToJson().MatchSnapshot();
        }

    }
}
