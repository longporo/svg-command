namespace svg_command.pojo.command
{
    /// <summary>
    /// The Command plays the Command role, declares the do and undo function,
    /// its sub-class interacts with the Receiver(FaceCanvas) to execute the corresponding operations
    /// </summary>
    public abstract class Command
    {
        public abstract void Do();
        public abstract void Undo();
    }
}