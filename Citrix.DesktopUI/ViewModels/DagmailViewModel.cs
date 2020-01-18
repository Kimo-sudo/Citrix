using Caliburn.Micro;
using Citrix.Data;
using Citrix.DesktopUI.lib;
using Citrix.DesktopUI.Lib.Models;
using Citrix.Models;
using Citrix.Models.Services.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Citrix.DesktopUI.ViewModels
{
    public class DagmailViewModel : Screen
    {
        private readonly IDagmailEndpoint _dagmail;
        private readonly IWindowManager _window;
        private readonly ApplicationDbContext _context;
        private BindingList<Dagmail> _dagdeels;

        public DagmailViewModel(IWindowManager window, ApplicationDbContext context, IDagmailEndpoint dagmail)
        {
            _window = window;
            _context = context;
            _dagmail = dagmail;
        }


        public BindingList<Dagmail> Dagmail

        {
            get { return _dagdeels; }
            set
            {
                _dagdeels = value;
                NotifyOfPropertyChange(() => Dagmail);
            }
        }


        protected override async void OnViewLoaded(object view)
        {
            
            base.OnViewLoaded(view);
            try
            {
                await LoadUsers();
                
            }
            catch (Exception ex)
            {
                dynamic settings = new ExpandoObject();
                settings.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                settings.ResizeMode = ResizeMode.NoResize;
                settings.Title = "System Error";
                await TryCloseAsync();
            }

        }
        
        public async Task LoadUsers()
        {

            var x = await _dagmail.GetAll();
            var dagmails = new BindingList<Dagmail>();
            foreach (var item in x)
            {
                dagmails.Add(item);
            }
            Dagmail = dagmails;
           


        }
    }
}
