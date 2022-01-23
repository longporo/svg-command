using System;
using svg_command.pojo.style;

namespace svg_command.pojo.face
{
    [Serializable]
    public class LeftEye : Organ
    {
        public LeftEye()
        {
            this.Style = new LeftEyeStyleA();
            this.OrganName = "Left Eye";
        }

        public override void SetStyleA()
        {
            this.SetStyle(new LeftEyeStyleA());
        }

        public override void SetStyleB()
        {
            this.SetStyle(new LeftEyeStyleB());
        }
    }
}