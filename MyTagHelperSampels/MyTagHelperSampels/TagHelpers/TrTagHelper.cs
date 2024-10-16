﻿using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MyTagHelperSampels.TagHelpers
{
    public class TrTagHelper:TagHelper
    {
        public string CellText { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            context.Items["CellText"] = CellText;
        }
    }
}
