using System;
namespace DataAccessSamples.Services
{
	public interface IDialogService
    {
        public Task ShowErrorAsync(string title, string message, string buttonText, Action afterHideCallback);
        public Task ShowExceptionAsync(Exception error, string title, string buttonText, Action afterHideCallback);

        public Task ShowAlertAsync(string title, string message, string buttonText, Action afterHideCallback);
        public Task<bool> ShowAlertAsync(string title, string message, string buttonConfirmText, string buttonCancelText, Action<bool> afterHideCallback);

    }
}

