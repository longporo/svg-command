using System;

namespace svg_command.pojo.style
{
    [Serializable]
    public abstract class StyleB : Style
    {
        protected StyleB()
        {
            StyleName = "StyleB";
        }
    }
}