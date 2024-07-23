namespace Manager
{
    public abstract class MusicManager 
    {
        private  static bool _shouldPlayMusic = true;

        public static void ChangeMusicMode(bool value)
        {
            _shouldPlayMusic = value;
        }

        public static bool ShouldPlayMusic()
        {
            return _shouldPlayMusic;
        }
    }
}