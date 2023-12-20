namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {
            IStreamable music = new Music("Eminem", "Album Name", 10, 10);
            IStreamable file = new File("FileName here", 10, 10);

            StreamProgressInfo streamingMusic = new StreamProgressInfo(music);
            StreamProgressInfo streamingFile = new StreamProgressInfo(file);

            System.Console.WriteLine(streamingMusic);
            System.Console.WriteLine(streamingFile);
        }
    }
}
