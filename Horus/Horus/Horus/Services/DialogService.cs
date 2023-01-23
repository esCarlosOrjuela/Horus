using System;
using System.Threading.Tasks;
using Horus.Helpers.PopUp;
using Horus.Interfaces;
using Rg.Plugins.Popup.Services;

namespace Horus.Services
{
    public class DialogService : IDialogService
    {
        /// <summary>Presents an alert dialog to the application user with an accept and a cancel button.</summary>
        /// <param name="title">The title of the alert dialog.</param>
        /// <param name="message">The body text of the alert dialog.</param>
        /// <param name="accept">Text to be displayed on the 'Accept' button.</param>
        /// <param name="cancel">Text to be displayed on the 'Cancel' button.</param>
        /// <reference>
        /// Autor: Carlos.Orjuela | 20.Jan.2023
        /// </reference>
        public async Task<bool> ShowAlertAsync(string title, string message, string accept, string cancel)
        {
            return await App.Current.MainPage.DisplayAlert(title, message, accept, cancel);
        }

        /// <summary>Presents an alert dialog to the application user with an accept button.</summary>
        /// <param name="title">The title of the alert dialog.</param>
        /// <param name="message">The body text of the alert dialog.</param>
        /// <param name="accept">Text to be displayed on the 'Accept' button.</param>
        /// <reference>
        /// Autor: Carlos.Orjuela | 20.Jan.2023
        /// </reference>
        public Task ShowConfirmationAsync(string title, string message, string accept)
        {
            return App.Current.MainPage.DisplayAlert(title, message, accept);
        }

        /// <summary>Presents an alert dialog</summary>
        /// <param name="title">The title of the alert dialog.</param>
        /// <param name="message">The body text of the alert dialog.</param>s
        /// <reference>
        /// Autor: Carlos.Orjuela | 20.Jan.2023
        /// </reference>
        public Task ShowConfirmationAsync(string title, string message)
        {
            return App.Current.MainPage.DisplayAlert(title, message, "Ok");
        }

        public async Task ShowLoading(string message)
        {
            await PopupNavigation.Instance.PushAsync(new ActiviIndicator(message));
        }

        public async Task HideLoading()
        {
            await PopupNavigation.Instance.PopAsync(true);
        }
    }
}

