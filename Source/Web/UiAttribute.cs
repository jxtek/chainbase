using System;
using System.Data.SqlTypes;

namespace ChainFx.Web
{
    /// <summary>
    /// To specify basic user interface-related information for a nodule (work or action) object.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class UiAttribute : Attribute
    {
        readonly string label;

        readonly string tip;

        readonly string icon;

        readonly short group;

        /// <summary>
        ///  To specify user interface-related attributes.
        /// </summary>
        /// <param name="label">The label text for the target work or action. It can be Unicode symbols or HTML entities</param>
        /// <param name="tip">A short description of the functionality</param>
        /// <param
        ///     name="icon">
        /// </param>
        /// <param name="group"></param>
        public UiAttribute(string label = null, string tip = null, string icon = null, short group = 0)
        {
            this.label = label;
            this.tip = tip;
            this.icon = icon;
            this.group = group;
        }

        public string Label => label;

        public string Tip => tip;

        public string Icon => icon;

        /// <summary>
        /// A number that determines grouping of functions.
        /// </summary>
        public short Group => group;

        /// <summary>
        /// Can be included & shown as help documentation.
        /// </summary>
        public bool Help { get; set; } = true;
    }
}