var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.pos_api>("pos-api");

builder.Build().Run();
