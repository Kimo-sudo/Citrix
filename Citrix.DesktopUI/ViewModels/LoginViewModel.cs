using Caliburn.Micro;
using Citrix.DesktopUI.EventModels;
using Citrix.DesktopUI.Helpers;
using Citrix.DesktopUI.lib;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Citrix.DesktopUI.ViewModels
{
    public class LoginViewModel : Conductor<object>
    {

        private IEventAggregator _events;
        private string _userName = "admin@test.nl";
        private string _password = "Admin-123";
        private string _errorMessage;
        private IAPIHelper _apiHelper;
        

        public LoginViewModel(IEventAggregator events, IAPIHelper apiHelper)
        {
            _events = events;
            _apiHelper = apiHelper;
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                NotifyOfPropertyChange(() => IsErrorVisible);
                NotifyOfPropertyChange(() => ErrorMessage);
            }
        }

        public bool IsErrorVisible
        {
            get
            {
                bool output = false;

                if (ErrorMessage?.Length > 0)
                {
                    output = true;
                }

                return output;
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanLogIn);
            }
        }
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                NotifyOfPropertyChange(() => UserName);
                NotifyOfPropertyChange(() => CanLogIn);
            }
        }
        public bool CanLogIn
        {
            get
            {
                bool output = false;

                if (UserName?.Length > 0 && Password?.Length > 0)
                {
                    output = true;
                }

                return output;
            }
        }

        public async Task LogIn()
        {
            try
            {
                ErrorMessage = "";
                var result = await _apiHelper.Authenticate(UserName, Password);
                await _events.PublishOnUIThreadAsync(new LogOnEvent());

            }
            catch (Exception ex)
            {
               

                switch (ex.Message)
                {
                    case "Bad Request":
                        ErrorMessage = "Gebruikersnaam of wachtwoord niet correct. " +
                            "\nWachtwoord of gebruikersnaam vergeten?" +
                            "\n neem dan contact op met info@citrix.nl";
                        break;
                    default:
                        ErrorMessage = ex.Message;
                        break;
                }

            }

        }
    }
}