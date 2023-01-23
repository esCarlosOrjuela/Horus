using System;
using Xamarin.Forms;
using PropertyChanged;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Horus.MVVM.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class BaseViewModel: ObservableValidator
    {
        public BaseViewModel() { }

        /// <summary>
        /// Interface abstracting platform-specific navigation.
        /// </summary>
        public INavigation Navigation;

        #region Binding Properties

        /// <summary>
        /// Property that gets or sets whether a process is wainting
        /// </summary>
        public bool IsBusy { get; set; }

        #endregion

        #region Methods
        public async virtual Task OnAppearing() { }
        public async virtual Task OnDisappearing() { }
        public async virtual Task OnBackButtonPressed() => await Navigation.PopAsync();

        #endregion
    }
}

