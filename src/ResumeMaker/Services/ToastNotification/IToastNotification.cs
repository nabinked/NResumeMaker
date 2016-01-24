using System.Collections.Generic;
using ResumeMaker.ViewModels;

namespace ResumeMaker.Services.ToastNotification
{
    public interface IToastNotification
    {
        IList<ToastMessage> ToastMessages { get; set; }
        void AddToastMessage(string title, string message, ToastEnums.ToastType notificationType);

        void AddToastMessage(string title, string message, ToastEnums.ToastType notificationType,
            ToastOptions toastOptions);
    }
}
