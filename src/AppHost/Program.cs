var builder = DistributedApplication.CreateBuilder(args);

var ui = builder.AddProject<Projects.UI>("ui");

builder.Build().Run();
