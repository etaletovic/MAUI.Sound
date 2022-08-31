namespace MAUI.Sound.AudioPlayer.Extensions
{
    public static class StreamExtensions
    {
        public static void WriteToDisk(this Stream data, string destination, bool overwrite = true)
        {
            var finfo = new FileInfo(destination);

            if (finfo.Exists && !overwrite)
                throw new InvalidOperationException($"File already exists. {destination}");

            using var fileStream = File.Create(destination);
            data.CopyTo(fileStream);
            fileStream.Close();
        }
    }
}
