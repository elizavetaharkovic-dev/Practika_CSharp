class MediaDevice : IAudioPlayer, IVideoPlayer
{
    void IAudioPlayer.Play(string fileName)
    {
        Console.WriteLine($"Воспроизведение аудио: {fileName}");
    }
    void IVideoPlayer.Play(string fileName)
    {
        Console.WriteLine($"Воспроизведение видео:{fileName}");
    }
}