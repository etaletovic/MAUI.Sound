namespace MAUI.Sound.AudioPlayer
{
    // All the code in this file is only included on Mac Catalyst.
    public class MacCatalystPlayer : IPlayer
    {
        public bool IsPlaying => throw new NotImplementedException();

        public void LoadData(string fileName, AudioFileTypes type)
        {
            throw new NotImplementedException();
        }

        public void LoadData(Stream data, AudioFileTypes type)
        {
            throw new NotImplementedException();
        }

        public void Pause()
        {
            throw new NotImplementedException();
        }

        public void Play()
        {
            throw new NotImplementedException();
        }
    }
}