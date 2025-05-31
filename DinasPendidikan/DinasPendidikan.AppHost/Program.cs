var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.DinasPendidikan_ApiService>("apiservice");
var identityService = builder.AddProject<Projects.Identity_ApiService>("identity-service");
    //.WithReference(builder.AddPostgres("identity-db"));
var dokumenService = builder.AddProject<Projects.DinasPendidikanDokumenService>("dokumen-service");
builder.AddProject<Projects.DinasPendidikan_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(identityService)
    .WithReference(apiService)
    .WithReference(dokumenService);



builder.Build().Run();
