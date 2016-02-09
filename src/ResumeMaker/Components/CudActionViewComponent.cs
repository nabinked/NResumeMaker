using System;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Mvc.ViewComponents;
using Newtonsoft.Json;
using ResumeMaker.Enums;
using ResumeMaker.Extensions;
using ResumeMaker.Services;
using ResumeMaker.ViewModels;

namespace ResumeMaker.Components
{
    public class CudActionViewComponent : ResumeMakerBaseViewComponent
    {
        private readonly IResumeBuilderViewHelper _viewHelper;

        public CudActionViewComponent(IResumeBuilderViewHelper viewHelper)
        {
            _viewHelper = viewHelper;
        }
        public bool IsVisible => ViewBag.UserCanEdit ?? false;

        public IViewComponentResult Invoke(Type controllerType, string actionName, string targetElementId,
            object paramObj, CudTypeEnum cudType, string innerText)
        {
            if (cudType == CudTypeEnum.Create || cudType == CudTypeEnum.Update)
            {
                var cuvm = new CreateUpdateActionViewModel()
                {
                    IsVisible = IsVisible,
                    FormParams = GetJsonFormParams(paramObj),
                    GetFormUrl = GetFormUrl(actionName, controllerType),
                    TargetElementId = targetElementId,
                    InnerText = GetInnerTextForCreateUpdateAnchors(cudType, innerText)
                };
                return View("CreateUpdateActionView", cuvm);
            }
            throw new Exception("Worng method invocation. There is a method overload for creating delete actions.");
        }

        private Uri GetFormUrl(string actionName, Type controllerType)
        {
            var url = Url.Action(actionName, controllerType.GetControllerName());
            return new Uri(url, UriKind.Relative);
        }

        private string GetJsonFormParams(object paramObj)
        {
            return JsonConvert.SerializeObject(paramObj);
        }

        private string GetInnerTextForCreateUpdateAnchors(CudTypeEnum cudType, string innerText)
        {

            switch (cudType)
            {
                case CudTypeEnum.Create:
                    {
                        return string.IsNullOrWhiteSpace(innerText) ? $"{innerText}<i class=\"fa fa-plus\"></i>" : innerText;

                    }
                case CudTypeEnum.Update:
                    {

                        return string.IsNullOrWhiteSpace(innerText) ? $"{innerText}<i class=\"fa fa-pencil\"></i>" : innerText;

                    }
                case CudTypeEnum.Delete:
                    return string.IsNullOrWhiteSpace(innerText) ? $"{innerText}<i class=\"fa fa-remove\"></i>" : innerText; ;
                default:
                    throw new ArgumentOutOfRangeException(nameof(cudType), cudType, null);
            }
        }

        public IViewComponentResult Invoke(Type controllerType, string actionName, long id)
        {
            var dvm = new DeleteActionViewModel()
            {
                ControllerName = controllerType.GetControllerName(),
                ActionName = actionName,
                RecordId = id,
                IsVisible = IsVisible,
                ReturnUrl = _viewHelper.CurrentUrl
            };
            return View("DeleteActionView", dvm);
        }

        public HtmlString Invoke(string innerText)
        {
            if (IsVisible)
            {
                return
                    new HtmlString(string.IsNullOrWhiteSpace(innerText)
                        ? $"<i class=\"btn btn-link fa fa-edit form-toggle-button\"></i>"
                        : $"<a class=\"btn btn-link form-toggle-button\">{innerText}</a   >");
            }
            else
            {
                return new HtmlString("");
            }
            
        }
    }
}
