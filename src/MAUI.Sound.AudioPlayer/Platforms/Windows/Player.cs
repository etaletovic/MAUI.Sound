using MAUI.Sound.AudioPlayer.Extensions;
using Windows.Media.Core;
using Windows.Media.Playback;

namespace MAUI.Sound.AudioPlayer
{
    public class Player : IPlayer, IDisposable
    {
        private MediaPlayer _player = new();
        private bool disposedValue;
        public bool IsPlaying { get; private set; }

        public void LoadData(Stream data, AudioFileTypes type)
        {
            var path = Path.Combine(FileSystem.Current.CacheDirectory, $"{Guid.NewGuid()}{type.GetFileExtension()}");

            data.WriteToDisk(path);

            LoadData(path, type);
        }

        public void LoadData(string filePath, AudioFileTypes type)
        {
            _player.Source = MediaSource.CreateFromUri(new Uri(filePath));
        }

        public void Pause()
        {
            _player.Pause();
            IsPlaying = false;
        }

        public void Play()
        {
            _player.Play();
            IsPlaying = true;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    _player.Dispose();

                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~WindowsPlayer()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }


    }
}
