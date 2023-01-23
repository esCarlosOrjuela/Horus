using System;
using System.Collections.Generic;
using Horus.MVVM.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms;

namespace Horus.MVVM.View
{
    public partial class ChallengesView : ContentPage
    {
        ChallengeViewModel viewModelClass;

        public ChallengesView()
        {
            InitializeComponent();

            viewModelClass = ActivatorUtilities.CreateInstance<ChallengeViewModel>(App.Current.Services, this.Navigation);
            BindingContext = viewModelClass;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await viewModelClass.OnAppearing();
        }


    }
}

