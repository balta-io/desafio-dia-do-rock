using DesafioDiaDoRock.ApplicationCore.Interfaces.Integrations;
using DesafioDiaDoRock.ApplicationCore.Interfaces.Repositories;
using DesafioDiaDoRock.ApplicationCore.Interfaces.Services;
using DesafioDiaDoRock.ApplicationCore.Models.Integrations;
using DesafioDiaDoRock.ApplicationCore.Services;
using DesafioDiaDoRock.Infraestructure.Data;
using DesafioDiaDoRock.Infraestructure.Integrations.Google;
using DesafioDiaDoRock.Infraestructure.Repository;
using DesafioDiaDoRock.PublicApi.Common.Api;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Configuração do DbContext
builder.Services.AddDbContext<ApplicationDbContext>(a => a.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registro de dependências
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IPlacesService, PlacesService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddTransient<TokenService>();

builder.AddConfiguration();

string BackendUrl = Configuration.BackendUrl;
string FrontendUrl = Configuration.FrontendUrl;

builder.AddCrossOrigin();
builder.Services.AddControllers();


// Configuração JWT
builder.Services.AddServiceJwt();
builder.Services.AddTransient<TokenService>();

// Configuração do Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "DesafioDiaDoRock API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Insira o token JWT no campo 'Authorization' usando o prefixo 'Bearer'. Exemplo: Bearer {seu_token_jwt}"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.AddServiceDefaults(); //Classe padrão de serviço, registrado com projeto de API

var app = builder.Build();

// Configuração do pipeline de requisição HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(ApiConfiguration.CorsPolicyName);

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
