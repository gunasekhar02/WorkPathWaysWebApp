using WorkPathways.WorkPathways.DataAccess.Services;
using WorkPathways.WorkPathways.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<UserService>();
builder.Services.AddSingleton<UserDataAccessService>();
builder.Services.AddSingleton<ExperianceService>();
builder.Services.AddSingleton<ExperianceDataAccessService>();
builder.Services.AddSingleton<AccomplishmentsService>();
builder.Services.AddSingleton<AccomplishmentsDataAccessService>();
builder.Services.AddSingleton<DesiredCompaniesService>();
builder.Services.AddSingleton<DesiredCompaniesDataAccessService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseDeveloperExceptionPage();

app.UseAuthorization();

app.MapControllers();

app.Run();
