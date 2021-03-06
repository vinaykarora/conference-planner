# Conference Planner App

Buid GraphQL Server Side using ASP.NET Core and Hot Chocolate

```
dotnet graphql init https://localhost:5001/graphql/ -n ConferenceClient -p GraphQL.Client
```

```
dotnet graphql update -u https://localhost:5001/graphql/ -p GraphQL.Client
```

# Add a speaker by writing a GraphQL mutation.

```
mutation AddSpeaker {
  addSpeaker(input: {
    name: "Speaker Name"
    bio: "Speaker Bio"
    webSite: "http://speaker.website" }) {
    speaker {
      id
    }
  }
}
```

# Query the names of all the speakers in the database.

```
query GetSpeakerNames {
  speakers {
    name
  }
}
```

# Parallel Query the names of all the speakers in the database.

```
query GetSpeakerNamesInParallel {
  a: speakers {
    name
    bio
  }
  b: speakers {
    name
    bio
  }
  c: speakers {
    name
    bio
  }
}
```

# Now try out if the new field works right.

```
query GetSpecificSpeakerById {
  a: speaker(id: 1) {
    name
  }
  b: speaker(id: 1) {
    name
  }
}
```

# Execute the following query

```
query GetSpeakerWithSessions {
   speakers {
       name
       sessions {
           title
       }
   }
}
```

# Add sessions

```
mutation AddSession{
  addSession(input:{
    title: "The tour of c#",
     speakerIds:["U3BlYWtlcgppMQ=="],
  }){
      session {
      id
    }
  }
}
```

# Add new track

```
mutation AddTrack{
  addTrack(input:{
     name:"Track 1",
  }){
       errors {
         code,
         message
       },
        track{
          id
        }
    }
  }
```

# Query Session and speakers

```
query FindSession{
sessions{
   id,
   title,
    abstract,
    duration,
    endTime,
    startTime,
    trackId,
    speakers{
      id,
      name
    }
}
}
```

# Schedule session

```
mutation ScheduleSession{
  scheduleSession(input: {
    sessionId :"U2Vzc2lvbgppMQ==",
    trackId:"VHJhY2sKaTE=",
    startTime:"2021-09-21T13:11:55.00",
    endTime:"2021-09-21T13:13:55.00"
  }){
     errors{
       code,
       message
     },
     session{
       startTime,
       endTime,
       speakers{
         name
       },
       track{
         name
       }
     }
  }
}
```

# Find sessions

```
query FindSession{
    sessions{
      nodes{
      id,
      title,
      track{
        id,
        name
      }
    }
  }
}
```

# Test uppercase middleware

```
{
  tracks {
    name
  }
}
```

# Track paginated query

```
query GetFirstTrack {
  tracksPaginated(first: 1) {
    edges {
      node {
        id
        name
      }
      cursor
    }
    pageInfo {
      startCursor
      endCursor
      hasNextPage
      hasPreviousPage
    }
  }
}
```

# Fetch a specific track and get the first session of this track:

```
query GetTrackWithSessions {
  trackById(id: "VHJhY2sKaTI=") {
    id
    sessions(first: 1) {
      nodes {
        title
      }
    }
  }
}
```

# Get Sessions Containing 'Tour' In Title

```
query GetSessionsContainingTourInTitle {
  sessions(where: { title: { contains: "tour" } }) {
    nodes {
      title
    }
  }
}
```

# Register Attendee

```
mutation RegisterAttendee{
  registerAttendee(input:{
       emailAddress:"vin.aroar@gmail.com",
       firstName:"Vinay",
       lastName:"Arora",
       userName:"vin.aroar"
  }){
    attendee{
      id
    },
    errors{
      code,
      message
    }
  }
}
```

# CheckIn Attendee

```
mutation CheckinAttendee{
  checkInAttendee(input:{
       attendeeId:"QXR0ZW5kZWUKaTE=",
      sessionId:"U2Vzc2lvbgppMQ=="
  }){
    attendee{
      id,
      emailAddress
    },
    errors{
      code,
      message
    }
  }
}
```

# On Session Scheduled

```
subscription {
  onSessionScheduled {
    title
    startTime
  }
}


query GetSessionsAndTracks {
  sessions {
    nodes {
      id
    }
  }
  tracks {
      id
  }
}

mutation ScheduleSession {
  scheduleSession(
    input: {
      sessionId: "U2Vzc2lvbgppMQ=="
      trackId: "VHJhY2sKaTE="
      startTime: "2021-10-01T16:00"
      endTime: "2021-10-01T17:00"
    }
  ) {
    session {
      title
    }
  }
}
```
