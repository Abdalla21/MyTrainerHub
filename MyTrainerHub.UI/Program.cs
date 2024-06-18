using Microsoft.AspNetCore.Identity;
using MyTrainerHub.Core.Domain.Entities;
using MyTrainerHub.UI.ServicesInjectionExtension;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication()
    .AddCookie(IdentityConstants.ApplicationScheme)
    .AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddAuthorization();
builder.Services.AddCORSService();

builder.Services.AddIdentityService();

builder.Services.AddDBContextService(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapIdentityApi<ApplicationUser>();

app.Run();


//  -----------------------------------Creating Backend-----------------------------------
// |             CleanArchitecture            =>                   Done                   |
// |                Minimal APIs                                                          |
// |              Identity Server                                                         |
// |                 Unit Tests                                                           |
// |          TDD - Test Driven Design                                                    |
//  -----------------------------------Creating Frontend----------------------------------
// |                   HTML                                                               |
// |                   CSS                                                                |
// |                JavaScript                                                            |
// |                 Angular                                                              |
//  --------------------------------------------------------------------------------------