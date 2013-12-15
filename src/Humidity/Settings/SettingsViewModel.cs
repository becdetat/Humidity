using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Humidity.Infrastructure;
using MahApps.Metro.Controls;

namespace Humidity.Settings
{
    public class SettingsViewModel : FlyoutViewModel
    {
        public SettingsViewModel()
        {
            Header = "Settings";
            Position = Position.Right;
        }
    }
}
