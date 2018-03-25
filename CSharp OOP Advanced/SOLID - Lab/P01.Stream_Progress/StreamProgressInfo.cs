namespace P01.Stream_Progress
{
    public class StreamProgressInfo
    {
        private IStreamProgress streamProgress;

        public StreamProgressInfo(IStreamProgress streamResult)
        {
            this.streamProgress = streamResult;
        }

        // If we want to stream a music file, we can't

        public int CalculateCurrentPercent()
        {
            return (this.streamProgress.BytesSent * 100) / this.streamProgress.Length;
        }
    }
}
