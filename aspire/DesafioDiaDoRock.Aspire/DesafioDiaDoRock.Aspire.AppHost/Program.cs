using Projects;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<DesafioDiaDoRock_PublicApi>("DesafioDiaDoRockApi");
builder.AddProject<DesafioDiaDoRock_UI>("DesafioDiaDoRockUI");

builder.Build().Run();