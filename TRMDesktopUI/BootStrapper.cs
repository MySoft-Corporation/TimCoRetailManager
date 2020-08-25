using Caliburn.Micro;
using System.Windows;
using TRMDesktopUI.ViewModels;

namespace TRMDesktopUI
{
    class BootStrapper : BootstrapperBase
    {
        public BootStrapper()
        {
            Initialize();
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}
