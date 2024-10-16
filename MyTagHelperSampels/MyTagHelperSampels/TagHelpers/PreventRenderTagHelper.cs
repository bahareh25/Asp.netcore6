using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MyTagHelperSampels.TagHelpers
{
    [HtmlTargetElement("PreventRender")]
    public class PreventRenderTagHelper:TagHelper
    {
        public bool AllowRender { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
           if(!AllowRender)
            { output.SuppressOutput(); 
            }
        }
    }

    [HtmlTargetElement("Authorize")]
    public class AuthorizeTagHelper : TagHelper
    {
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext Context { get; set; }
        public string ValidRole { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
          if(!Context.HttpContext.User.IsInRole("ValidRole"))
                output.SuppressOutput();
        }
    }
}
