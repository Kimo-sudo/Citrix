using Caliburn.Micro;
using Citrix.Data;
using Citrix.DesktopUI.lib;
using Citrix.DesktopUI.Lib;
using Citrix.DesktopUI.Lib.Models;
using System;
using System.ComponentModel;
using System.Dynamic;
using System.Threading.Tasks;
using System.Windows;

namespace Citrix.DesktopUI.ViewModels
{
    public class HomeViewModel : Conductor<object>
    {
        private readonly IDagmailEndpoint _dagmail;
        private readonly IWindowManager _window;
        private readonly ApplicationDbContext _context;
        private BindingList<Dagmail> _dagdeels;

        private readonly IKlachtenEndpoint _klachten;
        private BindingList<KlachtModel> _klacht;

        public HomeViewModel(IWindowManager window, IKlachtenEndpoint klachten, ApplicationDbContext context, IDagmailEndpoint dagmail)
        {
            _window = window;
            _context = context;
            _dagmail = dagmail;
            _klachten = klachten;
        }

        public BindingList<Dagmail> Dagmail
        {
            get
            {

                return _dagdeels;
            }
            set
            {
                _dagdeels = value;
                NotifyOfPropertyChange(() => Dagmail);
            }
        }

        public BindingList<KlachtModel> Klachten
        {
            get
            {
                return _klacht;
            }
            set
            {
                _klacht = value;
                NotifyOfPropertyChange(() => Klachten);
            }
        }

        protected override async void OnViewLoaded(object view)
        {

            base.OnViewLoaded(view);
            try
            {
                await LoadInfo();

            }
            catch (Exception)
            {
                dynamic settings = new ExpandoObject();
                settings.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                settings.ResizeMode = ResizeMode.NoResize;
                settings.Title = "System Error";
                await TryCloseAsync();
            }

        }

        public async Task LoadInfo()
        {
            ///  Dagmail 
            var x = await _dagmail.GetAll();
            var dagmails = new BindingList<Dagmail>();
            foreach (var item in x)
            {
                dagmails.Add(item);
            }
            Dagmail = dagmails;

            // klachten

           
            var alleKlachten = await _klachten.GetAll();
            var KlachtLoaded = new BindingList<KlachtModel>();

            foreach (var klacht in alleKlachten)
            {
                KlachtLoaded.Add(klacht);
            }
            Klachten = KlachtLoaded;
            
        }
    }
}

