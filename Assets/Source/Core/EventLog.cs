using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Source.Core
{
    public static class EventLog
    {
        public static readonly int LogLength = 5;
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
            UserInterface.Singleton.SetText(text, UserInterface.TextPosition.MiddleLeft, "magenta");
        }
    }
}
