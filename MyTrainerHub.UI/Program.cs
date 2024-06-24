using Microsoft.AspNetCore.Identity;
using MyTrainerHub.Core.Domain.Entities;
using MyTrainerHub.Core.DTOs.RegistrationDTOs;
using MyTrainerHub.Infrastructure.DtoExtension;
using MyTrainerHub.UI.ServicesInjectionExtension;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication()
    .AddCookie(IdentityConstants.ApplicationScheme)
    .AddBearerToken(IdentityConstants.BearerScheme);

builder.Services.AddAuthorization();
builder.Services.AddCorsService();

builder.Services.AddIdentityService();

builder.Services.AddDbContextService(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapIdentityApi<ApplicationUser>();

app.MapPost("RegisterV2", async (HttpContext http, UserManager<ApplicationUser> usrManager, RegisterDto regDto) =>
{
    IdentityResult result = regDto.ValidateUser();

    if (!result.Succeeded)
    {
        http.Response.StatusCode = 400;
    }
    else
    {
        ApplicationUser appUsr = regDto.ToUser();

        result = await usrManager.CreateAsync(appUsr, regDto.Password);

        http.Response.StatusCode = result.Succeeded ? 200 : 400;
    }

    return result;
});

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