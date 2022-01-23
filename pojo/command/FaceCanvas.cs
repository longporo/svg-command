using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using svg_command.exception;
using svg_command.pojo.face;

namespace svg_command.pojo.command
{
    /// <summary>
    /// The FaceCanvas plays the Receiver role and contains concrete methods that associated with the commands
    /// </summary>
    public class FaceCanvas
    {
        private Face Face;
        
        /// <summary>
        /// Initialise Singleton
        /// </summary>
        private static readonly FaceCanvas _instance = new(new Face());

        public static FaceCanvas GetInstance => _instance;

        private FaceCanvas(Face face)
        {
            Face = face;
        }
        
        /// <summary>
        /// Save to a svg file
        /// </summary>
        /// <param name="cmd"></param>
        /// <exception cref="MyException"></exception>
        public void SaveSvgFile(string cmd)
        {
            string commandName = "save";
            List<string> args = GetArgs(cmd, commandName, 1);
            string fileName = args[0];
            if (fileName.Length < 5 || !fileName.EndsWith(".svg"))
            {
                throw new MyException($"Invalid file name: {fileName}, file name should look like: fileName.svg");
            }
            
            string text = GenSvgCode();
            File.WriteAllText(fileName, text);
            Console.WriteLine($"File: {fileName} has been saved!");
        }
        
        /// <summary>
        /// Print current svg
        /// </summary>
        public void Draw()
        {
            Console.WriteLine(GenSvgCode());
        }

        /// <summary>
        /// Generate the svg code
        /// </summary>
        /// <returns></returns>
        public string GenSvgCode()
        {
            StringBuilder sb = new();

            // header
            sb.Append(@"<svg viewBox=""0 0 72 72"" xmlns=""http://www.w3.org/2000/svg"" >");
            sb.Append(Environment.NewLine);
            
            // content
            sb.Append("<!-- Face -->");
            sb.Append(Environment.NewLine);
            sb.Append(@"<circle cx=""36"" cy=""36"" r=""23"" fill=""#FCEA2B"" stroke=""#000000"" stroke-miterlimit=""10"" stroke-width=""2""/>");
            sb.Append(Environment.NewLine);
            
            sb.Append("<!-- Left brow -->");
            sb.Append(Environment.NewLine);
            sb.Append(this.Face.LeftBrow.Style.GenSvgCode());
            sb.Append(Environment.NewLine);
            
            sb.Append("<!-- Right brow -->");
            sb.Append(Environment.NewLine);
            sb.Append(this.Face.RightBrow.Style.GenSvgCode());
            sb.Append(Environment.NewLine);
            
            sb.Append("<!-- Left eye -->");
            sb.Append(Environment.NewLine);
            sb.Append(this.Face.LeftEye.Style.GenSvgCode());
            sb.Append(Environment.NewLine);
            
            sb.Append("<!-- Right eye -->");
            sb.Append(Environment.NewLine);
            sb.Append(this.Face.RightEye.Style.GenSvgCode());
            sb.Append(Environment.NewLine);
            
            sb.Append("<!-- Mouth -->");
            sb.Append(Environment.NewLine);
            sb.Append(this.Face.Mouth.Style.GenSvgCode());
            sb.Append(Environment.NewLine);
            
            // footer
            sb.Append("</svg>");

            return sb.ToString();
        }
        
         /// <summary>
        /// Get the command arguments
        /// </summary>
        /// <param name="cmdStr"></param>
        /// <param name="commandName"></param>
        /// <param name="expectedCount"></param>
        /// <returns></returns>
        /// <exception cref="MyException"></exception>
        /// Throw the exception if the arguments count does not equal to expected count
        public List<string> GetArgs(string cmdStr, string commandName, int expectedCount)
        {
            List<string> argList = new List<string>();
            var args = cmdStr.Split(" ");
            foreach (var arg in args)
            {
                var trimArg = arg.Trim();
                if (trimArg.Length > 0 && trimArg != commandName)
                {
                    argList.Add(trimArg);
                }
            }

            if (argList.Count != expectedCount)
            {
                throw new MyException($"Invalid '{commandName}' command, use 'help' for help.");
            }

            return argList;
        }
        
        /// <summary>
        /// Get the corresponding organ by a string
        /// </summary>
        /// <param name="organStr"></param>
        /// <param name="commandName"></param>
        /// <returns></returns>
        /// <exception cref="MyException"></exception>
        /// Throw the exception if there are not matched string for organStr
        public Organ GetOrganByStr(string organStr, string commandName)
        {
            Organ operateOrgan;
            switch (organStr)
            {
                case "left-eye":
                    operateOrgan = this.Face.LeftEye;
                    break;
                case "right-eye":
                    operateOrgan = this.Face.RightEye;
                    break;
                case "left-brow":
                    operateOrgan = this.Face.LeftBrow;
                    break;
                case "right-brow":
                    operateOrgan = this.Face.RightBrow;
                    break;
                case "mouth":
                    operateOrgan = this.Face.Mouth;
                    break;
                default:
                    throw new MyException($"Invalid '{commandName}' command, use 'help' for help.");
            }

            return operateOrgan;
        }
        
        /// <summary>
        /// Move the specific organ
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="value"></param>
        /// <param name="organ"></param>
        /// <exception cref="MyException"></exception>
        public void MoveByDirection(string direction, int value, Organ organ)
        {
            switch (direction)
            {
                case "up":
                    organ.MoveUp(value);
                    break;
                case "down":
                    organ.MoveDown(value);
                    break;
                case "left":
                    organ.MoveLeft(value);
                    break;
                case "right":
                    organ.MoveRight(value);
                    break;
                default:
                    throw new MyException(@$"Invalid direction: {direction}, use 'help' for help.");
            }
        }
    }
}