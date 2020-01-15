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
        private DagmailViewModel _dagmailVM;
        private readonly ApplicationDbContext _context;


        public ShellViewModel(IEventAggregator events, DagmailViewModel dagmailVM, ApplicationDbContext context)
        {
            _events = events;
            _dagmailVM = dagmailVM;
            _events.SubscribeOnPublishedThread(this);
            _context = context;

           ActivateItemAsync(IoC.Get<LoginViewModel>(), new CancellationToken());
        }

        public bool IsLoggedIn
        {
            get
            {
                bool output = false;
                if (string.IsNullOrWhiteSpace("Test") == false)
                {
                    output = true;
                }
                return output;
            }
        }
        public void Dagmail()
        {
            ActivateItemAsync(IoC.Get<DagmailViewModel>(), new CancellationToken());
        }

        public async Task HandleAsync(LogOnEvent message, CancellationToken cancellationToken)
        {
            await ActivateItemAsync(_dagmailVM, cancellationToken);

           
            NotifyOfPropertyChange(() => IsLoggedIn);
        }


    }


}
