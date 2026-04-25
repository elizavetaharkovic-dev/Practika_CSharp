// Видеопроигрыватель
class Program
{
    static void Main()
    {
        MediaDevice device = new MediaDevice();
        IAudioPlayer audio = device;
        audio.Play("file1.mp3");
        IVideoPlayer video = device;
        video.Play("file2.mp4");
    }
}