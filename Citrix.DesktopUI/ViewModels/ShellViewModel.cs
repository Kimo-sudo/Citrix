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

        public ShellViewModel(DagmailViewModel dagmailVM)
        {
            _dagmailVM = dagmailVM;

            ActivateItemAsync(IoC.Get<DagmailViewModel>(), new CancellationToken());
        }
    }
}
