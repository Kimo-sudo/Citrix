using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Citrix.DesktopUI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private DagmailViewModel _dagmailVM;
        private NavViewModel _navVM;
        private ManagerViewModel _managerVM;

        public ShellViewModel(DagmailViewModel dagmailVM, NavViewModel navVM, ManagerViewModel managerVM)
        {
            _dagmailVM = dagmailVM;
            _navVM = navVM;
            _managerVM = managerVM;

            ActivateItemAsync(IoC.Get<DagmailViewModel>(), new CancellationToken());
            ActivateItemAsync(IoC.Get<NavViewModel>(), new CancellationToken());

        }
    }
}
