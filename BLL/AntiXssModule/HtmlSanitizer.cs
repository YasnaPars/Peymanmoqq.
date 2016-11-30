using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace HtmlCleaner
{
    public static class HtmlSanitizer
    {
        #region Fields (4)

        private static readonly Regex ChromeWhiteSpace = new Regex(@"style=""white-space\s*:\s*pre\s*;\s*""", RegexOptions.Singleline | RegexOptions.IgnoreCase | RegexOptions.Compiled);
        private static readonly Regex HtmlComments = new Regex("((<!-- )((?!<!-- ).)*( -->))(\r\n)*", RegexOptions.Singleline | RegexOptions.IgnoreCase | RegexOptions.Compiled);
        private static readonly Regex HtmlTagExpression = new Regex(@"(?'tag_start'</?)(?'tag'\w+)((\s+(?'attr'(?'attr_name'\w+)(\s*=\s*(?:"".*?""|'.*?'|[^'"">\s]+)))?)+\s*|\s*)(?'tag_end'/?>)", RegexOptions.Singleline | RegexOptions.IgnoreCase | RegexOptions.Compiled);
        private static readonly Dictionary<string, List<string>> ValidHtmlTags = new Dictionary<string, List<string>> {
        { "p", new List<string> { "style" } },
        { "table", new List<string> { "height", "width", "style" } },
        { "tr", new List<string> { "style" } },
        { "td", new List<string> { "style" } },
        { "tbody", new List<string> { "style" } },
        { "tfoot", new List<string> {"style", "class"}},
        { "th", new List<string> { "style" } },
        { "div", new List<string> { "dir", "align", "style" } },
        { "span", new List<string> { "dir", "color", "align", "style" } },
        { "pre", new List<string> { "language", "name", "style" } },
        { "strong", new List<string> { "style" } },
        { "br", new List<string> { "style" } },
        { "label", new List<string> {"style", "class"}},
        { "font", new List<string> {"style", "class", "color", "face", "size"}},
        { "h1", new List<string> { "style" } },
        { "h2", new List<string> { "style" } },
        { "h3", new List<string> { "style" } },
        { "h4", new List<string> { "style" } },
        { "h5", new List<string> { "style" } },
        { "h6", new List<string> { "style" } },
        { "blockquote", new List<string> {"style", "class"}},
        { "b", new List<string> { "style" } },
        { "hr", new List<string> { "style" } },
        { "em", new List<string> { "style" } },
        { "i", new List<string> { "style" } },
        { "u", new List<string> { "style" } },
        { "strike", new List<string> { "style" } },
        { "ol", new List<string> { "style" } },
        { "ul", new List<string> { "style" } },
        { "li", new List<string> { "style" } },
        { "a", new List<string> { "href", "style" } },
        { "img", new List<string> { "src", "height", "width", "alt", "style" } },
        { "q", new List<string> { "cite", "style" } },
        { "cite", new List<string> { "style" } },
        { "abbr", new List<string> { "style" } },
        { "acronym", new List<string> { "style" } },
        { "del", new List<string> { "style" } },
        { "ins", new List<string> { "style" } }};

        #endregion Fields

        #region Methods (3)

        private static string cleanHtml(this string html)
        {
            html = ChromeWhiteSpace.Replace(html, string.Empty);
            html = HtmlComments.Replace(html, string.Empty);
            return html;
        }

        /// <summary>
        /// To the safe HTML.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public static string ToSafeHtml(this string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }

            text = text.cleanHtml();
            text = text.removeInvalidHtmlTags();
            return text.ApplyModeratePersianRules();
        }

        // Private Methods (1) 
        /// <summary>
        /// Removes the invalid HTML tags.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        private static string removeInvalidHtmlTags(this string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }

            return HtmlTagExpression.Replace(text, m =>
            {
                if (!ValidHtmlTags.ContainsKey(m.Groups["tag"].Value.ToLowerInvariant()))
                {
                    return String.Empty;
                }

                var generatedTag = new StringBuilder(m.Length);
                var tagStart = m.Groups["tag_start"];
                var tagEnd = m.Groups["tag_end"];
                var tag = m.Groups["tag"];
                var tagAttributes = m.Groups["attr"];
                generatedTag.Append(tagStart.Success ? tagStart.Value : "<");
                generatedTag.Append(tag.Value);

                foreach (Capture attr in tagAttributes.Captures)
                {
                    var indexOfEquals = attr.Value.IndexOf('=');

                    // don't proceed any futurer if there is no equal sign or just an equal sign
                    if (indexOfEquals < 1)
                    {
                        continue;
                    }

                    var attrName = attr.Value.Substring(0, indexOfEquals).ToLowerInvariant();

                    // check to see if the attribute name is allowed and write attribute if it is
                    if (!ValidHtmlTags[tag.Value.ToLowerInvariant()].Contains(attrName))
                    {
                        continue;
                    }

                    generatedTag.Append(' ');
                    generatedTag.Append(attr.Value);
                }

                generatedTag.Append(tagEnd.Success ? tagEnd.Value : ">");
                return generatedTag.ToString();
            });
        }

        #endregion Methods
    }
}