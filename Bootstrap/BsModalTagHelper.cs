using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TagHelperNet
{
    /// <summary>
    /// This tag must have 3 sections: -title, -content, -footer.
    /// </summary>
    [HtmlTargetElement("bs-modal")]
    public class BsModalTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var childContent = output.GetChildContentAsync().Result.GetContent();
            var re = "(.*?)<-title>(.*?)</-title>(?:.*)" +
                "<-content>(.*?)</-content>(?:.*)" +
                "<-footer>(.*?)</-footer>(.*)";

            var regex = new Regex(re, RegexOptions.Singleline);
            var match = regex.Match(childContent);
            var before = match.Success ? match.Groups[1].Value : "";
            var title = match.Success ? match.Groups[2].Value : "";
            var content = match.Success ? match.Groups[3].Value
                : "Content should have these sections: title, content, footer.";
            var footer = match.Success ? match.Groups[4].Value
                : @"<button type=""button"" class=""btn btn-default"" data-dismiss=""modal"">Close</button>";
            var after = match.Success ? match.Groups[5].Value : "";

            output.TagName = "div";
            output.Attributes.Add("class", "modal fade");
            output.Attributes.Add("tabindex", "-1");
            output.Attributes.Add("role", "dialog");

            var pcontent = $@"{before}
<div class=""modal-dialog"" role=""document"">
  <div class=""modal-content"">
    <div class=""modal-header"">
      <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close""><span aria-hidden=""true"">&times;</span></button>
      <h4 class=""modal-title"">{title}</h4>
    </div>
    <div class=""modal-body"">{content}</div>
    <div class=""modal-footer"">{footer}</div>
  </div><!-- /.modal-content -->
</div><!-- /.modal-dialog -->
{after}";

            output.Content.SetHtmlContent(pcontent);
        }

    }
}
