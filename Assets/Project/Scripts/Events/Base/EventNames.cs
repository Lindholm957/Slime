
namespace Project.Scripts.Events.Base
{
    public static class EventNames
    {
        public static readonly string[] TEXT_ALL_NAMES = new[]
        {
            Slime.Stopped,
            Enemy.BecameVisible
        };

        public static class Game
        {
            public static string Started => "started";
        }

        public static class Slime
        {
            public static string Stopped => "stopped";
        }
        
        public static class Enemy
        {
            public static string BecameVisible => "became_visible";
        }
    }
}