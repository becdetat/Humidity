using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Autofac;
using Caliburn.Micro;
using Humidity.ViewModels;
using IContainer = Autofac.IContainer;

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

            builder.RegisterAssemblyTypes(assemblies);
            builder.RegisterAssemblyModules(assemblies);

            builder.RegisterType<ShellViewModel>().AsImplementedInterfaces().InstancePerDependency();

            RegisterViewModels(builder);
            RegisterViews(builder);
            RegisterWindowManager(builder);
            RegisterEventAggregator(builder);

            return builder.Build();
        }

        private static void RegisterEventAggregator(ContainerBuilder builder)
        {
            builder
                .Register<IEventAggregator>(c => new EventAggregator())
                .InstancePerLifetimeScope();
        }

        private static void RegisterWindowManager(ContainerBuilder builder)
        {
            builder
                .Register<IWindowManager>(c => new WindowManager())
                .InstancePerLifetimeScope();
        }

        private static void RegisterViewModels(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(AssemblySource.Instance.ToArray())
                .Where(type => type.Name.EndsWith("ViewModel"))
                .Where(type => type.IsAssignableTo<INotifyPropertyChanged>())
                .AsSelf()
                .InstancePerDependency();
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
