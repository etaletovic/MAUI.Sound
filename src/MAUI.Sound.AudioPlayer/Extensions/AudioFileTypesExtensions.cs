namespace MAUI.Sound.AudioPlayer.Extensions
{
    public static class AudioFileTypesExtensions
    {
        public static string GetFileExtension(this AudioFileTypes type) => type switch
        {
            AudioFileTypes.MP3 => ".mp3",
            AudioFileTypes.WAV => ".wav",
            AudioFileTypes.FLAC => ".flac",
            AudioFileTypes.ALAC => ".alac",
            AudioFileTypes.OGG => ".ogg",
            AudioFileTypes.AAC => ".aac",
            _ => throw new NotSupportedException("File type is not supported"),
        };
    }
}
