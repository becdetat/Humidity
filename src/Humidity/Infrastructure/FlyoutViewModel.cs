using MahApps.Metro.Controls;

namespace Humidity.Infrastructure
{
    public abstract class FlyoutViewModel
    {
        public string Header { get; set; }
        public bool IsOpen { get; set; }
        public Position Position { get; set; }
    }
}