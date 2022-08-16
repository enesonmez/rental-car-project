using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// IoC
// builder.Services.AddSingleton<IBrandService,BrandManager>();
// builder.Services.AddSingleton<IBrandDal,EfBrandDal>();
// builder.Services.AddSingleton<ICarService,CarManager>();
// builder.Services.AddSingleton<ICarDal,EfCarDal>();
// builder.Services.AddSingleton<IColorService,ColorManager>();
// builder.Services.AddSingleton<IColorDal,EfColorDal>();
// builder.Services.AddSingleton<ICustomerService,CustomerManager>();
// builder.Services.AddSingleton<ICustomerDal,EfCustomerDal>();
// builder.Services.AddSingleton<IRentalService,RentalManager>();
// builder.Services.AddSingleton<IRentalDal,EfRentalDal>();
// builder.Services.AddSingleton<IUserService,UserManager>();
// builder.Services.AddSingleton<IUserDal,EfUserDal>();
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new AutofacBusinessModule());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey!)
        };
    }
);

builder.Services.AddDependencyResolvers(new ICoreModule[] { new CoreModule()});

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder=>builder.WithOrigins("http://localhost:4200").AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
