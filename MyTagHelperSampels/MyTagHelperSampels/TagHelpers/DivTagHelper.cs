using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MyTagHelperSampels.TagHelpers
{
    public class DivTagHelper:TagHelper
    {
        public string BroAlertColor { get; set; } = "danger";
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.Add("class",$"alert alert-{BroAlertColor}");
            output.PreElement.Append("Text befor danger alert");
            output.PostElement.Append("Text after danger alert");


            output.PreContent.Append("Text befor danger content alert");
            output.PostContent.Append("Text after danger content alert");
        }
    }
}
