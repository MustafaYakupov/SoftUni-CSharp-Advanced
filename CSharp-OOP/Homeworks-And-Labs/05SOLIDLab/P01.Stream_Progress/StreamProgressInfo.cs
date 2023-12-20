using System.Text;

namespace P01.Stream_Progress
{
    public class StreamProgressInfo
    {
        private IStreamable stream;

        public StreamProgressInfo(IStreamable stream)
        {
            this.stream = stream;
        }

        public int CalculateCurrentPercent()
        {
            return (this.stream.BytesSent * 100) / this.stream.Length;
        }

        public override string ToString()
        {
            StringBuilder sb = new();

            sb.AppendLine($"{stream.GetType().Name}");

            return sb.ToString().Trim();
        }
    }
}
