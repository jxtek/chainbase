using System;

namespace ChainFx.Web
{
    /// <summary>
    /// A comment tag for generating help documentation. 
    /// </summary>
    public abstract class HelpAttribute : Attribute
    {
        public const string CRLF = "\r\n";

        public abstract void Render(HtmlBuilder h);

        public abstract bool IsDetail { get; }
    }
}