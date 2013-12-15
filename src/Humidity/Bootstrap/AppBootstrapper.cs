using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Autofac;

namespace Humidity.Bootstrap
{
    public class AppBootstrapper
    {
        private IContainer _container;

        protected  void Configure()
        {
            _container = AutofacConfig.Register();
        }

        protected  void BuildUp(object instance)
        {
            _container.InjectProperties(instance);
        }

        protected  object GetInstance(Type service, string key)
        {
            return !string.IsNullOrWhiteSpace(key)
                ? _container.ResolveNamed(key, service)
                : _container.Resolve(service);
        }

        protected  IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.Resolve(typeof (IEnumerable<>).MakeGenericType(service)) as IEnumerable<object>;
        }
    }

    public interface IShell
    {
    }
}
