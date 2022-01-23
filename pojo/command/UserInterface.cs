using System.Collections.Generic;

namespace svg_command.pojo.command
{
    /// <summary>
    /// The UserInterface plays the Invoker role and carries out the commands to execute and is responsible for the undo and redo function
    /// </summary>
    public class UserInterface
    {
        public readonly FaceCanvas Canvas = FaceCanvas.GetInstance;
        private Stack<Command> UNDO_STACK = new ();
        private Stack<Command> REDO_STACK = new ();
        
        public void Action(Command command)
        {
            UNDO_STACK.Push(command);
            REDO_STACK.Clear();
            command.Do();
        }

        public bool Undo()
        {
            if (UNDO_STACK.Count == 0)
            {
                return false;
            }
            var command = UNDO_STACK.Pop();
            command.Undo();
            REDO_STACK.Push(command);
            return true;
        }

        public bool Redo()
        {
            if (REDO_STACK.Count == 0)
            {
                return false;
            }
            var command = REDO_STACK.Pop();
            command.Do();
            UNDO_STACK.Push(command);
            return true;
        }
    }
}