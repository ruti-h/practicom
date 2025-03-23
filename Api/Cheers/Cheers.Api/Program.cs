using Amazon.Extensions.NETCore.Setup;
using Amazon.S3;
using Cheers.Api;
using Cheers.Core;
using Cheers.Core.IRepository;
using Cheers.Core.IServices;
using Cheers.Data;
using Cheers.Data.Repositories;
using Cheers.Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

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

builder.Services.AddDefaultAWSOptions(builder.Configuration.GetAWSOptions());
builder.Services.AddSingleton<IAmazonS3>(serviceProvider =>
{
    var options = serviceProvider.GetRequiredService<IOptions<AWSOptions>>().Value;

    // הגדרת Credentials באופן ידני
    var credentials = new Amazon.Runtime.BasicAWSCredentials(
        builder.Configuration["AWS:AccessKey"],
        builder.Configuration["AWS:SecretKey"]
    );

    // הגדרת Region
    var region = Amazon.RegionEndpoint.GetBySystemName(builder.Configuration["AWS:Region"]);

    return new AmazonS3Client(credentials, region);
});



// הוספת JWT Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

// הוספת הרשאות מבוססות-תפקידים
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
    options.AddPolicy("MatchmakerOrAdmin", policy => policy.RequireRole("Matchmaker", "Admin"));
    options.AddPolicy("MaleOrMatchmaker", policy => policy.RequireRole("Male", "Matchmaker"));
    options.AddPolicy("WomenOrMatchmaker", policy => policy.RequireRole("Women", "Matchmaker"));
});
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
