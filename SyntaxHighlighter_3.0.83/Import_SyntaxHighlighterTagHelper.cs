using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace TagHelperNet
{
    [HtmlTargetElement("import-SyntaxHighlighter")]
    public class Import_SyntaxHighlighterTagHelper : TagHelper, IImportable
    {
        public string From { get; set; } = "http://taghelper.net";
        public string In { get; set; } = "TagHelperNet/syntaxhighlighter_3.0.83";

        public enum SupportLanguage
        {
            None,
            ActionScript3,
            Bash,
            ColdFusion, CSharp, Cpp, CSS,
            Delphi, Diff,
            Erlang,
            Groovy,
            JavaScript, Java, JavaFX,
            Perl, PHP, PlainText, PowerShell, Python,
            Ruby,
            Scala,
            SQL,
            VisualBasic,
            XML,
        }

        public static string GetBrush(SupportLanguage language)
        {
            switch (language)
            {
                default:
                    return "";
                case SupportLanguage.ActionScript3:
                    return "as3";
                case SupportLanguage.Bash:
                    return "bash";
                case SupportLanguage.ColdFusion:
                    return "cf";
                case SupportLanguage.Cpp:
                    return "cpp";
                case SupportLanguage.CSharp:
                    return "csharp";
                case SupportLanguage.CSS:
                    return "css";
                case SupportLanguage.Delphi:
                    return "delphi";
                case SupportLanguage.Diff:
                    return "diff";
                case SupportLanguage.Erlang:
                    return "erl";
                case SupportLanguage.Groovy:
                    return "groovy";
                case SupportLanguage.Java:
                    return "java";
                case SupportLanguage.JavaFX:
                    return "jfx";
                case SupportLanguage.JavaScript:
                    return "js";
                case SupportLanguage.Perl:
                    return "perl";
                case SupportLanguage.PHP:
                    return "php";
                case SupportLanguage.PlainText:
                    return "plain";
                case SupportLanguage.PowerShell:
                    return "ps";
                case SupportLanguage.Python:
                    return "py";
                case SupportLanguage.Ruby:
                    return "ruby";
                case SupportLanguage.Scala:
                    return "scala";
                case SupportLanguage.SQL:
                    return "sql";
                case SupportLanguage.VisualBasic:
                    return "vb";
                case SupportLanguage.XML:
                    return "xml";
            }
        }

        public static string GetJavaScriptFileName(SupportLanguage language)
        {
            switch (language)
            {
                default:
                    return "";
                case SupportLanguage.ActionScript3:
                    return "shBrushAS3.js";
                case SupportLanguage.Bash:
                    return "shBrushBash.js";
                case SupportLanguage.ColdFusion:
                    return "shBrushColdFusion.js";
                case SupportLanguage.Cpp:
                    return "shBrushCpp.js";
                case SupportLanguage.CSharp:
                    return "shBrushCSharp.js";
                case SupportLanguage.CSS:
                    return "shBrushCss.js";
                case SupportLanguage.Delphi:
                    return "shBrushDelphi.js";
                case SupportLanguage.Diff:
                    return "shBrushDiff.js";
                case SupportLanguage.Erlang:
                    return "shBrushErlang.js";
                case SupportLanguage.Groovy:
                    return "shBrushGroovy.js";
                case SupportLanguage.Java:
                    return "shBrushJava.js";
                case SupportLanguage.JavaFX:
                    return "shBrushJavaFX.js";
                case SupportLanguage.JavaScript:
                    return "shBrushJScript.js";
                case SupportLanguage.Perl:
                    return "shBrushPerl.js";
                case SupportLanguage.PHP:
                    return "shBrushPhp.js";
                case SupportLanguage.PlainText:
                    return "shBrushPlain.js";
                case SupportLanguage.PowerShell:
                    return "shBrushPowerShell.js";
                case SupportLanguage.Python:
                    return "shBrushPython.js";
                case SupportLanguage.Ruby:
                    return "shBrushRuby.js";
                case SupportLanguage.Scala:
                    return "shBrushScala.js";
                case SupportLanguage.SQL:
                    return "shBrushSql.js";
                case SupportLanguage.VisualBasic:
                    return "shBrushVb.js";
                case SupportLanguage.XML:
                    return "shBrushXml.js";
            }
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = string.Empty;

            var postElement = new StringBuilder();
            postElement.Append($@"<script type=""text/javascript"" src=""{From}/{In}/scripts/shCore.js""></script>");

            var supportLanguageNames = Enum.GetNames(typeof(SupportLanguage));
            foreach (var name in supportLanguageNames)
            {
                if (name == SupportLanguage.None.ToString()) continue;

                var language = (SupportLanguage)Enum.Parse(typeof(SupportLanguage), name);
                postElement.Append($@"<script type=""text/javascript"" src=""{From}/{In}/scripts/{GetJavaScriptFileName(language)}""></script>");
            }
            postElement.Append($@"<link type=""text/css"" rel=""stylesheet"" href=""{From}/{In}/styles/shCore.css"" />");
            postElement.Append(@"<script type=""text/javascript"">SyntaxHighlighter.all();</script>");

            output.Content.SetHtmlContent(string.Empty);
            output.PostElement.SetHtmlContent(postElement.ToString());
        }
    }
}
