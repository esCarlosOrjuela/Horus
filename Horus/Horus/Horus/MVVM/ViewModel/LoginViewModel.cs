using System;
using Horus.Services;
using Xamarin.Forms;
using Horus.Interfaces;
using System.Windows.Input;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;
using PropertyChanged;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Horus.MVVM.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {

        #region Variables
        private readonly IDialogService _dialogServices;
        private readonly IAutenticationUserService _autenticationUserServices;

        public ObservableCollection<string> Bugs { get; set; }
        #endregion

        #region Binding Properties
        [Required(ErrorMessage = "Campo Email es requerido")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Formato de correo no valido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Password es requerido")]
        public string Password { get; set; }
        #endregion


        #region Events Command
        public ICommand OnTapOptionCommand => new Command((parameter) =>
        {
            _dialogServices.ShowConfirmationAsync("Información", $"Bienvenido a la opción {parameter}!");
        });

        public ICommand AuthenticateUserCommand => new Command(AuthenticateUserCommandExecute);

        #endregion

        public LoginViewModel(INavigation navigation)
        {
            Password = string.Empty;
            Navigation = navigation;
            Bugs = new ObservableCollection<string>();
            _dialogServices = App.Current.Services.GetService<IDialogService>();
            _autenticationUserServices = App.Current.Services.GetRequiredService<IAutenticationUserService>();
        }

        #region ExecuteCommand
        private async void AuthenticateUserCommandExecute(object obj)
        {
            try
            {
                Bugs.Clear();
                ValidateAllProperties();
                GetErrors(nameof(Email)).ToList().ForEach(e => Bugs.Add($"Error: {e.ErrorMessage}"));
                GetErrors(nameof(Password)).ToList().ForEach(e => Bugs.Add($"Error:{e.ErrorMessage}"));

                if (Bugs.Count > 0)
                {
                    string error = string.Empty;

                    foreach (var bug in Bugs)
                        error += $"\r\n{bug}";

                    await Task.FromResult(_dialogServices.ShowConfirmationAsync("Error", $"{error}"));
                }
                else
                {
                    await Task.FromResult(_dialogServices.ShowLoading("Verificando..."));
                    bool authenticatedUser = await _autenticationUserServices.UserSignIn(user: this.Email, pass: this.Password);

                    if (authenticatedUser)
                        await Navigation.PushAsync(new MVVM.View.ChallengesView());
                    else
                        throw new ArgumentNullException("Contenido solo visible a usuarios registrados");
                }

            }
            catch (Exception Exception)
            {
                await Task.FromResult(_dialogServices.HideLoading());
                await Task.FromResult(_dialogServices.ShowConfirmationAsync("Error", $"{Exception.Message}"));
            }

        }
        #endregion
    }
}

