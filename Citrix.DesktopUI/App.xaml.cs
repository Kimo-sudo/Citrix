using Citrix.APICalling.Services;
using Citrix.Models.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Citrix.DesktopUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    /// 

    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {

            new DagmailService().GetDagmail(Models.Models.DagmailOmzet.Hoog).ContinueWith((task) =>
            {
                var result = task.Result;

            });
            base.OnStartup(e);
        }
    }
}
