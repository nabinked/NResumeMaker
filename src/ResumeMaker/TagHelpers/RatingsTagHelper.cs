
using System.Text;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Razor.TagHelpers;

namespace ResumeMaker.TagHelpers
{
    [HtmlTargetElement("rating")]
    public class RatingsTagHelper : TagHelper
    {
        public int Rating { get; set; }
        public string SizeClass { get; set; }

        private HtmlString GetContent()
        {
            var sb = new StringBuilder();
            sb.Append("<div>");
            for (int i = 1; i < 6; i++)
            {
                
                sb.Append(i <= Rating ? GetStarDiv("rating-full") : GetStarDiv("rating-empty"));
            }
            sb.Append("</div>");
            var html = new HtmlString(sb.ToString());
            return html;
        }

        private string GetStarDiv(string ratingClass)
        {
            return $"<div class='{ratingClass} {SizeClass}'></div>";
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            var content = GetContent();
            output.Content.SetContent(content);

            base.Process(context, output);
        }
    }
}
