using Assets.Source.Actors.SpritesCollection;
using Assets.Source.Core;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;

namespace Assets.Source.Actors.Items
{
    public class Key : Item
    {
        // in txt: K
        public override string DefaultName => "Key";
        public override string DefaultSpriteId => Sprites.ItemSprites["Key"];
        public override void Pickup(Player player)
        {
          
            player.Inventory.Add(this);
            ActorManager.Singleton.DestroyActor(this);
            EventLog.AddEvent($"{player.Name} picks up {DefaultName}");
        }
    }
}
