using System;
using System.Linq;
using System.Windows;
using Autofac;
using Caliburn.Micro;

namespace Humidity.Bootstrap
{
    public static class AutofacConfig
    {
        public static IContainer Register()
        {
            var builder = new ContainerBuilder();

            var assemblies = new[]
            {
                typeof (IShell).Assembly
            };

            builder.RegisterAssemblyTypes(assemblies)
                .Where(t => !t.IsAbstract)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyModules(assemblies);

            // Register view models
            builder.RegisterAssemblyTypes(AssemblySource.Instance.ToArray())
                .Where(type => type.Name.EndsWith("ViewModel"))
                .AsSelf()
                .InstancePerDependency();

            RegisterViews(builder);

            // Register window manager
            builder
                .Register<IWindowManager>(c => new WindowManager())
                .InstancePerLifetimeScope();

            // Register event aggregator
            builder
                .Register<IEventAggregator>(c => new EventAggregator())
                .InstancePerLifetimeScope();

            return builder.Build();
        }

        private static void RegisterViews(ContainerBuilder builder)
        {
            var themeResources = new ResourceDictionary
            {
                Source =
                    new Uri("pack://application:,,,/Resources/humiditytheme.xaml")
            };
            builder.RegisterAssemblyTypes(AssemblySource.Instance.ToArray())
                .Where(type => type.Name.EndsWith("View"))
                .AsSelf()
                .InstancePerDependency()
                .OnActivating(e =>
                {
                    {
                        var frameworkElement = e.Instance as FrameworkElement;
                        if (frameworkElement != null)
                        {
                            frameworkElement.Resources.MergedDictionaries.Add(themeResources);
                        }
                    }
                });
        }
    }
}