using Caliburn.Micro;
using MahApps.Metro.Controls;
using PropertyChanged;

namespace Humidity.Infrastructure
{
    [ImplementPropertyChanged]
    public abstract class FlyoutViewModel : PropertyChangedBase
    {
        public string Header { get; set; }
        public bool IsOpen { get; set; }
        public Position Position { get; set; }
    }
}