using Cheers.Api;
using Cheers.Core;
using Cheers.Core.IRepository;
using Cheers.Core.IServices;
using Cheers.Data;
using Cheers.Data.Repositories;
using Cheers.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(MappingProfilePostModel));
builder.Services.AddAutoMapper(typeof(MapperProfile), typeof(MappingProfilePostModel));

// רישום ה-DataContext
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer("Data Source=DESKTOP-SSNMLFD;Initial Catalog=ImageDesign;Integrated Security=false; Trusted_Connection=SSPI; MultipleActiveResultSets=true; TrustServerCertificate=true"));

// רישום ה-repositories
builder.Services.AddScoped<IRepositoryMeeting, RepositoryMeeting>();
builder.Services.AddScoped<IRepositoryMatchmaker, RepositoryMatchMaker>();
builder.Services.AddScoped<IRepositoryMatchMaking, RepositoryMatchMaking>();
builder.Services.AddScoped<IRepositoryMale, RepositoryMale>();
builder.Services.AddScoped<IRepositoryWoman, RepositortWoman>();
builder.Services.AddScoped<IRepositoryFamilyDetail, RepositoryFamilyDetail>();
builder.Services.AddScoped<IRepositoryContacts, RepositoryContact>();

// רישום השירותים
builder.Services.AddScoped<IServiceContacts, ContactsService>();
builder.Services.AddScoped<IServiceFamiltDetail, FamilyDetailService>();
builder.Services.AddScoped<IServiceMale, MaleService>();
builder.Services.AddScoped<IServiceMatchMaking, MatchMakingService>();
builder.Services.AddScoped<IServiceMatchMaker, MatchMakerService>();
builder.Services.AddScoped<IServiceMeeting, MeetingService>();
builder.Services.AddScoped<IServiceWoman, WomanService>();

// רישום Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ImageDesign API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ImageDesign API V1");
        c.RoutePrefix = string.Empty;
    });
}

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
