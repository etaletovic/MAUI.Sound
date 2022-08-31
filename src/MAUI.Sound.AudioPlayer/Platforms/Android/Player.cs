using Android.Media;
using MAUI.Sound.AudioPlayer.Extensions;
using Stream = System.IO.Stream;

namespace MAUI.Sound.AudioPlayer
{
    public class Player : IPlayer, IDisposable
    {
        private readonly MediaPlayer _player = new();
        private bool disposedValue;

        public bool IsPlaying { get; private set; }

        public void LoadData(Stream data, AudioFileTypes type)
        {
            var path = Path.Combine(FileSystem.Current.CacheDirectory, $"{Guid.NewGuid()}{type.GetFileExtension()}");

            data.WriteToDisk(path);

            LoadData(path, type);
        }

        public void LoadData(string filePath, AudioFileTypes types)
        {
            _player.SetDataSource(filePath);
            _player.Prepare();
        }

        public void Play()
        {
            _player.Start();
            IsPlaying = true;
        }

        public void Pause()
        {
            _player.Pause();
            IsPlaying = false;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    _player?.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~AndroidPlayer()
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
