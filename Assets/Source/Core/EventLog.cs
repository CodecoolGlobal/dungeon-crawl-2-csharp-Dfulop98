using System.Collections.Generic;

namespace Assets.Source.Core
{
    public static class EventLog
    {
        public static readonly int LogLength = 3;
        public static List<string> Events = new List<string>();

        public static void AddEvent(string text)
        {
            Events.Add(text);
            if (Events.Count > LogLength)
            {
                Events.RemoveAt(0);
            }
            UpdateLog();
        }

        public static void UpdateLog()
        {
            string text = "";
            int max = (LogLength > Events.Count) ? Events.Count : LogLength;
            for (int i = 0; i < max; i++)
            {
                text += $"{Events[i]}\n";
            }
            UserInterface.Singleton.SetText(text, UserInterface.TextPosition.BottomLeft, "red");
        }
    }
}
