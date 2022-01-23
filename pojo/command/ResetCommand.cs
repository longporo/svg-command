using System;
using System.Collections.Generic;
using svg_command.pojo.face;
using svg_command.pojo.style;

namespace svg_command.pojo.command
{
    public class ResetCommand : Command
    {
        private string commandName = "reset";
        private Style prevStyle;
        private Organ operateOrgan;
        

        public ResetCommand(FaceCanvas faceCanvas, string cmd)
        {
            List<string> args = faceCanvas.GetArgs(cmd, commandName, 1);
            operateOrgan = faceCanvas.GetOrganByStr(args[0], commandName);
            prevStyle = operateOrgan.Style;
        }

        public override void Do()
        {
            operateOrgan.Reset();
            Console.WriteLine($"Set {operateOrgan.OrganName} style to default style: {operateOrgan.Style.StyleName}.");
        }

        public override void Undo()
        {
            Console.WriteLine($"Undo: Set {operateOrgan.OrganName} style to default style: {operateOrgan.Style.StyleName}.");
            operateOrgan.Style = prevStyle;
        }
    }
}