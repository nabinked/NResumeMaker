using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ResumeMaker.Services.ToastNotification;

namespace ResumeMaker.Components
{
    public class ToastrViewComponent : ResumeMakerBaseViewComponent
    {
        public IToastNotification ToastNotification { get; set; }

        public ToastrViewComponent(IToastNotification toastNotification)
        {
            ToastNotification = toastNotification;
        }

        public  IViewComponentResult Invoke()
        {
            return  View("ToastrView", ToastNotification);
        }

    }
}
