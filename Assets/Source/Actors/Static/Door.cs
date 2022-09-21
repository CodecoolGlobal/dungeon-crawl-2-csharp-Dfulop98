using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization;

namespace DungeonCrawl.Actors.Static
{
    public class Door: Actor
    {
        private string DoorId = "kenney_transparent_146";
        //true if closed
        public bool IsClosed = true;

        public override bool Detectable => IsClosed;
        public override string DefaultSpriteId => DoorId;
        public override string DefaultName => "Door";

        public void DoorOpen()
        {
            DoorId = "kenney_transparent_147";
            IsClosed = false;
        }
        
    }
}
