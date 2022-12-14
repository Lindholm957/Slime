
namespace Project.Scripts.Events.Base
{
    public static class EventNames
    {
        public static readonly string[] TEXT_ALL_NAMES = new[]
        {
            Slime.Stopped,
            Enemy.BecameVisible,
            Enemy.Died,
            Data.SoftCoinChanged,
            Data.TotalDamageChanged,
            Data.AttackSpeedChanged,
            Data.MaxHealthPointsChanged
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
            public static string Died => "died";
        }
        
        public static class Data
        {
            public static string SoftCoinChanged => "soft_coin_changed";
            public static string TotalDamageChanged => "total_damage_changed";
            public static string AttackSpeedChanged => "attack_speed_changed";
            public static string MaxHealthPointsChanged => "max_health_points_changed";
        }
    }
}