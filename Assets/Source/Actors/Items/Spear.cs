using Assets.Source.Actors.SpritesCollection;
using Assets.Source.Core;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;

namespace Assets.Source.Actors.Items
{
    internal class Spear : Item
    {
        public override char MapIcon => 'G';
        public override string DefaultName => ClassName;
        public static readonly string ClassName = "Halandzsa";
        public override string DefaultSpriteId => Sprites.Item[DefaultName];

        public override void Pickup(Player player)
        {
            UpdateSprite(player);
            player.Inventory.Add(this.DefaultName);
            ActorManager.Singleton.DestroyActor(this);
            EventLog.AddEvent($"{player.Name} picks up {DefaultName}");

        }

        private void UpdateSprite(Player player)
        {
            if (player.UsedSpriteCollection == Sprites.Warrior
                || player.UsedSpriteCollection == Sprites.WarriorWithSword)
                player.UsedSpriteCollection = Sprites.WarriorWithSpear;
            else if (player.UsedSpriteCollection == Sprites.WarriorArmor
                || player.UsedSpriteCollection == Sprites.WarriorArmorSword)
                player.UsedSpriteCollection = Sprites.WarriorArmorSpear;
        }
    }
}
