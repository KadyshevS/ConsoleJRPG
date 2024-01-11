using System;

using Game.Util;

namespace Game
{
    class Player
    {
        public float PosX { get; }
        public float PosY { get; }

        public Player(float posX, float posY)
        {
            PosX = posX;
            PosY = posY;
        }
    }
    abstract class Game
    {
        protected virtual void OnStart() { }
        protected virtual void OnUpdate(float delta) { }
        protected virtual void OnEnd() { }

        public bool ShouldEnd { get; } = false;
        public int FrameDelay { get; set; } = 50;

        private static DateTime Time1 = DateTime.Now;
        private static DateTime Time2 = DateTime.Now;     
        
        public static float GetDeltaTime()
        {
            Time2 = DateTime.Now;
            float deltaTime = (Time2.Ticks - Time1.Ticks) / 10000000f;
            Time1 = Time2;
            return deltaTime;
        }

        public void Run()
        {
            OnStart();
            while(!ShouldEnd)
            {
                OnUpdate( GetDeltaTime() );
                System.Threading.Thread.Sleep(FrameDelay);
            }
            OnEnd();
        }
    }
    class MyGame : Game
    {
        private string Map =
            "########################################\n" +
            "#                                      #\n" +
            "#                                      #\n" +
            "#                                      #\n" +
            "#                                      #\n" +
            "#                                      #\n" +
            "#                                      #\n" +
            "#                                      #\n" +
            "#                                      #\n" +
            "#                                      #\n" +
            "#                                      #\n" +
            "#                                      #\n" +
            "#                                      #\n" +
            "#                                      #\n" +
            "#                                      #\n" +
            "#                                      #\n" +
            "########################################";

        string HealthBar = "\n\nHealth: ----------\nArmor: -----------\n";

        protected override void OnStart()
        {
        }
        protected override void OnUpdate(float delta)
        {
            Console.Clear();
            string res = Utils.AppendString(Map, HealthBar, 4);
            Console.WriteLine(res);
            Console.WriteLine($"\nDelta time: {delta}");
        }
        protected override void OnEnd()
        {
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var myGame = new MyGame();
            myGame.Run();
            
            Console.ReadKey();
        }
    }
}
