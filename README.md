# conference-planner
GraphQL on ASP.NET Core

# add a speaker by writing a GraphQL mutation.

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

# Query the names of all the speakers in the database.

query GetSpeakerNames {
  speakers {
    name
  }
}

# Parallel Query the names of all the speakers in the database.
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

# Now try out if the new field works right.

query GetSpecificSpeakerById {
  a: speaker(id: 1) {
    name
  }
  b: speaker(id: 1) {
    name
  }
}

# execute the following query
query GetSpeakerWithSessions {
   speakers {
       name
       sessions {
           title
       }
   }
}
