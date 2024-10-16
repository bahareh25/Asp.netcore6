using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MyTagHelperSampels.TagHelpers
{
   // [HtmlTargetElement("p", Attributes = "my-text-bg-color",ParentTag ="div")]
    [HtmlTargetElement("p",Attributes = "my-text-bg-color")]
    [HtmlTargetElement("Span", Attributes = "my-text-bg-color")]
   // [HtmlTargetElement("*", Attributes = "my-text-bg-color")]
    public class PTagHelper:TagHelper
    {
        public string MyTextBgColor { get; set; } = "text-bg-primary";
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.Add("class", MyTextBgColor);
        }
    }
}
