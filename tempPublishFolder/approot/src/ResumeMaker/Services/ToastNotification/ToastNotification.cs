using System.Collections.Generic;
using ResumeMaker.ViewModels;

namespace ResumeMaker.Services.ToastNotification
{
    class ToastNotification : IToastNotification
    {
        public IList<ToastMessage> ToastMessages { get; set; } = new List<ToastMessage>(10);

        public void AddToastMessage(string title, string message, ToastEnums.ToastType notificationType)
        {
            var toastMessage = new ToastMessage()
            {
                Title = title,
                Message = message,
                ToastType = notificationType
            };

            ToastMessages.Add(toastMessage);

        }

        public void AddToastMessage(string title, string message, ToastEnums.ToastType notificationType, ToastOptions toastOptions)
        {
            var toastMessage = new ToastMessage()
            {
                Title = title,
                Message = message,
                ToastType = notificationType,
                ToastOptions = toastOptions
            };

            ToastMessages.Add(toastMessage);

        }
    }
}