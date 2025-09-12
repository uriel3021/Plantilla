using Aspire.Hosting;
var builder = DistributedApplication.CreateBuilder(args);

builder.AddContainer("grafana", "grafana/grafana")
    .WithBindMount("../../../compose/grafana/config", "/etc/grafana", isReadOnly: true)
    .WithBindMount("../../../compose/grafana/dashboards", "/var/lib/grafana/dashboards", isReadOnly: true)
    .WithHttpEndpoint(port: 3000, targetPort: 3000, name: "http");

builder.AddContainer("prometheus", "prom/prometheus")
    .WithBindMount("../../../compose/prometheus", "/etc/prometheus", isReadOnly: true)
    .WithHttpEndpoint(port: 9090, targetPort: 9090);

var database = builder.AddSqlServer("db")
    .WithDataVolume()
    .WithEnvironment("ACCEPT_EULA", "Y")
    .WithEnvironment("MSSQL_PID", "Express")
    .WithEnvironment("MSSQL_COLLATION", "SQL_Latin1_General_CP1_CI_AS")
    .WithEnvironment("MSSQL_TCP_PORT", "1433")
    .WithEnvironment("MSSQL_USER", "admin")
    .WithEnvironment("MSSQL_PASSWORD", "admin")

    .AddDatabase("fullstackhero");

builder.AddProject<Projects.Server>("webapi")
    .WaitFor(database);

builder.AddProject<Projects.Client>("blazor");

using var app = builder.Build();
await app.RunAsync();
