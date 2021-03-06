﻿namespace BlazorExample
{
    using BlazorExample.CLI.Services;
    using Microsoft.Extensions.DependencyInjection;
    using Typin;
    using Typin.Directives;

    public class CliStartup : ICliStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Register services
            services.AddSingleton<IWebHostRunnerService, WebHostRunnerService>()
                    .AddSingleton<IBackgroundWebHostProvider, BackgroundWebHostProvider>();
        }

        public void Configure(CliApplicationBuilder app)
        {
            app.AddCommandsFromThisAssembly()
               .AddDirective<DebugDirective>()
               .UseInteractiveMode(useAdvancedInput: false);
        }
    }
}
