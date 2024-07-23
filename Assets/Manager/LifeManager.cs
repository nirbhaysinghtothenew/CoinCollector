namespace Manager
{
    abstract class LifeManager
    {
        private static readonly int MaximumLife = 3;
        public static int CurrentLive = 3;

        private LifeManager()
        {
            CurrentLive = MaximumLife;
        }

        public static void DecrementLife()
        {
            if (CurrentLive <= 0 ) return;
            CurrentLive--;
        }

    }
}