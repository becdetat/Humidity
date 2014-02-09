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