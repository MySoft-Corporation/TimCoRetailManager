using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Effects;
using TRMDesktopUI.Helpers;

namespace TRMDesktopUI.ViewModels
{
    public class LoginViewModel : Screen
    {
        private string userName;

        public string UserName
        {
            get { return userName; }
            set { 
                userName = value;
                NotifyOfPropertyChange(() => UserName);
            }
        }
        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; 
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanLogIn);
            }
        }
        private IAPIHelper APIHelper;
        public LoginViewModel(IAPIHelper aPIHelper)
        {
            APIHelper = aPIHelper;
        }
        public bool CanLogIn
        {
            get
            {
                return UserName?.Length > 0 && Password?.Length > 0;
            }
        }
        public async Task LogIn()
        {
            await APIHelper.AuthenticateAsync(UserName, Password);
        }


    }
}
