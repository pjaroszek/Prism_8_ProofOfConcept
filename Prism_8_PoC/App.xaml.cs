
using Microsoft.Extensions.Logging;

using Prism.Events;
using Prism.Ioc;
using Prism.Unity;

using Prism_8_PoC.Views;

using Serilog;
using Serilog.Extensions.Logging;
using Serilog.Sinks.Graylog;

using System.Windows;

namespace Prism_8_PoC
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .Enrich.FromLogContext()
    .WriteTo.Graylog(new GraylogSinkOptions
    {
        HostnameOrAddress = "localhost",
        Port = 12201,
    })
    .CreateLogger();

            base.OnStartup(e);

        }

        protected override void OnExit(ExitEventArgs e)
        {
            Log.CloseAndFlush();
            base.OnExit(e);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            var eventAggregator = this.Container.Resolve<IEventAggregator>();
            containerRegistry.RegisterSingleton<ILoggerFactory, SerilogLoggerFactory>();
        }

        protected override Window CreateShell()
        {
            return this.Container.Resolve<ShellView>();
        }
    }
}
