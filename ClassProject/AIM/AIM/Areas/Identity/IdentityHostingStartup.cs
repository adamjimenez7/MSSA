using System;
using AIM.Areas.Identity.Data;
using AIM.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(AIM.Areas.Identity.IdentityHostingStartup))]
namespace AIM.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AIMContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AIMContextConnection")));

                //services.AddDefaultIdentity<AIMUser>(options => options.SignIn.RequireConfirmedAccount = true) ***Already created in startup
                //    .AddEntityFrameworkStores<AIMContext>();
            });
        }
    }
}