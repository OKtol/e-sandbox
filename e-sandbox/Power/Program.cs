namespace Power
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var game = new Game(800, 600, "kek");
            game.Run();
        }
    }
}
