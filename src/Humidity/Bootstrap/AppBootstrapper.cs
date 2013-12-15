using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Autofac;
using Caliburn.Micro;

namespace Humidity.Bootstrap
{
    public class AppBootstrapper : Bootstrapper<IShell>
    {
        private IContainer _container;

        protected override void Configure()
        {
            _container = AutofacConfig.Register();

            //ViewLocator.GetOrCreateViewType = GetOrCreateViewType;
        }

        protected override void BuildUp(object instance)
        {
            _container.InjectProperties(instance);
        }

        protected override object GetInstance(Type service, string key)
        {
            return !string.IsNullOrWhiteSpace(key)
                ? _container.ResolveNamed(key, service)
                : _container.Resolve(service);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.Resolve(typeof (IEnumerable<>).MakeGenericType(service)) as IEnumerable<object>;
        }
    }

    public interface IShell
    {
    }
}
