using Assets.Source.Actors.SpritesCollection;
using Assets.Source.Core;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;

namespace Assets.Source.Actors.Items
{
    public class Blanket : Item
    {
        public override string DefaultName => ClassName;
        public static readonly string ClassName = "Köppeny";
        public override char MapIcon => 'e';
        public override string DefaultSpriteId => Sprites.Item[DefaultName];

        public override void Pickup(Player player)
        {
            player.Armor = 100;
            PlayerUtilities.ChooseSpriteCollection();
            ActorManager.Singleton.DestroyActor(this);
            EventLog.AddEvent($"{player.Name} picks up {DefaultName}");
        }
    }
}