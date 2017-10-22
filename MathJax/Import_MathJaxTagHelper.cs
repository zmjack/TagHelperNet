using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TagHelperNet
{
    [HtmlTargetElement("import-MathJax")]
    public class Import_MathJaxTagHelper : TagHelper, IImportable
    {
        public string From { get; set; } = "https://cdn.mathjax.org";
        public string In { get; set; } = "mathjax/2.7-latest";

        public EConfig Config { get; set; }

        public enum EConfig
        {
            None,
            Recommand,

            TeX_MML_AM__CHTML,
            TeX_MML_AM__HTMLorMML,
            TeX_MML_AM__SVG,

            TeX_AMS_MML__HTMLorMML,

            TeX_AMS__CHTML,
            TeX_AMS__SVG,
            TeX_AMS__HTML,

            MML__CHTML,
            MML__SVG,
            MML__HTMLorMML,

            AM__CHTML,
            AM__SVG,
            AM__HTMLorMML,

            TeX_AMS_MML__SVG,
        }

        private static Dictionary<EConfig, string> Config_ConfigString = new Dictionary<EConfig, string>
        {
            [EConfig.None] = "",

            [EConfig.Recommand] = "TeX-MML-AM_HTMLorMML",

            [EConfig.TeX_MML_AM__CHTML] = "TeX-MML-AM_CHTML",
            [EConfig.TeX_MML_AM__HTMLorMML] = "TeX-MML-AM_HTMLorMML",
            [EConfig.TeX_MML_AM__SVG] = "TeX-MML-AM_SVG",

            [EConfig.TeX_AMS_MML__HTMLorMML] = "TeX-AMS-MML_HTMLorMML",
            [EConfig.TeX_AMS_MML__SVG] = "TeX-AMS-MML_SVG",

            [EConfig.TeX_AMS__CHTML] = "TeX-AMS_CHTML",
            [EConfig.TeX_AMS__SVG] = "TeX-AMS_SVG",
            [EConfig.TeX_AMS__HTML] = "TeX-AMS_HTML",

            [EConfig.MML__CHTML] = "MML_CHTML",
            [EConfig.MML__SVG] = "MML_SVG",
            [EConfig.MML__HTMLorMML] = "MML_HTMLorMML",

            [EConfig.AM__CHTML] = "AM_CHTML",
            [EConfig.AM__SVG] = "AM_SVG",
            [EConfig.AM__HTMLorMML] = "AM_HTMLorMML",
        };

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = string.Empty;

            var postElement = new StringBuilder();

            if (Config != EConfig.None)
            {
                postElement.Append($@"<script type=""text/javascript"" async src=""{From}/{In}/MathJax.js?config={Config_ConfigString[Config]}""></script>");
            }
            else postElement.Append($@"<script type=""text/javascript"" async src=""{From}/{In}/MathJax.js""></script>");

            output.Content.SetHtmlContent(postElement.ToString());
        }

    }
}
