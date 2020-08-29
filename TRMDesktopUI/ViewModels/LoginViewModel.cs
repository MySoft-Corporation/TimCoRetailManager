using Caliburn.Micro;
using POSDesktopUI.Library.Api;
using System;
using System.Threading.Tasks;
using TRMDesktopUI.Models;

namespace TRMDesktopUI.ViewModels
{
    public class LoginViewModel : Screen
    {
        private IAPIHelper _APIHelper;
        public LoginViewModel(IAPIHelper aPIHelper)
        {
            _APIHelper = aPIHelper;
        }
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
                AuthenticatedUser result = await _APIHelper.Authenticate(UserName, Password);
                await _APIHelper.GetLoggedInUserInfo(result.access_token);
          
            }
            catch (Exception exc)
            {
                ErrorMsg = exc.Message.ToString();
               
            }
           
        }


    }
}
