using DungeonCrawl.Actors;
using DungeonCrawl.Actors.Characters;

namespace Assets.Source.Actors.Items
{
    public abstract class Item : Actor
    {
        public abstract void Pickup(Player player);
      
    }
}
