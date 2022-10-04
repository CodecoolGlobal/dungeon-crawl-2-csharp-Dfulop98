using Assets.Source.Actors.SpritesCollection;
using Assets.Source.Core;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;

namespace Assets.Source.Actors.Items
{
    internal class Spear : Item
    {
        public override string DefaultName => "Halandzsa";
        public override string DefaultSpriteId => Sprites.ItemSprites["Spear"];

        public override void Pickup(Player player)
        {
            // Apply change
            player.Damage += 1000;
            player.Inventory.Add(this);
            player.UsedSpriteCollection = Sprites.PlayerWSPearSprites;
            ActorManager.Singleton.DestroyActor(this);
            EventLog.AddEvent($"{player.Name} picks up {DefaultName}");

        }
    }
}
