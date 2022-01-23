using System;
using System.Collections.Generic;
using svg_command.exception;
using svg_command.pojo.face;
using svg_command.pojo.style;

namespace svg_command.pojo.command
{
    public class StyleCommand : Command
    {
        private string commandName = "style";
        private string styleName;
        private Style prevStyle;
        private Organ operateOrgan;
        

        public StyleCommand(FaceCanvas faceCanvas, string cmd)
        {
            List<string> args = faceCanvas.GetArgs(cmd, commandName, 2);
            operateOrgan = faceCanvas.GetOrganByStr(args[0], commandName);
            styleName = args[1];
            prevStyle = operateOrgan.Style;
        }

        public override void Do()
        {
            switch (styleName)
            {
                case "a":
                    operateOrgan.SetStyleA();
                    break;
                case "b":
                    operateOrgan.SetStyleB();
                    break;
                default:
                    throw new MyException(@$"Invalid style: {styleName}, currently supported styles: a, b.");
            }
            Console.WriteLine($"Set {operateOrgan.OrganName} style to style: {operateOrgan.Style.StyleName}.");
        }

        public override void Undo()
        {
            operateOrgan.Style = prevStyle;
            Console.WriteLine($"Undo: Set {operateOrgan.OrganName} style to style: {operateOrgan.Style.StyleName}.");
        }
    }
}