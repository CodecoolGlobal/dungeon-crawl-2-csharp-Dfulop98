using DungeonCrawl.Core;
using Assets.Source.Core;
using DungeonCrawl.Actors.Characters;
using Assets.Source.Actors.SpritesCollection;

namespace Assets.Source.Actors.Items
{
    internal class HealthPotion : Item
    {
        public override char MapIcon => ',';
        public override string DefaultName => ClassName;
        public static readonly string ClassName = "Health Potion";
        public override string DefaultSpriteId => Sprites.Item["HealthPotion"];

        public override void Pickup(Player player)
        {
            if (player.Health <= 90)
            {
                // Apply change
                player.Health += 10;
                ActorManager.Singleton.DestroyActor(this);
                EventLog.AddEvent($"{player.Name} picks up {DefaultName}");
            }
            else if (90 < player.Health && player.Health < 100)
            {
                player.Health = 100;
                ActorManager.Singleton.DestroyActor(this);
                EventLog.AddEvent($"{player.Name} picks up {DefaultName}");
            }
        }
    }
}
