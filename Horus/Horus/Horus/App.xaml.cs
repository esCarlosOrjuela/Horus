
using System;
using Xamarin.Forms;
using Horus.MVVM.View;
using Horus.Services;
using Horus.Interfaces;
using Horus.MVVM.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace Horus
{
    public partial class App : Application
    {
        public new static App Current => (App)Application.Current;
        public IServiceProvider Services { get; }

        public App()
        {
            Services = App.RegisterDependencyAndServices();

            InitializeComponent();
            MainPage = new MVVM.View.LoginView();
        }

        /// <summary>
        /// Container for registering dependencies and services
        /// </summary>
        /// <reference>
        /// Autor: Carlos.Orjuela | 20.Jan.2023
        /// </reference>
        private static IServiceProvider RegisterDependencyAndServices()
        {
            var serviceDescriptors = new ServiceCollection();

            #region Services
            serviceDescriptors.AddTransient<IDialogService, DialogService>();
            #endregion

            #region ViewModels
            serviceDescriptors.AddTransient<LoginViewModel>();
            #endregion

            return serviceDescriptors.BuildServiceProvider();
        }

        protected override void OnStart() { }

        protected override void OnSleep() { }

        protected override void OnResume() { }
    }
}

