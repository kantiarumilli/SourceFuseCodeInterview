using AcmeCorp.ContactInfo.Abstract.Facade;
using AcmeCorp.ContactInfo.Abstract.Services;
using AcmeCorp.ContactInfo.API.Infrastructure;
using AcmeCorp.ContactInfo.Entities.BO;
using AcmeCorp.ContactInfo.Entities.DBO;
using AcmeCorp.ContactInfo.Facade;
using AcmeCorp.ContactInfo.Services;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

try
{
    var env = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT");

    var cfgBldr = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env}.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables();

    var mapperConfig = new MapperConfiguration((cfg) =>
    {
        cfg.CreateMap<ContactBO, ContactDBO>().ReverseMap();
        cfg.CreateMap<OrderDBO, OrderDBO>().ReverseMap();
    });

    var mapper = mapperConfig.CreateMapper();
    var config = cfgBldr.Build();
    var connStr = config.GetConnectionString("CONTACTS_CONNECTIONSTRING");
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddSingleton<IConfiguration>(config);
    builder.Services.AddSingleton<IMapper>(mapper);

    builder.Services.AddScoped<IContactFacade, ContactFacade>();
    builder.Services.AddScoped<IOrderFacade, OrderFacade>();
    builder.Services.AddScoped<IContactDBService, ContactDBService>();
    builder.Services.AddScoped<IOrderDBService, OrderDBService>();

    builder.Services.AddDbContext<ContactInfoContext>((o) =>
    {
        o.UseSqlServer(connStr);
    });

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseMiddleware<ApiKeyMiddleware>();
    //app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception e)
{

}