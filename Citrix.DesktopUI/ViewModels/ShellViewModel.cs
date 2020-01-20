using Caliburn.Micro;
using Citrix.Data;
using Citrix.DesktopUI.EventModels;
using Citrix.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Citrix.DesktopUI.ViewModels
{

    public class ShellViewModel : Conductor<object>, IHandle<LogOnEvent>
    {

        private IEventAggregator _events;
        private HomeViewModel _homeVM;
        private readonly ApplicationDbContext _context;
        public bool _dagmail;
        private readonly IWindowManager _windowManager;


        public ShellViewModel(IEventAggregator events, IWindowManager windowManager, HomeViewModel homeVM, ApplicationDbContext context)
        {
            _events = events;
            _homeVM = homeVM;
            _events.SubscribeOnPublishedThread(this);
            _context = context;
            _windowManager = windowManager;
        }

        public bool IsLoggedIn
        {
            get
            {
                bool output = false;
                if (ActiveItem == _homeVM)
                {
                    output = true;
                }
                return output;
            }
            set
            {
                IsLoggedIn = value;

            }
        }

        public async Task HandleAsync(LogOnEvent message, CancellationToken cancellationToken)
        {
            await ActivateItemAsync(_homeVM, cancellationToken);
            NotifyOfPropertyChange(() => IsLoggedIn);
        }
    }
}
