using Microsoft.AspNet.Razor.TagHelpers;

namespace ResumeMaker.TagHelpers
{
    [HtmlTargetElement("button", Attributes = "asp-refresh")]
    public class RefreshButtonTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);
            output.Content.SetHtmlContent("<i class='fa fa-refresh'></i> &nbsp;Cancel");
        }
    }
}
