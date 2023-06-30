using API.GraphQL;
using GraphQL.Server.Ui.Voyager;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var AllowSpecificOrgins = "_allowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextFactory<OMAContext>(options =>
{
    options.UseInMemoryDatabase("InMemoryDB");
});

builder.Services.AddGraphQLServer()
.AddQueryType<Query>()
.AddFiltering();


builder.Services.AddControllers();

var app = builder.Build();

app.UseCors(AllowSpecificOrgins);

app.MapGraphQL();

app.UseGraphQLVoyager("/graphql-voyager", new VoyagerOptions { GraphQLEndPoint = "/graphql" });

app.Run();
