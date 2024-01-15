using Demo.HotChocolate.Queries;
using Demo.HotChocolate.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddSingleton<IDbContext, DbContext>();

builder.Services
    .AddGraphQLServer()
    .AddQueryType(x => x.Name("RootQuery"))
    .AddType<QueryBooks>()
    .AddType<QueryAuthors>();

var app = builder.Build();

app.MapGraphQL();

app.Run();
