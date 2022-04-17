using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SecureSite_aspNetCoreWebApp_ModelViewControl.Data;

[assembly: HostingStartup(typeof(SecureSite_aspNetCoreWebApp_ModelViewControl.Areas.Identity.IdentityHostingStartup))]
namespace SecureSite_aspNetCoreWebApp_ModelViewControl.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}