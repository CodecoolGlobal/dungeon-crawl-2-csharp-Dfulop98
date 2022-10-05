
using System.Runtime.CompilerServices;
using Assets.Source.Core;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;

namespace Assets.Source.Actors.Items
{
    public class Sword : Item
    {
        public override char MapIcon => 'w';
        public override string DefaultName => "Sword";
        public override string DefaultSpriteId => "PackCastle01_43";

        public override void Pickup(Player player)
        {
            // Apply change
            player.Damage += 10;
            player.Inventory.Add(this);
            ActorManager.Singleton.DestroyActor(this);
            EventLog.AddEvent($"{player.Name} picks up {DefaultName}");
        }
    }
}
