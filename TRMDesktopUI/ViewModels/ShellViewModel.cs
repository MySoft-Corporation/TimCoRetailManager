using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRMDesktopUI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private LoginViewModel _loginView;
        public ShellViewModel(LoginViewModel loginViewModel)
        {
            _loginView = loginViewModel;
            ActivateItem(_loginView);
        }
    }
}
