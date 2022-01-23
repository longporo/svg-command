using System;

namespace svg_command.pojo.style
{
    [Serializable]
    public abstract class StyleA : Style
    {
        protected StyleA()
        {
            StyleName = "StyleA";
        }
    }
}