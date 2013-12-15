using System;
using Caliburn.Micro;
using Humidity.Bootstrap;
using Humidity.Infrastructure;
using Humidity.Settings;

namespace Humidity.Shell
{
    public class ShellViewModel : Screen, IShell
    {
        private readonly SettingsViewModel _settings;

        public ShellViewModel(SettingsViewModel settings)
        {
            _settings = settings;

            Flyouts = new BindableCollection<FlyoutViewModel>();
            Flyouts.Add(_settings);
        }

        public new string DisplayName
        {
            get { return "Humidity"; }
            set { }
        }

        public IObservableCollection<FlyoutViewModel> Flyouts { get; private set; }

        public override void CanClose(Action<bool> callback)
        {
            App.Current.Shutdown();
        }

        public void ShowSettings()
        {
            _settings.IsOpen = !_settings.IsOpen;
        }
    }
}
