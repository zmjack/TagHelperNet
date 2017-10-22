using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;
using static TagHelperNet.Import_SyntaxHighlighterTagHelper;
using System.Text.RegularExpressions;

namespace TagHelperNet
{
    [HtmlTargetElement("code")]
    public class CodeTagHelper : TagHelper
    {
        /// <summary>
        /// Specify the language of displayed code
        /// </summary>
        public SupportLanguage NPLanguage { get; set; }

        /// <summary>
        /// Specify the highlights of displayed code. Use comma(,) to separate each row number.
        /// 23
        /// </summary>
        public string NPHighlight { get; set; }

        /// <summary>
        /// Specify the line of displayed code start with.
        /// </summary>
        public int? NPFirstLine { get; set; }

        /// <summary>
        /// Specify whether the code is collapsed when it's displayed firstly.
        /// </summary>
        public bool NPCollapse { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var childContent = output.GetChildContentAsync().Result.GetContent();

            var regex = new Regex(@"<pre>(?:\\r\\n)?(.+)(?:\\r\\n)?</pre>?", RegexOptions.Singleline);
            var match = regex.Match(childContent);
            if (match.Success)
                output.Content.SetHtmlContent(match.Groups[1].Value);

            if (NPLanguage != SupportLanguage.None)
            {
                output.TagName = "pre";

                var @class = new StringBuilder();
                @class.Append($"brush:{GetBrush(NPLanguage)};");
                if (!string.IsNullOrEmpty(NPHighlight))
                    @class.Append($"highlight:[{NPHighlight}];");
                if (NPFirstLine != null)
                    @class.Append($"first-line:{NPFirstLine};");
                if (NPCollapse)
                    @class.Append($"collapse:true;");

                output.Attributes.Add("class", @class);
            }
            else output.SuppressOutput();
        }

    }
}
