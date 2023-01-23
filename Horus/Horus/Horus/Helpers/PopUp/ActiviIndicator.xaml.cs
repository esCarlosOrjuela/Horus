using System;
using Xamarin.Forms;
using Rg.Plugins.Popup.Pages;
using System.Collections.Generic;

namespace Horus.Helpers.PopUp
{
    public partial class ActiviIndicator : PopupPage
    {
        public ActiviIndicator(string txtActivityIndicator)
        {
            InitializeComponent();
            this.lblActivityIndicator.Text = txtActivityIndicator;
        }
    }
}

