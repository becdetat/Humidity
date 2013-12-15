using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using MahApps.Metro.Controls;
using PropertyChanged;

namespace Humidity.Infrastructure
{
    [ImplementPropertyChanged]
    public abstract class FlyoutViewModel
    {
        public string Header { get; set; }
        public bool IsOpen { get; set; }
        public Position Position { get; set; }
    }
}
