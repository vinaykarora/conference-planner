using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConferencePlanner.GraphQL;
using ConferencePlanner.GraphQL.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using ConferencePlanner.GraphQL.Queries.Attendees;
using ConferencePlanner.GraphQL.Queries.Sessions;
using ConferencePlanner.GraphQL.Queries.Speakers;
using ConferencePlanner.GraphQL.Queries.Tracks;

using ConferencePlanner.GraphQL.Mutations.Attendees;
using ConferencePlanner.GraphQL.Mutations.Sessions;
using ConferencePlanner.GraphQL.Mutations.Speakers;
using ConferencePlanner.GraphQL.Mutations.Tracks;

using ConferencePlanner.GraphQL.Subscriptions.Attendees;
using ConferencePlanner.GraphQL.Subscriptions.Sessions;

using ConferencePlanner.GraphQL.DataLoader;
using ConferencePlanner.GraphQL.Types;
namespace ConferencePlanner.GraphQL
{
    public class Startup
    {
        private const string _BlazorClientPolicy = "GraphQL Client App";
        private const string _BlazorClientBaseUri = "http://localhost:5002";

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
             {
                 options.AddPolicy(name: _BlazorClientPolicy,
                                   builder =>
                                   {
                                       builder.WithOrigins(_BlazorClientBaseUri)
                                       .AllowAnyHeader()
                                       .AllowAnyMethod()
                                       .AllowCredentials(); ;
                                   });
             });

            services.AddPooledDbContextFactory<ApplicationDbContext>(options => options.UseSqlite("Data Source=conferences.db"));
            services
                .AddGraphQLServer()
                .AddQueryType(d => d.Name("Query"))
                    .AddTypeExtension<AttendeeQueries>()
                    .AddTypeExtension<SpeakerQueries>()
                    .AddTypeExtension<SessionQueries>()
                    .AddTypeExtension<TrackQueries>()
                .AddMutationType(d => d.Name("Mutation"))
                    .AddTypeExtension<AttendeeMutations>()
                    .AddTypeExtension<SessionMutations>()
                    .AddTypeExtension<SpeakerMutations>()
                    .AddTypeExtension<TrackMutations>()
                .AddSubscriptionType(d => d.Name("Subscription"))
                    .AddTypeExtension<AttendeeSubscriptions>()
                    .AddTypeExtension<SessionSubscriptions>()
                .AddType<AttendeeType>()
                .AddType<SessionType>()
                .AddType<SpeakerType>()
                .AddType<TrackType>()
                .EnableRelaySupport()
                .AddFiltering()
                .AddSorting()
                .AddInMemorySubscriptions()
                .AddDataLoader<SpeakerByIdDataLoader>()
                .AddDataLoader<SessionByIdDataLoader>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseWebSockets();
            app.UseRouting();
            app.UseCors(_BlazorClientPolicy);
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });

        }
    }
}
