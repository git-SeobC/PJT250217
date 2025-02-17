namespace L20250217
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Engine engine = Engine.Instance();

            engine.Load();

            engine.Run();

            //engine.Stop();
        }
    }
}