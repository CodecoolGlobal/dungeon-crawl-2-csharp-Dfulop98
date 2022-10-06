using Assets.Source.Actors.SpritesCollection;
using Assets.Source.Core;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;

namespace Assets.Source.Actors.Items
{
    public class Armor : Item
    {
        public override string DefaultName => ClassName;
        public static readonly string ClassName = "Armor";
        public override char MapIcon => 'e';
        public override string DefaultSpriteId => Sprites.Item[DefaultName];

        public override void Pickup(Player player)
        {
            player.Inventory.Add(this.DefaultName);
            ActorManager.Singleton.DestroyActor(this);
            player.ChooseSpriteCollection();
            EventLog.AddEvent($"{player.Name} picks up {DefaultName}");
        }
    }
}