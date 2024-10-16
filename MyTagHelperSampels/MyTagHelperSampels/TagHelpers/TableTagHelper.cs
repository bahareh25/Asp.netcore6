using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MyTagHelperSampels.TagHelpers
{
    public class TableTagHelper:TagHelper
    {
        public string BroBgColor { get; set; } = "info";
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.Add("class", $"table table-striped table-bordered table-{BroBgColor}");
        }
    }
}
