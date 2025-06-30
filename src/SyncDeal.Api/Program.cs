using SyncDeal.Api.Filters;
using SyncDeal.Api.Middlewares;
using SyncDeal.Application;
using SyncDeal.Infra;
using SyncDeal.Infra.Migrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

await MigrateDatabase(app);

async Task MigrateDatabase(IApplicationBuilder app)
{
    await using var scope = app.ApplicationServices.CreateAsyncScope();

    await DatabaseMigration.MigrateDatabaseAsync(scope.ServiceProvider);

}

app.UseHttpsRedirection();

app.UseMiddleware<CultureMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
