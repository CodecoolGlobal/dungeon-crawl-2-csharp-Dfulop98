using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Source.Core
{
    public class EventLog
    {
        public List<string> Events = new List<string>();
        public void AddEvent(string text)
        {
            Console.WriteLine("event");
        }
    }
}
