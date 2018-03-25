namespace Logger.Models.Layouts
{
    public class SimpleLayout : Layout
    {
        // 0 -> Date; 1 -> ErrorLevel; 2 -> Message
        public override string Format => "{0} - {1} - {2}";
    }
}
