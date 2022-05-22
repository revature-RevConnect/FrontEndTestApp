using SocialAPI.Data.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using SocialAPI.Controllers;

var builder = WebApplication.CreateBuilder(args);
//using var loggerFactory = LoggerFactory.Create(loggingBuilder => loggingBuilder.SetMinimumLevel(LogLevel.Trace).AddConsole());
//ILogger<Program> logger = loggerFactory.CreateLogger<Program>();
//logger.LogInformation("test");

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        builder =>
        {
            builder.SetIsOriginAllowed(origin=> true)
                   .AllowAnyMethod()
                   .AllowAnyHeader()
                   .AllowCredentials();
        });
});



//sets controllers to need authentication to process http requests
builder.Services.AddControllers(options =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
    options.Filters.Add(new AuthorizeFilter(policy));
});

//Adds authentication and sets authority and audience from Auth0
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.Authority = "https://dev-d63d2wc5.us.auth0.com/";
    options.Audience = "https://TestRevConnect/api";
});

//Adding Auth0 Config to Swagger
builder.Services.AddSwaggerGen(c =>
{
c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyProject", Version = "v1.0.0" });

var securitySchema = new OpenApiSecurityScheme()
{
    Description = "Using the Authorization header with the Bearer scheme.",
    Name = "Authorization",
    In = ParameterLocation.Header,
    Type = SecuritySchemeType.Http,
    Scheme = "bearer",
    Reference = new OpenApiReference
    {
        Type = ReferenceType.SecurityScheme,
        Id = "Bearer"
    }
};

c.AddSecurityDefinition("Bearer", securitySchema);

c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {securitySchema, new[] { "Bearer" } }
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

string connection = builder.Configuration.GetConnectionString("RevConnectPhoto");
//string connection = builder.Configuration.GetConnectionString("Photo");

//sets up blobconfig needed to access blob storage in photoscontroller
builder.Services.AddSingleton<BlobConfig>(_ => new BlobConfig()
{
    _connection = connection
});


//Adds DBContext and makes conencciton to SQL server
builder.Services.AddDbContext<SocialContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TestRevConnect"));
    //options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();
app.Run();
