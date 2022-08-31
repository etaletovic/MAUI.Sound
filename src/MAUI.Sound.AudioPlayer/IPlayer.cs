namespace MAUI.Sound.AudioPlayer
{
    public interface IPlayer
    {
        public bool IsPlaying { get; }
        void Play();
        void Pause();

        void LoadData(string fileName, AudioFileTypes type);
        void LoadData(Stream data, AudioFileTypes type);
    }
}
