using Caliburn.Micro;
using Citrix.Data;
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
        private readonly IWindowManager _window;
        private readonly ApplicationDbContextFactory _contextFactory;
        private IDataAccesUI<Manager> managerService = new GenericDataService<Manager>(new ApplicationDbContextFactory());
        public DagmailViewModel(IWindowManager window, ApplicationDbContextFactory contextFactory)
        {
            _window = window;
            _contextFactory = contextFactory;


        }

        private BindingList<Manager> _managers;

        

        public BindingList<Manager> Managers
        {
            get { return _managers; }
            set
            {
                _managers = value;
                NotifyOfPropertyChange(() => Managers);
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
            var userList = await managerService.GetAll();
            Managers = new BindingList<Manager>(userList);

        }
    }
}
