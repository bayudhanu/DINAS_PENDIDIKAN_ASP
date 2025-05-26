var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.DinasPendidikan_ApiService>("apiservice");
var identityApi = builder.AddProject<Projects.Identity_ApiService>("identity-service");
    //.WithReference(builder.AddPostgres("identity-db"));
builder.AddProject<Projects.DinasPendidikan_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(identityApi)
    .WithReference(apiService);

builder.Build().Run();
