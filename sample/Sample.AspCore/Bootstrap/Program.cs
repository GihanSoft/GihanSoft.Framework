using GihanSoft.Framework.Web.Bootstrap.Initializers;
using GihanSoft.Framework.Web.Swagger;

using Sample.AspCore.Common.Data;

#pragma warning disable CA1852 // Type 'Program' can be sealed because it has no subtypes in its containing assembly and is not externally visible

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer().AddSwaggerGen(opt =>
{
    opt.CustomSchemaIds(SwaggerSchemaAttributeIdSelector.SchemaSelector);
});

DataServiceSetup.ConfigureServices(builder.Services);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger().UseSwaggerUI();
}

app.MapMinimalEndpoints<Program>();
app.MapDefaultControllerRoute();

await app.RunInitializersAsync<Program>().ConfigureAwait(false);
await app.RunAsync().ConfigureAwait(false);

#pragma warning restore CA1852 // Type 'Program' can be sealed because it has no subtypes in its containing assembly and is not externally visible
