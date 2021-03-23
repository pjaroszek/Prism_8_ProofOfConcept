using Microsoft.Extensions.Logging;

using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;

namespace Prism_8_PoC.ViewModels
{
    public sealed partial class ShellViewModel : BindableBase
    {
        //  private readonly AggregateLogger logger;
        private readonly IDialogService dialogService;
        private readonly IEventAggregator eventAggregator;
        private readonly IRegionManager regionManager;
        private readonly ILogger<ShellViewModel> logger;
        public ShellViewModel(IDialogService dialogService, IEventAggregator eventAggregator, IRegionManager regionManager, ILoggerFactory loggerFactory)//AggregateLogger logger)
        {
            this.dialogService = dialogService;
            this.eventAggregator = eventAggregator;
            this.regionManager = regionManager;
            this.logger = loggerFactory.CreateLogger<ShellViewModel>();

            this.logger.LogInformation("test");

            //   this.logger = logger;
            //  this.logger.Log("asasa");


        }

    }
}