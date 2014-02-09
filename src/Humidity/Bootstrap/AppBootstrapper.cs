using System;
using System.Collections.Generic;
using Autofac;
using Caliburn.Micro;
using Humidity.Shell;

namespace Humidity.Bootstrap
{
    public class AppBootstrapper : Bootstrapper<ShellViewModel>
    {
        private readonly IContainer _container;

        public AppBootstrapper()
        {
            _container = AutofacConfig.Register();
        }

        protected override void Configure()
        {
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
}