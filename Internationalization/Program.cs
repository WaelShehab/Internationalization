using FluentValidation;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Internationalization
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            ConfigureServices(builder.Services);
            
            WebAssemblyHost host = builder.Build();
            var js = host.Services.GetRequiredService<IJSRuntime>();
            string culture = await js.InvokeAsync<string>("getFromLocalStorage", "culture");

            CultureInfo selectedCulture;

            if (culture == null)
            {
                selectedCulture = new CultureInfo("en-US");
            }
            else
            {
                selectedCulture = new CultureInfo(culture);
            }

            CultureInfo.DefaultThreadCurrentCulture = selectedCulture;
            CultureInfo.DefaultThreadCurrentUICulture = selectedCulture;
            await host.RunAsync();
            //await builder.Build().RunAsync();
        }
        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddLocalization();
            services.AddTransient<IValidator<Student>, StudentValidator>();
            services.AddSingleton<InteropSettings>();
        }
    }
}
