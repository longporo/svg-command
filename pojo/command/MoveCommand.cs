using System;
using System.Collections.Generic;
using svg_command.exception;
using svg_command.pojo.face;

namespace svg_command.pojo.command
{
    public class MoveCommand : Command
    {
        private string commandName = "move";
        private FaceCanvas faceCanvas;
        private Organ operateOrgan;
        private string direction;
        private int moveLength;
        private int prevTransX;
        private int prevTransY;

        public MoveCommand(FaceCanvas faceCanvas, string cmd)
        {
            try
            {
                this.faceCanvas = faceCanvas;
                List<string> args = faceCanvas.GetArgs(cmd, commandName, 3);
                direction = args[1];
                moveLength = int.Parse(args[2]);
                operateOrgan = faceCanvas.GetOrganByStr(args[0], commandName);
                prevTransX = operateOrgan.Style.TransX;
                prevTransY = operateOrgan.Style.TransY;
            }
            catch (Exception e)
            {
                if (e is MyException)
                {
                    throw;
                }

                throw new MyException($"Invalid '{commandName}' command, use 'help' for help.");
            }
        }

        public override void Do()
        {
            faceCanvas.MoveByDirection(direction, moveLength, operateOrgan);
            Console.WriteLine(
                $"{operateOrgan.OrganName} ({operateOrgan.Style.StyleName}) moved {direction} {moveLength}px.");
        }

        public override void Undo()
        {
            operateOrgan.Style.TransX = prevTransX;
            operateOrgan.Style.TransY = prevTransY;
            Console.WriteLine(
                $"Undo: {operateOrgan.OrganName} ({operateOrgan.Style.StyleName}) moved {direction} {moveLength}px.");
        }
    }
}