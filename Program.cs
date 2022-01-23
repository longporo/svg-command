using System;
using svg_command.exception;
using svg_command.pojo.command;

namespace svg_command
{
    class Program
    {
        /// <summary>
        /// Student Number: 21250028.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // The client code
            var user = new UserInterface();

            Console.WriteLine();
            Console.WriteLine("Emoticon created - use commands to show, hide, move or style features to the emoticon.");
            ShowHelpMsg();
            bool showTheMenu = true;
            while (showTheMenu)
            {
                try
                {
                    showTheMenu = MainMenu(user);
                }
                catch (Exception ex)
                {
                    if (ex is MyException)
                    {
                        Console.WriteLine(ex.Message);
                    } else
                    {
                        Console.WriteLine("Oooops! System error: {0}", ex.Message);
                    }
                }
            }
        }
        
        //
        // This section contains the application menu
        //
        private static bool MainMenu(UserInterface user)
        {
            string cmd = Console.ReadLine();
            cmd = cmd.ToLower().Trim();
            if (cmd == "quit")
            {
                Console.WriteLine("Goodbye!");
                return false;
            }
            if (cmd.StartsWith("show "))
            {
                user.Action(new ShowCommand(user.Canvas, cmd));
            }
            else if (cmd.StartsWith("hide "))
            { 
                user.Action(new HideCommand(user.Canvas, cmd));
            }
            else if (cmd.StartsWith("move "))
            {
                user.Action(new MoveCommand(user.Canvas, cmd));
            }
            else if (cmd.StartsWith("reset "))
            {
                user.Action(new ResetCommand(user.Canvas, cmd));
            }
            else if (cmd.StartsWith("style "))
            {
                user.Action(new StyleCommand(user.Canvas, cmd));
            }
            else if (cmd.StartsWith("save "))
            {
                user.Canvas.SaveSvgFile(cmd);
            }
            else if (cmd == "draw")
            {
                user.Canvas.Draw();
            }
            else if (cmd == "undo")
            {
                var success = user.Undo();
                if (!success)
                {
                    Console.WriteLine("Nothing to undo...");
                    Console.WriteLine();
                    return true;
                }
            }
            else if (cmd == "redo")
            {
                var success = user.Redo();
                if (!success)
                {
                    Console.WriteLine("Nothing to redo...");
                    Console.WriteLine();
                    return true;
                }
            }
            else if (cmd == "help")
            {
                ShowHelpMsg();
            }
            else
            {
                Console.WriteLine("Invalid directive, use 'help' for help");
            }
            Console.WriteLine();
            return true;
        }
        
        /// <summary>
        /// Show help message
        /// </summary>
        private static void ShowHelpMsg()
        {
            Console.WriteLine("Commands:");
            Console.WriteLine("          show   { left-eye | right-eye | left-brow | right-brow | mouth }");
            Console.WriteLine("          hide   { left-eye | right-eye | left-brow | right-brow | mouth }");
            Console.WriteLine("          move   { left-eye | right-eye | left-brow | right-brow | mouth } {up | down | left | right } value");
            Console.WriteLine("          reset  { left-eye | right-eye | left-brow | right-brow | mouth }");
            Console.WriteLine("          style  { left-eye | right-eye | left-brow | right-brow | mouth } {a | b}");
            Console.WriteLine("          save   { <file> }");
            Console.WriteLine("          draw");
            Console.WriteLine("          undo");
            Console.WriteLine("          redo");
            Console.WriteLine("          help");
            Console.WriteLine("          quit");
        }
    }
}