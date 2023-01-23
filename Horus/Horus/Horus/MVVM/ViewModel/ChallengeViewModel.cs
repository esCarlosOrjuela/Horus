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

        public ChallengeModel ChallengeSelectedItem { set { Task task = ChallengeSelectedItemCommandExecute(value); } }

        #region Events Command
        public ICommand ChallengeSelectedItem2
            => new Command<ChallengeModel>(async (ChallengeSelectedItem) => await ChallengeSelectedItemCommandExecute(ChallengeSelectedItem));

        #endregion

        public ChallengeViewModel(INavigation navigation)
        {
            Navigation = navigation;
            _dialogServices = App.Current.Services.GetService<IDialogService>();
            _challengesService = App.Current.Services.GetRequiredService<IChallengesService>();
        }

        private async Task ChallengeSelectedItemCommandExecute(ChallengeModel challengeSelectedItem)
        {
            Challenges.Clear();
            var newChallenges = JsonConvert.DeserializeObject<ObservableCollection<ChallengeModel>>(_jsonCloneObjectChallenges);
            var updateItem = newChallenges.FirstOrDefault(x => x.Id == challengeSelectedItem.Id);
            updateItem.TitleTextColorItem = (Color)Application.Current.Resources["TextColorItemSelected"];
            updateItem.ProgressBarColorItem = (Color)Application.Current.Resources["TextColorItemSelected"];
            updateItem.DescriptionTextColorItem = (Color)Application.Current.Resources["TextColorItemSelected"];
            updateItem.GridBackgroundColorItem = (Color)Application.Current.Resources["GridBackgroundColorItemSelected"];

            Challenges = new ObservableCollection<ChallengeModel>(newChallenges);
            TotalChallenges = Challenges.Count();
            TotalChallengesCompled = Challenges.Where(x => x.FloatCompleted == 1).ToList().Count();
        }

        public async override Task OnAppearing()
        {
            try
            {
                Challenges = new ObservableCollection<ChallengeModel>(await _challengesService.GetChallenges());
                TotalChallenges = Challenges.Count();
                TotalChallengesCompled = Challenges.Where(x => x.FloatCompleted == 1).ToList().Count();

                _jsonCloneObjectChallenges = JsonConvert.SerializeObject(Challenges);

                foreach (var item in Challenges)
                {
                    item.TitleTextColorItem = (Color)Application.Current.Resources["TitleTextColorItem"];
                    item.ProgressBarColorItem = (Color)Application.Current.Resources["ProgressBarColorItem"];
                    item.GridBackgroundColorItem = (Color)Application.Current.Resources["GridBackgroundColorItem"];
                    item.DescriptionTextColorItem = (Color)Application.Current.Resources["DescriptionTextColorItem"];
                }
                await Task.FromResult(_dialogServices.HideLoading());
            }
            catch (Exception Exception)
            {
                await Task.FromResult(_dialogServices.HideLoading());
                await Task.FromResult(_dialogServices.ShowConfirmationAsync("Información", $"{Exception.Message}"));
            }

        }
    }
}
