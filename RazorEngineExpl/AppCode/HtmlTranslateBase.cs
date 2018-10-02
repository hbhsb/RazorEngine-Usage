using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RazorEngine.Templating;
using RazorEngine.Text;

namespace RazorEngineExpl.AppCode
{
    public class MyHtmlHelper
    {
        public IEncodedString Raw(string rawString)
        {
            if (rawString.Contains("1"))
            {
                return new RawString("翻译后");
            }
            return new RawString(rawString);
        }
    }

    public abstract class HtmlTranslateBase<T> : TemplateBase<T>
    {
        public HtmlTranslateBase()
        {
            Html = new MyHtmlHelper();
        }
        public MyHtmlHelper Html { get; set; }
    }
}