using System;
using System.Collections.Generic;
using svg_command.pojo.face;

namespace svg_command.pojo.command
{
    public class HideCommand : Command
    {

        private string commandName = "hide";
        private Organ operateOrgan;
        
        public HideCommand(FaceCanvas faceCanvas, string cmd)
        {
            List<string> args = faceCanvas.GetArgs(cmd, commandName, 1);
            this.operateOrgan = faceCanvas.GetOrganByStr(args[0], commandName);
        }

        public override void Do()
        {
            operateOrgan.Style.IsShown = false;
            Console.WriteLine($"{operateOrgan.OrganName} ({operateOrgan.Style.StyleName}) hidden from emoticon.");
        }

        public override void Undo()
        {
            operateOrgan.Style.IsShown = true;
            Console.WriteLine($"Undo: {operateOrgan.OrganName} ({operateOrgan.Style.StyleName}) hidden from emoticon.");
        }
    }
}