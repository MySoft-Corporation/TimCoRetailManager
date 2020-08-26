using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using TRMDesktopUI.ViewModels;

namespace TRMDesktopUI
{
    public class BootStrapper : BootstrapperBase
    {
        private SimpleContainer simpleContainer = new SimpleContainer();
        
        
        public BootStrapper()
        {
            Initialize();
        }
        protected override void Configure()
        {
            simpleContainer.Instance(simpleContainer);
            simpleContainer.Singleton<IWindowManager, WindowManager>().Singleton<IEventAggregator, EventAggregator>();
            GetType().Assembly.GetTypes().Where(Type => Type.IsClass).Where(Type => Type.Name.EndsWith("ViewModel")).ToList().ForEach(viewModelType => simpleContainer.RegisterPerRequest(viewModelType, viewModelType.ToString(), viewModelType));
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }
        protected override object GetInstance(Type service, string key)
        {
            return simpleContainer.GetInstance(service, key);
        }
        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return simpleContainer.GetAllInstances(service);
        }
        protected override void BuildUp(object instance)
        {
            simpleContainer.BuildUp(instance);
        }

    }
}
