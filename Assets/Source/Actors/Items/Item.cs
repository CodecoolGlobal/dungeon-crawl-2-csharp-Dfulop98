using DungeonCrawl.Actors;
using DungeonCrawl.Actors.Characters;

namespace Assets.Source.Actors.Items
{
    public abstract class Item : Actor
    {
        public string Name;
        public Item()
        {
            Name = DefaultName;
        }
        public abstract void Pickup(Player player);
    }
}
