using System;
using svg_command.pojo.style;

namespace svg_command.pojo.face
{
    [Serializable]
    public class RightEye : Organ
    {
        public RightEye()
        {
            this.Style = new RightEyeStyleA();
            this.OrganName = "Right Eye";
        }

        public override void SetStyleA()
        {
            this.SetStyle(new RightEyeStyleA());
        }

        public override void SetStyleB()
        {
            this.SetStyle(new RightEyeStyleB());
        }
    }
}