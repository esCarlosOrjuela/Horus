using System;
using System.Collections.Generic;
using Horus.MVVM.ViewModel;
using Horus.Resources.Fonts;
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms;

namespace Horus.MVVM.View
{
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
            BindingContext = ActivatorUtilities.CreateInstance<LoginViewModel>(App.Current.Services, this.Navigation);
        }

        /// <summary>
        /// Action called when invoking the Tap event on the Password's eye
        /// </summary>
        /// <param name="sender">Contains a reference to the control/object that raised the event</param>
        /// <param name="e">Contains event data</param>
        /// <reference>
        /// Autor: Carlos.Orjuela | 20.Jan.2023
        /// </reference>
        void TapGestureRecognizerEye_Tapped(System.Object sender, System.EventArgs e)
        {
            this.txtPass.IsPassword = !this.txtPass.IsPassword;
            string icon = string.Empty;

            if (sender is Label)
            {
                if (!this.txtPass.IsPassword)
                    icon = IconFont.EyeOffOutline;
                else
                    icon = IconFont.EyeOutline;

                var lblIcon = sender as Label;
                lblIcon.Text = icon;
            }
                
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            this.txtPass.Text = string.Empty;
        }

    }
}

