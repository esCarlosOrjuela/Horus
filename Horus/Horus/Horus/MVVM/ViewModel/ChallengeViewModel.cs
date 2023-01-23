using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Horus.MVVM.Model;
using PropertyChanged;
using Xamarin.Forms;
using Horus.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Horus.Services;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace Horus.MVVM.ViewModel
{
    public class ChallengeViewModel : BaseViewModel
    {

        #region Variables
        private string _jsonCloneObjectChallenges;
        private readonly IDialogService _dialogServices;
        private readonly IChallengesService _challengesService;
        #endregion

        public int TotalChallenges { get; set; }
        public int TotalChallengesCompled { get; set; }
        public ObservableCollection<ChallengeModel> Challenges { get; set; }

        public ICommand OnBackButtonPressedCommand => new Command(async () => await OnBackButtonPressedCommandExecute());
        public ICommand SelectedItemCommand => new Command<ChallengeModel>((ChallengeSelected) => SelectedItemCommandExecute(ChallengeSelected));

        private Task SelectedItemCommandExecute()
        {
            throw new NotImplementedException();
        }

        //public ChallengeModel ChallengeSelectedItem { set { _ = ChallengeSelectedItemCommandExecute(value); } }

        public ChallengeViewModel(INavigation navigation)
        {
            Navigation = navigation;
            _dialogServices = App.Current.Services.GetService<IDialogService>();
            _challengesService = App.Current.Services.GetRequiredService<IChallengesService>();
        }

        private void SelectedItemCommandExecute(ChallengeModel challengeSelectedItem)
        {
            string information = $"Titulo: {challengeSelectedItem.Title}\r\nDescripción: {challengeSelectedItem.Description}";
            Challenges.Clear();
            var newChallenges = JsonConvert.DeserializeObject<ObservableCollection<ChallengeModel>>(_jsonCloneObjectChallenges);
            Challenges = new ObservableCollection<ChallengeModel>(newChallenges);

            ApplyStyles(Challenges);
            var updateItem = Challenges.FirstOrDefault(x => x.Id == challengeSelectedItem.Id);
            updateItem.TitleTextColorItem = (Color)Application.Current.Resources["TextColorItemSelected"];
            updateItem.ProgressBarColorItem = (Color)Application.Current.Resources["TextColorItemSelected"];
            updateItem.DescriptionTextColorItem = (Color)Application.Current.Resources["TextColorItemSelected"];
            updateItem.GridBackgroundColorItem = (Color)Application.Current.Resources["GridBackgroundColorItemSelected"];

        }

        public async override Task OnAppearing()
        {
            try
            {
                Challenges = new ObservableCollection<ChallengeModel>(await _challengesService.GetChallenges());
                TotalChallenges = Challenges.Count();
                TotalChallengesCompled = Challenges.Where(x => x.FloatCompleted == 1).ToList().Count();

                _jsonCloneObjectChallenges = JsonConvert.SerializeObject(Challenges);
                ApplyStyles(Challenges);
                await Task.FromResult(_dialogServices.HideLoading());
            }
            catch (Exception Exception)
            {
                await Task.FromResult(_dialogServices.HideLoading());
                await Task.FromResult(_dialogServices.ShowConfirmationAsync("Información", $"{Exception.Message}"));
            }
        }

        private void ApplyStyles(ObservableCollection<ChallengeModel> collectionChallenges)
        {
            foreach (var item in Challenges)
            {
                item.TitleTextColorItem = (Color)Application.Current.Resources["TitleTextColorItem"];
                item.ProgressBarColorItem = (Color)Application.Current.Resources["ProgressBarColorItem"];
                item.GridBackgroundColorItem = (Color)Application.Current.Resources["GridBackgroundColorItem"];
                item.DescriptionTextColorItem = (Color)Application.Current.Resources["DescriptionTextColorItem"];
            }
        }

        public async Task OnBackButtonPressedCommandExecute()
        {
            Device.BeginInvokeOnMainThread(async () => {
                var result = await _dialogServices.ShowAlertAsync("Información", $"Seguro que desea cerrar sesión?", "Aceptar", "Cancelar");

                if (result)
                    await Navigation.PopAsync();
            });
        }
    }
}
