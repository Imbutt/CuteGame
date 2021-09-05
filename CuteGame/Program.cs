using System;

namespace CuteGame
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new SpyGame())
                game.Run();
        }
    }
}
