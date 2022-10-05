using Assets.Source.Core;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;

namespace Assets.Source.Actors.Items
{
    internal class Spear : Item
    {
        public override char MapIcon => 'G';
        public override string DefaultName => "Halandzsa";
        public override string DefaultSpriteId => "PackCastle01_9";

        public override void Pickup(Player player)
        {
            // Apply change
            player.Damage += 1000;
            player.Inventory.Add(this);
            ActorManager.Singleton.DestroyActor(this);
            EventLog.AddEvent($"{player.Name} picks up {DefaultName}");
        }
    }
}
