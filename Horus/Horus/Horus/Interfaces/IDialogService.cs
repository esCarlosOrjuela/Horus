using System;
using System.Threading.Tasks;

namespace Horus.Interfaces
{
    public interface IDialogService
    {
        Task<bool> ShowAlertAsync(string title, string message, string accept, string cancel);
        Task ShowConfirmationAsync(string title, string message, string accept);
        Task ShowConfirmationAsync(string title, string message);
        Task ShowLoading(string message);
        Task HideLoading();
    }
}

