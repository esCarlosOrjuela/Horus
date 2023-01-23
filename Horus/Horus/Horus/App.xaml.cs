
using System;
using Horus.Interfaces;
using Horus.MVVM.ViewModel;
using Horus.Services;
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms;

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
            MainPage = new NavigationPage(new MVVM.View.LoginView());
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
            serviceDescriptors.AddTransient<IChallengesService, ChallengesService>();
            serviceDescriptors.AddTransient<IAutenticationUserService, AutenticationUserService>();
            #endregion

            #region ViewModels
            serviceDescriptors.AddTransient<LoginViewModel>();
            serviceDescriptors.AddTransient<ChallengeViewModel>();
            #endregion

            return serviceDescriptors.BuildServiceProvider();
        }

        protected override void OnStart() { }

        protected override void OnSleep() { }

        protected override void OnResume() { }
    }
}

