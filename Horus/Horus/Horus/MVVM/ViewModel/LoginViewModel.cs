using System;
using Horus.Services;
using Xamarin.Forms;
using Horus.Interfaces;
using System.Windows.Input;
using Microsoft.Extensions.DependencyInjection;

namespace Horus.MVVM.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {

        #region Variables
        private readonly IDialogService _dialogServices;
        #endregion

        #region Events Command
        public ICommand OnTapOptionCommand => new Command((parameter) =>
        {
            _dialogServices.ShowConfirmationAsync("Información", $"Bienvenido a la opción {parameter}!");
        });
        #endregion

        public LoginViewModel(INavigation navigation)
        {
            Navigation = navigation;
            _dialogServices = App.Current.Services.GetService<IDialogService>();
        }
    }
}

