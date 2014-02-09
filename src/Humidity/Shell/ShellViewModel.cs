using System;
using Caliburn.Micro;
using Humidity.Bootstrap;
using Humidity.Infrastructure;
using Humidity.Settings;

namespace Humidity.Shell
{
    public class ShellViewModel : Conductor<IScreen>.Collection.OneActive, IShell
    {
        private readonly SettingsViewModel _settings;
        private readonly BindableCollection<FlyoutViewModel> _flyouts;

        public ShellViewModel(SettingsViewModel settings)
        {
            _settings = settings;

            DisplayName = "Humidity";
            _flyouts = new BindableCollection<FlyoutViewModel> {_settings};
        }

        public IObservableCollection<FlyoutViewModel> Flyouts
        {
            get { return _flyouts; }
        }
        public IObservableCollection<FlyoutViewModel> Flyouts2{get { return Flyouts; }}

        public void ShowSettings()
        {
            _settings.IsOpen = !_settings.IsOpen;
        }
    }
}
