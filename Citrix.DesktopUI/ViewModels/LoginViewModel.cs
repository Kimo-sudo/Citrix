using Caliburn.Micro;
using Citrix.Data;
using Citrix.DesktopUI.EventModels;
using Citrix.DesktopUI.Helpers;
using Citrix.DesktopUI.lib;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Citrix.DesktopUI.ViewModels
{
    public class LoginViewModel : Conductor<object>
    {

        private string _userName = "admin@admin.nl";
        private string _password = "Admin-123";

        private IEventAggregator _events;
        private string _errorMessage;
        private IAPIHelper _apiHelper;
        private IWindowManager manager = new WindowManager();
        private readonly IWindowManager _windowManager;
        public bool _dagmail;


        public LoginViewModel(IEventAggregator events, IAPIHelper apiHelper, IWindowManager windowManager)
        {
            _events = events;
            _apiHelper = apiHelper;
            _windowManager = windowManager;
            
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

                await _windowManager.ShowWindowAsync(IoC.Get<ShellViewModel>());
                await _events.PublishOnUIThreadAsync(new LogOnEvent());
                await this.TryCloseAsync();
                
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