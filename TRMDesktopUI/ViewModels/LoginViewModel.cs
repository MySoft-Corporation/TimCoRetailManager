using Caliburn.Micro;
using System;
using System.Threading.Tasks;
using TRMDesktopUI.Helpers;

namespace TRMDesktopUI.ViewModels
{
    public class LoginViewModel : Screen
    {
        private string errorMSG;

        public string ErrorMsg
        {
            get { return errorMSG; }
            set { 
                errorMSG = value;
                NotifyOfPropertyChange(() => ErrorMsg);
                NotifyOfPropertyChange(() => IsErrorVisible);
            }
        }

        public bool IsErrorVisible
        {
            get {
                return errorMSG?.Length > 0;
            }
        }

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
            try
            {
                ErrorMsg = "Checking in Database";
                 await APIHelper.AuthenticateAsync(UserName, Password);
                ErrorMsg = "Logging In";
            }
            catch (Exception exc)
            {
                ErrorMsg = exc.Message.ToString();
               
            }
           
        }


    }
}
