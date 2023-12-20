using System.Text;

namespace P01.Stream_Progress
{
    public class Music : IStreamable
    {
        private string artist;
        private string album;

        public Music(string artist, string album, int length, int bytesSent)
        {
            this.artist = artist;
            this.album = album;
            this.Length = length;
            this.BytesSent = bytesSent;
        }

        public int Length { get; private set; }

        public int BytesSent { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new();

            
            sb.AppendLine($"Streaming {base.ToString()}: {this.artist} {this.album}");

            return sb.ToString().Trim();
        }
    }
}
