
using Assets.Source.Actors.SpritesCollection;
using Assets.Source.Core;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;

namespace Assets.Source.Actors.Items
{
    public class Sword : Item
    {
        public override string DefaultName => "Sword";
        public override string DefaultSpriteId => Sprites.ItemSprites["Sword"];

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
