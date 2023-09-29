using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        // Add other services...

        services.AddDistributedMemoryCache();
        services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(30);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });

        // Add DbContext configuration
        services.AddDbContext<YourDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Other middleware...

        app.UseSession();

        // ...
    }
}
