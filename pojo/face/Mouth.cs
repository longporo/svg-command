using System;
using svg_command.pojo.style;

namespace svg_command.pojo.face
{
    [Serializable]
    public class Mouth : Organ
    {
        public Mouth()
        {
            this.Style = new MouthStyleA();
            this.OrganName = "Mouth";
        }

        public override void SetStyleA()
        {
            this.SetStyle(new MouthStyleA());
        }

        public override void SetStyleB()
        {
            this.SetStyle(new MouthStyleB());
        }
    }
}