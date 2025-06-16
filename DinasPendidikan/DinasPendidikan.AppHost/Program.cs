var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.DinasPendidikan_ApiService>("api-service");
var identityService = builder.AddProject<Projects.Identity_ApiService>("identity-service");
    //.WithReference(builder.AddPostgres("identity-db"));
var dokumenService = builder.AddProject<Projects.DinasPendidikanDokumenService>("dokumen-service");
var asetService = builder.AddProject<Projects.DinasPendidikan_AsetService>("aset-service");
var lpjService = builder.AddProject<Projects.DinasPendidikan_LpjService>("lpj-service");
var schedulerService = builder.AddProject<Projects.DinasPendidikan_SchedulerService>("scheduler-service");
builder.AddProject<Projects.DinasPendidikan_Web>("web-frontend")
    .WithExternalHttpEndpoints()
    .WithReference(identityService)
    .WithReference(apiService)
    .WithReference(dokumenService)
    .WithReference(asetService)
    .WithReference(lpjService)
    .WithReference(schedulerService);

builder.Build().Run();
