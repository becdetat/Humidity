using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
