using DungeonCrawl.Core;

namespace DungeonCrawl.Actors.Static
{
    public class Door: Actor
    {
        public override bool Detectable => true;
        public override string DefaultSpriteId => "kenney_transparent_146";
        public override string DefaultName => "Door";

        public void DoorOpen()
        {
            ActorManager.Singleton.Spawn<OpenDoor>(Position);
            ActorManager.Singleton.DestroyActor(this);
        }
    }

    public class OpenDoor: Actor
    {
        public override bool Detectable => false;
        public override string DefaultSpriteId => "kenney_transparent_147";
        public override string DefaultName => "OpenDoor";

    }
}
