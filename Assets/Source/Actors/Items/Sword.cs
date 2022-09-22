
using Assets.Source.Core;
using DungeonCrawl.Actors;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;
using Debug = UnityEngine.Debug;

namespace Assets.Source.Actors.Items
{
    public class Sword : Item
    {
        public override string DefaultName => "Sword";
        public override string DefaultSpriteId => "PackCastle01_43";

        public override void Pickup(Player player)
        {
            // Apply change
            player.Damage += 10;
            player._inventory.Add(this);
            ActorManager.Singleton.DestroyActor(this);
            EventLog.AddEvent($"{player.Name} picks up {DefaultName}");
        }
    }
}
