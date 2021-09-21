namespace ConferencePlanner.GraphQL.Mutations.Speakers
{
    public record AddSpeakerInput(
        string Name,
        string Bio,
        string WebSite);
}
