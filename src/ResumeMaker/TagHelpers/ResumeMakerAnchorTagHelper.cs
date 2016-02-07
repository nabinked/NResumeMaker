using System;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Razor.TagHelpers;
using ResumeMaker.Extensions;

namespace ResumeMaker.TagHelpers
{
    [HtmlTargetElement("a", Attributes = IsGetFormAjaxAttribute)]
    public class ResumeMakerAnchorTagHelper : TagHelper
    {
        private readonly IUrlHelper _urlHelper;

        public ResumeMakerAnchorTagHelper(IUrlHelper urlHelper)
        {
            _urlHelper = urlHelper;
        }

        private const string IsGetFormAjaxAttribute = "asp-get-form-ajax";
        private const string GetFormControllerTypeAttribute = "asp-get-form-controller-type";
        private const string GetFormActionAttribute = "asp-get-form-action";
        private const string GetFormIdAttribute = "asp-get-form-id";
        private const string TargetLoadElementIdAttribute = "asp-target-load-element-id";


        /// <summary>
        /// The controller that contains the action to return partial method
        /// </summary>
        [HtmlAttributeName(GetFormControllerTypeAttribute)]
        public Type GetFormControllerType { get; set; }

        /// <summary>
        /// True if the anchor brings the form by AJAX.
        /// </summary>
        [HtmlAttributeName(IsGetFormAjaxAttribute)]
        public bool IsGetFormAjax { get; set; }

        /// <summary>
        /// The action in the controller which returns a partial view
        /// </summary>
        [HtmlAttributeName(GetFormActionAttribute)]
        public string GetFormAction { get; set; }

        /// <summary>
        /// The action in the controller which returns a partial view
        /// </summary>
        [HtmlAttributeName(GetFormIdAttribute)]
        public long GetFormId { get; set; }

        /// <summary>
        /// The target element where the form is loaded
        /// </summary>
        [HtmlAttributeName(TargetLoadElementIdAttribute)]
        public string TargetLoadElementId { get; set; }

       
        public string GetFormControllerName => GetFormControllerType.GetControllerName();

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (IsGetFormAjax)
            {
                //Add the CSS class "get-form-ajax"
                IReadOnlyTagHelperAttribute cssClass;
                context.AllAttributes.TryGetAttribute("class", out cssClass);

                output.Attributes["class"] = cssClass?.Value + " get-form-ajax";

                output.Attributes.Add("data-load-form-url", _urlHelper.Action(GetFormAction, GetFormControllerName, null));
                output.Attributes.Add("data-target-element-id", TargetLoadElementId);
                output.Attributes.Add(GetFormIdAttribute, GetFormId);
            }
            base.Process(context, output);
        }
    }
}
