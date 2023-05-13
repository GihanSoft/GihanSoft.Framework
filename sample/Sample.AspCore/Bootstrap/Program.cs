using GihanSoft.Framework.Web.Bootstrap.Initializers;

using Sample.AspCore.Bootstrap;

#pragma warning disable CA1852 // Type 'Program' can be sealed because it has no subtypes in its containing assembly and is not externally visible

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServiceSetups<Program>(new BootstrapServiceProvider(builder));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger().UseSwaggerUI();
}

app.MapMinimalEndpoints<Program>();
app.MapEndpointSetups<Program>();

await app.RunInitializersAsync<Program>().ConfigureAwait(false);
await app.RunAsync().ConfigureAwait(false);

#pragma warning restore CA1852 // Type 'Program' can be sealed because it has no subtypes in its containing assembly and is not externally visible
