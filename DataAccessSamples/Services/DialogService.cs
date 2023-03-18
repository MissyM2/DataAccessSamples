using System;
namespace DataAccessSamples.Services
{
    public class DialogService : IDialogService
    {
        public async Task ShowErrorAsync(string title, string message, string buttonText, Action afterHideCallback)
        {
            await Application.Current.MainPage.DisplayAlert(title, message, buttonText);
            if (afterHideCallback != null)
            {
                afterHideCallback();
            }
        }

        public async Task ShowExceptionAsync(Exception error, string title, string buttonText, Action afterHideCallback)
        {
            await Application.Current.MainPage.DisplayAlert(
                title,
                error.Message,
                buttonText);

            if (afterHideCallback != null)
            {
                afterHideCallback();
            }
        }

        public async Task ShowAlertAsync(string title, string message, string buttonText, Action afterHideCallback)
        {
            await Application.Current.MainPage.DisplayAlert(title, message, buttonText);

            if (afterHideCallback != null)
            {
                afterHideCallback();
            }
        }

        public async Task<bool> ShowAlertAsync(string title, string message, string buttonConfirmText,
        string buttonCancelText, Action<bool> afterHideCallback)
        {
            var result = await Application.Current.MainPage.DisplayAlert(
            title,
            message,
            buttonConfirmText,
            buttonCancelText);

            if (afterHideCallback != null)
            {
                afterHideCallback(result);
            }
            return result;
        }

    }

}


